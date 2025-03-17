
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

            var actionUnit = args[0];
            var argsMap = Utils.Utils.ParseOptions(args);
            Console.WriteLine($"actionUnit={actionUnit}");
            Utils.Utils.Print(argsMap);
        }
    }
}