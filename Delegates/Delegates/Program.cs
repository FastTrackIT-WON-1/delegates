using System;
using System.Collections.Generic;

namespace Delegates
{
    public delegate int Sum3Numbers(int a, int b, int c);

    class Program
    {
        static string text = "Test";

        private static int Sum(int x, int y, int z)
            => x + y + z;

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
            List<Action> listOfActions = new List<Action>();
            for (int i = 0; i < 3; i++)
            {
                int temp = i;
                listOfActions.Add(() => Console.WriteLine(temp));
            }

            foreach (Action a in listOfActions)
            {
                a();
            }
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

        private static void MulticastDelegatesExample()
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

        private static void DoSomething(MessageBroadcast broadcaster)
        {
            Console.WriteLine("Doing something special here...");
            if (!(broadcaster is null))
            {
                broadcaster.Invoke("Test");
            }
        }

        private static void EventsExample()
        {
            MessagePublisher publisher = new MessagePublisher();
            publisher.OnMessageReceived += ReceiveMessage1;
            publisher.OnMessageReceived += ReceiveMessage2;

            publisher.SendMessage("Test");
        }

        private static void LambdaExample1()
        {
            Sum3Numbers sumFunc = (x, y, z) => x + y + z;

            int result = sumFunc.Invoke(10, 20, 30);

            Console.WriteLine(result);
        }
    }
}
