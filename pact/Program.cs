namespace pact
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Test pact");
            if (args.Length == 0)
            {
                return;
            }

            var argsMap = Utils.Utils.ParseOptions(args);
            argsMap["action"] = args[0];
            Utils.Utils.Print(argsMap);
        }
    }
}