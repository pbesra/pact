using pact.Configs;

namespace pact.Utils
{
    public class Utils
    {
        public static Dictionary<string, object> ParseOptions(string[] args)
        {
            var options = new Dictionary<string, object>();
            for (int i = 1; i < args.Length; i++)
            {
                if (args[i].StartsWith("-"))
                {
                    options[args[i]] = validArgValue(args, i+1);
                }
            }
            object validArgValue(string[] args, int index)
            {
                if (index>=args.Length)
                {
                    return true;
                }
                var val=args[index];
                object argVal = val.StartsWith("-") ? true : val;
                return argVal;
            }
            return options;
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