using pact.Services;

namespace pact
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            var argsMap = Utils.Utils.ParseOptions(args);
            argsMap["action"] = args[0];
            var startUp = new StartUp();
            await startUp.Start(argsMap);
        }
    }

    public class StartUp
    {
        private readonly ActionServices _actionServices;

        public StartUp()
        {
            _actionServices = new ActionServices();
        }

        public async Task Start(Dictionary<string, object> args)
        {
            await _actionServices.Start(args);
        }
    }
}