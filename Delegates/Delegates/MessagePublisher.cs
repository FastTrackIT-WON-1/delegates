namespace Delegates
{
    public class MessagePublisher
    {
        private event MessageBroadcast handlers;

        public event MessageBroadcast OnMessageReceived
        {
            add { handlers += value; }
            remove { handlers -= value; }
        }

        public void SendMessage(string message)
        {
            handlers?.Invoke(message);
        }
    }
}
