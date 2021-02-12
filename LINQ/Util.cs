using System.Linq;
using System.Collections.Generic;
using System;

namespace LINQ
{
    class Util
    {
        public static void ArrayImpar(int[] array)
        {
            IEnumerable<int> queryImpar =
               from numero in array
               where (numero % 2 != 0)
               select numero;

            if (array.Count() == queryImpar.Count())
            {
                Console.WriteLine("Todos os números são ímpares!");
            }
            else
            {
                Console.Write("Somente esses números são ímpares:\n");
                foreach (int i in queryImpar)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
