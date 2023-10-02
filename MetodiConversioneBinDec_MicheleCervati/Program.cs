using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodiConversioneBinDec_MicheleCervati
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] valoriTest = {
                true, false, true, true, // 1011
                true, false, true, false, // 1010
                true, false, true, false, // 1010
                false, true, true, true // 0111
            };
            int[] testIp = { 0, 0, 0, 0 };
            int numeroDecimale = Convert_Binario_To_Intero(valoriTest);
            Console.WriteLine(numeroDecimale);

            int numDec2 = Convert_Decimale_Puntato_To_Decimale(testIp);
            Console.WriteLine(numDec2);

            Console.ReadLine();
        }

        static int Convert_Binario_To_Intero(bool[] b) //se inserito un numero convertibile a int ritorno int altrimenti ritorno -1
        {
            long numDecLong = 0;
            const int baseInput = 2;

            for (int i = b.Length - 1; i >= 0; i--)
            {
                if (b[i])
                {
                    numDecLong = numDecLong + (long)Math.Pow(baseInput, b.Length - 1 - i); //1 * 2 alla 0, 1 * 2 alla 1, 1* 2 alla 2 etc...
                }
            }

            if (numDecLong > int.MaxValue) //controllo che il numero non superi Int.MaxValue
            {
                return -1;
            }

            return (int)numDecLong;
        }

        static int Convert_Decimale_Puntato_To_Decimale(int[] dp) //se inserito un numero valido ritorno l'intero convertito, altrimenti se il numero è troppo grande per un int ritorno -1
        {
            long numDecLong = 0; //numDec viene assegnato long perchè il massimo valore dai 4 numeri in input è 4.294.967.295 ma Int.MaxValue è solo di 2,147,483,647
            const int baseInput = 256;

            for (int i = dp.Length - 1; i >= 0; i--)
            {

                numDecLong = numDecLong + (long)dp[i] * (long)Math.Pow(baseInput, dp.Length - 1 - i);

            }

            if (numDecLong > int.MaxValue) //controllo che il numero non superi Int.MaxValue
            {
                return -1;
            }

            return (int)numDecLong; //ritorno il numero castato ad int
        }



    }
}
