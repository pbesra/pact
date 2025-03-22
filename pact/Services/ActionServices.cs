using pact.Configs;
using pact.Models;
using Constant = pact.Constants.Constants;

namespace pact.Services
{
    public class ActionServices
    {
        public async Task Start(Dictionary<string, object> args)
        {
            var action = args["action"].ToString();
            var actionUnit = ActionConfigs.ActionUnits.FirstOrDefault(x => x.Code.Equals(action, StringComparison.OrdinalIgnoreCase));
            if (actionUnit != null)
            {
                var actionArgs = await SendCommand(args);
                actionUnit.PerformAction(actionArgs);
            }
        }

        public async Task<Dictionary<string, ActionArgDef>> SendCommand(Dictionary<string, object> args)
        {
            var argResult=new Dictionary<string, ActionArgDef>();
            var action = args["action"].ToString();
            var actionArgs = ActionConfigs.ActionUnits
                .FirstOrDefault(x => x.Code.Equals(action, StringComparison.OrdinalIgnoreCase))
                ?.ActionArgs;

            // this should be part of validation.
            var isValidArg = args?.Keys.FirstOrDefault(x => x != "action" && !actionArgs.ContainsKey(x));
            if (isValidArg != null)
            {
                Console.WriteLine("Wrong command entered");
                Environment.Exit(1);
            }
            foreach (var inputArgKey in args)
            {
                if (inputArgKey.Key == Constant.ACTION)
                {
                    continue;
                }
                argResult[inputArgKey.Key] = new ActionArgDef { Value = inputArgKey.Value };
            }
            return argResult;
        }
    }
}