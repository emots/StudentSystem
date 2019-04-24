using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Console.WriteLine("Enter fak Number:");
            //string FakNum = Console.ReadLine();

            //StudentData.PrepareCertificate(FakNum);
            //ReadCertificateDocument();
           
            //StudentData.CertificateToAll();
            ReadCertificateDocument();
        }

        private static void ReadCertificateDocument()
        {
            StreamReader sr = new StreamReader("certificate.txt");
            StringBuilder sb = new StringBuilder();
            sb.Append("Certificate Document" + Environment.NewLine);
            sb.Append(sr.ReadToEnd());
            Console.WriteLine(sb.ToString());
        }
    }
}
