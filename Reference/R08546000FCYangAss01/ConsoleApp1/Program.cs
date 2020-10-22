using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( "Who are your?" );
            string yourName;
            yourName = Console.ReadLine();
            Console.Write( $"Hello! {yourName} !!");
            Console.ReadKey();
        }
    }
}
