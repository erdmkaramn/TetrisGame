using System;

namespace Tetris
{
    static class SekilIsleyici
    {
        private static sekil[] dizi;
        
        static SekilIsleyici()
        {
            // Şekiller oluşturuldu ve diziye eklendi.
            dizi = new sekil[]
                {
                    new sekil {
                        genislik = 2,
                        yukseklik = 2,
                        noktalar = new int[,]
                        {
                            { 1, 1 },
                            { 1, 1 }
                        }
                    },
                    new sekil {
                        genislik = 1,
                        yukseklik = 4,
                        noktalar = new int[,]
                        {
                            { 1 },
                            { 1 },
                            { 1 },
                            { 1 }
                        }
                    },
                    new sekil {
                        genislik = 3,
                        yukseklik = 2,
                        noktalar = new int[,]
                        {
                            { 0, 1, 0 },
                            { 1, 1, 1 }
                        }
                    },
                    new sekil {
                        genislik = 3,
                        yukseklik = 2,
                        noktalar = new int[,]
                        {
                            { 0, 0, 1 },
                            { 1, 1, 1 }
                        }
                    },
                    new sekil {
                        genislik = 3,
                        yukseklik = 2,
                        noktalar = new int[,]
                        {
                            { 1, 0, 0 },
                            { 1, 1, 1 }
                        }
                    },
                    new sekil {
                        genislik = 3,
                        yukseklik = 2,
                        noktalar = new int[,]
                        {
                            { 1, 1, 0 },
                            { 0, 1, 1 }
                        }
                    },
                    new sekil {
                        genislik = 3,
                        yukseklik = 2,
                        noktalar = new int[,]
                        {
                            { 0, 1, 1 },
                            { 1, 1, 0 }
                        }
                    }
                };
        }

        // Diziyi rastgele bir şekilde oluşturun
        public static sekil RastgeleSekilAl()
        {
            var Sekil = dizi[new Random().Next(dizi.Length)];

            return Sekil;
        }
    }
}
