using System;

namespace Delegates
{

    public delegate int Sum3Numbers(int a, int b, int c);
    

    class Program
    {
        private static int Sum(int x, int y, int z)
        {
            return x + y + z;
        }

        static void ReceiveMessage1(string message)
        {
            Console.WriteLine($"1> {message}");
        }

        static void ReceiveMessage2(string message)
        {
            Console.WriteLine($"2> {message}");
        }

        static void Main(string[] args)
        {
            MessageBroadcast broadcaster, msg1, msg2;
            msg1 = ReceiveMessage1;
            msg2 = ReceiveMessage2;
            broadcaster = msg1 + msg2;

            // "attach" multiple functions
            // broadcaster += ReceiveMessage2;
            // broadcaster += ReceiveMessage1;


            broadcaster.Invoke("Test message!");

            
        }

        private static void DefineAndInitializeDelegates()
        {
            // Ex1: init delegate with a static function
            // Sum3Numbers sumFunc = Sum;

            // Ex2: init delegate with an instance function
            // MathHelper helper = new MathHelper();
            // Sum3Numbers sumFunc = helper.Sum;

            // Ex3: init delegate with an anonimous function
            Sum3Numbers sumFunc = delegate (int x, int y, int z)
            {
                return x + y + z;
            };

            int result = sumFunc.Invoke(10, 20, 30);

            Console.WriteLine(result);
        }

        private static void DoSomething(MessageBroadcast broadcaster)
        {
            Console.WriteLine("Doing something special here...");
            if (!(broadcaster is null))
            {
                broadcaster.Invoke("Test");
            }
        }
    }
}
