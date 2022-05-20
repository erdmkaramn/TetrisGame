using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;

using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {


        sekil guncelsekil;
        sekil sonrakisekil;
        Timer timer = new Timer();
        int skor = 0;
        int sure = 0;
        Bitmap cerceveBitMap;
        Graphics cerceveGrafik;
        int cerceveGenisligi = 15;
        int cerceveYuksekligi = 20;
        int[,] cerceveKumesi;
        int kumeBoyutu = 20;


        public Form1()
        {
            InitializeComponent();
        }
        
        private void CerceveyiYukle()
        {
            // Oyun alanı genişliğini küme boyutuna göre ayarlandı.
            cercevePictureBx.Width = cerceveGenisligi * kumeBoyutu;
            cercevePictureBx.Height = cerceveYuksekligi * kumeBoyutu;

            // Oyun alanının boyutuna göre bitmap oluşturuldu.
            cerceveBitMap = new Bitmap(cercevePictureBx.Width, cercevePictureBx.Height);

            cerceveGrafik = Graphics.FromImage(cerceveBitMap);

            cerceveGrafik.FillRectangle(Brushes.Black, 0, 0, cerceveBitMap.Width, cerceveBitMap.Height);

            // bitmapi oyun alanı içerisine yüklendi
            cercevePictureBx.Image = cerceveBitMap;
            
            // küme tanımlandı
            cerceveKumesi = new int[cerceveGenisligi, cerceveYuksekligi];
        }

        int mevcudX;
        int mevcudY;
        private sekil rastgelesekil()
        {
            var sekil = SekilIsleyici.RastgeleSekilAl();
            
            // x ve y değerleri merkezdeymiş gibi hesaplandı
            mevcudX = 7;
            mevcudY = -sekil.yukseklik;

            return sekil;
        }

        Bitmap bitmapCalisma;
        Graphics grafikCalisma;
        private void Timer_Tick(object sender, EventArgs e)
        {
            var haraketVarMi = hareketisagla(hareket: 1);

            // eğer yere ulaştıysa veya herhangi bir şekle dokunduysa
            if (!haraketVarMi)
            {
                // yeni bitmap tanımlandı
                cerceveBitMap = new Bitmap(bitmapCalisma);

                cerceveguncelle();

                // yeni şekle geç
                guncelsekil = sonrakisekil;
                sonrakisekil = sonrakisekilegec();
                
                DoluSatırıSilSkorGuncelle();
            }
        }

        private void cerceveguncelle()
        {
            for (int i = 0; i < guncelsekil.genislik; i++)
            {
                for (int j = 0; j < guncelsekil.yukseklik; j++)
                {
                    if (guncelsekil.noktalar[j, i] == 1)
                    {
                        if (mevcudY < 0)
                        {
                            timer.Enabled = false;
                            puanTimer.Enabled = false;
                            MessageBox.Show("Oyun Bitti");
                            yenidenBaslatBtn.Enabled = true;
                            break;
                        }

                        cerceveKumesi[mevcudX + i, mevcudY + j] = 1;
                    }
                }
            }
        }


        // hareketi kısıtlamak için
        private bool hareketisagla(int hareket = 0, int hareketYonu = 0)
        {

            var yeniX = mevcudX + hareketYonu;
            var yeniY = mevcudY + hareket;

            // blok eğer en aşşağıda veya yanlardaysa
            if (yeniX < 0 || yeniX + guncelsekil.genislik > cerceveGenisligi
                || yeniY + guncelsekil.yukseklik > cerceveYuksekligi)
                return false;

            // eğer başka herhangi bir bloğa değdiyse
            for (int i = 0; i < guncelsekil.genislik; i++)
            {
                for (int j = 0; j < guncelsekil.yukseklik; j++)
                {
                    if (yeniY + j > 0 && cerceveKumesi[yeniX + i, yeniY + j] == 1 && guncelsekil.noktalar[j, i] == 1)
                        return false;
                }
            }

            mevcudX = yeniX;
            mevcudY = yeniY;

            SekilCiz();

            return true;
        }

        private void SekilCiz()
        {
            bitmapCalisma = new Bitmap(cerceveBitMap);
            grafikCalisma = Graphics.FromImage(bitmapCalisma);

            for (int i = 0; i < guncelsekil.genislik; i++)
            {
                for (int j = 0; j < guncelsekil.yukseklik; j++)
                {
                    if (guncelsekil.noktalar[j, i] == 1)
                    {
                        grafikCalisma.FillRectangle(Brushes.Red, (mevcudX + i) * kumeBoyutu, (mevcudY + j) * kumeBoyutu, kumeBoyutu, kumeBoyutu);
                    }
                        
                }
            }
            cercevePictureBx.Image = bitmapCalisma;

            
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var yatayHareket = 0;
            var dikeyHareket = 0;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    yatayHareket--;
                    break;
                
                case Keys.Right:
                    yatayHareket++;
                    break;

                case Keys.Down:
                    dikeyHareket++;
                    break;

                case Keys.Up:
                    guncelsekil.Dondur();
                    break;
                default:
                    return;
            }

            var hareketBasariliMi = hareketisagla(dikeyHareket, yatayHareket);

            // eğer şekil döndürüldüğünde kenarlara çarpıyorsa (örneğin şekil döndüğünde yan sınırları aşabilir) bunun için şekli mevcud hataya düşmemek için yeniden hizlama işlemi
            if (!hareketBasariliMi && e.KeyCode == Keys.Up)
                guncelsekil.sekliDondur();
        }

       
        public void DoluSatırıSilSkorGuncelle()
        {
            // her satır kontrol edildi
            for (int i = 0; i < cerceveYuksekligi; i++)
            {
                int j;
                for (j = cerceveGenisligi - 1; j >= 0; j--)
                {
                    if (cerceveKumesi[j, i] == 0)
                        break;
                }

                if (j == -1)
                {
                    // skoru güncelle
                    skor += 100;
                    skorGuncelle();


                    // küme resetlenmesi için
                    for (j = 0; j < cerceveGenisligi; j++)
                    {
                        for (int k = i; k > 0; k--)
                        {
                            cerceveKumesi[j, k] = cerceveKumesi[j, k - 1];
                        }

                        cerceveKumesi[j, 0] = 0;
                    }
                }
            }

            // güncellenen kümedeki şekil çizdiriliyor
            for (int i = 0; i < cerceveGenisligi; i++)
            {
                for (int j = 0; j < cerceveYuksekligi; j++)
                {
                    cerceveGrafik = Graphics.FromImage(cerceveBitMap);

                    if(cerceveKumesi[i, j] == 1)
                    {
                        cerceveGrafik.FillRectangle(Brushes.Red,i * kumeBoyutu, j * kumeBoyutu, kumeBoyutu,kumeBoyutu);
                    }
                    else
                    {
                        cerceveGrafik.FillRectangle(Brushes.Black, i * kumeBoyutu, j * kumeBoyutu, kumeBoyutu, kumeBoyutu);
                    }
                }
            }

            cercevePictureBx.Image = cerceveBitMap;
        }

        Bitmap sonrakiSekilBitmap;
        Graphics sonrakiSekilGrafik;
        private sekil sonrakisekilegec()
        {
            var sekil = rastgelesekil();

            // sonraki gelecek olan şekil belirlendi
            sonrakiSekilBitmap = new Bitmap(6 * kumeBoyutu, 6 * kumeBoyutu);
            sonrakiSekilGrafik = Graphics.FromImage(sonrakiSekilBitmap);

            sonrakiSekilGrafik.FillRectangle(Brushes.LightGray, 0, 0, sonrakiSekilBitmap.Width, sonrakiSekilBitmap.Height);

            // ideal posizyona göre ayarlama yapıldı
            var baslangicX = (6 - sekil.genislik) / 2;
            var baslangicY = (6 - sekil.yukseklik) / 2;

            for (int i = 0; i < sekil.yukseklik; i++)
            {
                for (int j = 0; j < sekil.genislik; j++)
                {

                    if(sekil.noktalar[i, j] == 1)
                    {
                        sonrakiSekilGrafik.FillRectangle(Brushes.Blue, (baslangicX + j) * kumeBoyutu, (baslangicY + i) * kumeBoyutu,kumeBoyutu,kumeBoyutu);
                    }
                    else{
                        sonrakiSekilGrafik.FillRectangle(Brushes.LightGray, (baslangicX + j) * kumeBoyutu, (baslangicY + i) * kumeBoyutu, kumeBoyutu, kumeBoyutu);
                    }
                }
            }

            sonrakiPicture.Size = sonrakiSekilBitmap.Size;
            sonrakiPicture.Image = sonrakiSekilBitmap;

            return sekil;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sure++;
            skor += sure;
            skorGuncelle();
            sure = 0;
        }

        private void baslatBtn_Click(object sender, EventArgs e)
        {
            CerceveyiYukle();

            guncelsekil = rastgelesekil();
            sonrakisekil = sonrakisekilegec();

            timer.Tick += Timer_Tick;
            timer.Interval = 500;
            timer.Start();
            puanTimer.Start();

            this.KeyDown += Form1_KeyDown;

            baslatBtn.Visible = false;
            yenidenBaslatBtn.Enabled = false;//yön tuşlarını kullanabilmek için false yapıldı
        }

        private void yenidenBaslatBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void skorGuncelle()
        {
            puanLbl.Text = skor.ToString();
        }
    }
}
