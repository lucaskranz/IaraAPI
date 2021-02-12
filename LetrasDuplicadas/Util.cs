using System;
using System.Collections.Generic;
using System.Text;

namespace LetrasDuplicadas
{
    class Util
    {
        public static void RemovaLetrasDuplicadas(ref string[] palavras)
        {
            int cont = 0;
            char letraAtual, letraAnterior;

            for (int i = 0; i < palavras.Length; i++)
            {
                int n = 0;
                while (n < palavras[i].Length)
                {
                    if (n == 0)
                    {
                        n++;
                        continue;
                    }

                    letraAtual = palavras[i][n];
                    letraAnterior = palavras[i][n - 1];

                    if (letraAtual == letraAnterior)
                        palavras[i] = palavras[i].Remove(n, 1);
                    else
                        n++;
                }
            }

            foreach(string palavra in palavras)
            {
                Console.Write(palavra + " ");
            }
            Console.Write("\n");
        } 
    }
}
