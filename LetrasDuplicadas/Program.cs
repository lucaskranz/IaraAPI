using System;

namespace LetrasDuplicadas
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] duplicados1 = { "abracadabra", "allottee", "assessee" };
            string[] duplicados2 = {"kelless", "keenness"};
            string[] duplicados3 = { "booooooola", "macaarrrrrao", "carrrrrrneeeeee" };

            Util.RemovaLetrasDuplicadas(ref duplicados1);
            Util.RemovaLetrasDuplicadas(ref duplicados2);
            Util.RemovaLetrasDuplicadas(ref duplicados3);
        }
    }
}
