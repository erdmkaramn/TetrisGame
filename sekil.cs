namespace Tetris
{
    class sekil
    {
        public int genislik;
        public int yukseklik;
        public int[,] noktalar;

        private int[,] noktalarDerle;
        public void Dondur()
        {
            
            noktalarDerle = noktalar;

            noktalar = new int[genislik, yukseklik];
            for (int i = 0; i < genislik; i++)
            {
                for (int j = 0; j < yukseklik; j++)
                {
                    noktalar[i, j] = noktalarDerle[yukseklik - 1 - j, i];
                }
            }

            var temp = genislik;
            genislik = yukseklik;
            yukseklik = temp;
        }

        
        public void sekliDondur()
        {
            noktalar = noktalarDerle;

            var temp = genislik;
            genislik = yukseklik;
            yukseklik = temp;
        }
    }
}
