namespace Version2.Writer
{
    internal class Write
    {
        private static string LastMessage { get; set; }
        private static string Time => DateTime.Now.ToShortTimeString();

        public static void Error(string Message, bool UseTimestamp = true, bool CheckLast = true)
        {
            try
            {
                var old = Console.ForegroundColor;
                if (CheckLast && Message == LastMessage) return;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(UseTimestamp? $"[{Time}] {Message}" : Message);

                Console.ForegroundColor = old;
                LastMessage = Message;
            }
            catch (Exception)
            {
                // 
            }
        }
        public static void Warning(string Message, bool UseTimestamp = true, bool CheckLast = true)
        {
            try
            {
                var old = Console.ForegroundColor;
                if (CheckLast && Message == LastMessage) return;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(UseTimestamp ? $"[{Time}] {Message}" : Message);

                Console.ForegroundColor = old;
                LastMessage = Message;
            }
            catch (Exception)
            {
                // 
            }
        }

        public static void General(string Message, bool UseTimestamp = true, bool CheckLast = true)
        {
            try
            {
                var old = Console.ForegroundColor;
                if (CheckLast && Message == LastMessage) return;

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(UseTimestamp ? $"[{Time}] {Message}" : Message);

                Console.ForegroundColor = old;
                LastMessage = Message;
            }
            catch (Exception)
            {
                // 
            }
        }
        public static void Message(string Message, bool UseTimestamp = true, bool CheckLast = true)
        {
            try
            {
                var old = Console.ForegroundColor;
                if (CheckLast && Message == LastMessage) return;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(UseTimestamp ? $"[{Time}] {Message}" : Message);

                Console.ForegroundColor = old;
                LastMessage = Message;
            }
            catch (Exception)
            {
                // 
            }
        }
        public static void Success(string Message, bool UseTimestamp = true, bool CheckLast = true)
        {
            try
            {
                var old = Console.ForegroundColor;
                if (CheckLast && Message == LastMessage) return;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(UseTimestamp ? $"[{Time}] {Message}" : Message);

                Console.ForegroundColor = old;
                LastMessage = Message;
            }
            catch (Exception)
            {
                // 
            }
        }

        
    }
}
