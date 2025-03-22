using pact.Configs;

namespace pact.Services
{
    public class ActionHelperServices
    {
        public async Task ShowActions()
        {
            var actionDefs = ActionConfigs.ActionUnits;
            var maxLength = actionDefs.Select(x => x.Code).OrderBy(x => x.Length).LastOrDefault().Length;
            var emptyStr = new string(' ', maxLength);
            Console.WriteLine("----- All commands -----");
            foreach (var actionDef in actionDefs)
            {
                var argPrefixLength = new string(' ', $"{actionDef.Code}{GetEmptyStr(actionDef.Code)} ".Length+2);
                Console.WriteLine($"{actionDef.Code}{GetEmptyStr(actionDef.Code)} : {actionDef.Description}");
                var argsDef = await ShowAction(actionDef.Code);
                foreach (var arg in argsDef)
                {
                    Console.WriteLine($"{argPrefixLength}{arg}");
                }
            }
            string GetEmptyStr(string currentStr)
            {
                return new string(' ', maxLength - currentStr.Length);
            }
        }

        public async Task<List<string>> ShowAction(string actionCode)
        {
            var actionDef = ActionConfigs.ActionUnits.FirstOrDefault(x => x.Code == actionCode);
            var actionArgs = actionDef.ActionArgs;
            var maxLength = actionDef.ActionArgs.Keys.OrderBy(x => x.Length).LastOrDefault().Length;
            var argsDefList = new List<string>();
            foreach (var actionArg in actionArgs)
            {
                var argDef = $"{actionArg.Key}{GetEmptyStr(actionArg.Key)} : {actionArg.Value.Description}";
                argsDefList.Add(argDef);
            }

            string GetEmptyStr(string currentStr)
            {
                return new string(' ', maxLength - currentStr.Length);
            }
            return argsDefList;
        }
    }
}