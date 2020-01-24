using System;

namespace Game.Cli
{
    class Program
    {
        static int Main(string[] args)
        {
            var returnValue = new Program().Run();

            Console.WriteLine("Press any key");
            Console.ReadKey();
            
            return returnValue;
        }

        private int Run()
        {

            var levensloop = new Engine.Game();

            levensloop.Registery.Register(new WriteToConsoleSystem());
            

            var entity = levensloop.EntityRegistery.Create("Persoon 1");
            var entity3 = levensloop.EntityRegistery.Create("Persoon 3");

            levensloop.Run();

            return 0;

        }
    }
}
