using System;

namespace Bank_Panic
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (BankPanic game = new BankPanic())
            {
                game.Run();
            }
        }
    }
#endif
}

