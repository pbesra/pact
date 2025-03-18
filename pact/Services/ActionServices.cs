using pact.Configs;

namespace pact.Services
{
    public class ActionServices
    {
        public void Start(Dictionary<string, string> args)
        {
            var action = args["action"];
            var actionUnit = ActionConfigs.ActionUnits.FirstOrDefault(x => x.Code.Equals(action, StringComparison.OrdinalIgnoreCase));
            if (actionUnit != null)
            {
                actionUnit.PerformAction(args);
            }
        }
    }
}