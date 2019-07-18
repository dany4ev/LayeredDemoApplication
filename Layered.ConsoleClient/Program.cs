using LayeredDemo.ViewModels;
using System;

namespace Layered.ConsoleClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            var person = new PersonVM
            {
                FullName = "Danish Farman"
            };



            Console.ReadKey();
        }
    }
}
