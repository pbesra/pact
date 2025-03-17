using pact.Configs;

namespace pact.Utils
{
    public class Utils
    {
        public static Dictionary<string, string> ParseOptions(string[] args)
        {
            var options = new Dictionary<string, string>();
            for (int i = 1; i < args.Length; i += 2)
            {
                if (args[i].StartsWith("-"))
                {
                    options[args[i]] = args[i + 1];
                }
            }
            return options;
        }
        public static void Print(Dictionary<string, string> args)
        {
            foreach (var arg in args) 
            { 
                Console.WriteLine($"{arg.Key} = {arg.Value}");
            }
        }
        public static IResource GetResourceType(ResourceType resource)
        {
            if (Directory.Exists(resource.Path))
            {
                return new DirResourceImpl();
            }
            return new FileResourceImpl();
        }
    }
}