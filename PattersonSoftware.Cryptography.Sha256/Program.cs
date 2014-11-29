using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PattersonSoftware.Cryptography.Sha256
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length != 1)
            {
                Console.WriteLine("sha256sum: invalid arguments");
                Console.WriteLine("\tUsage: sha256sum [filename]");
                return;
            }
            Stream s;

            try
            {
                s = new FileStream(args[0], FileMode.Open);
            }
            catch
            {
                Console.WriteLine("sha256sum: invalid filename");
                return;
            }

            var sha256Hash = SHA256.Create().ComputeHash(s);
            s.Close();

            var md5Str = new StringBuilder("");

            foreach (var b in sha256Hash)
                md5Str.Append(b.ToString("x2"));

            Console.WriteLine(md5Str + " *" + args[0]);
        }
    }
}
