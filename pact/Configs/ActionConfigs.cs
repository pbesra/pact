using pact.Models;
using pact.Services;

namespace pact.Configs
{
    public class ActionConfigs
    {
        public static List<ActionUnit> ActionUnits = new List<ActionUnit>
        {
            new ActionUnit
            {
                NumericID=1,
                Description="Delete resource",
                Code="Delete",
                PerformAction = (args)=>
                {
                    var fileServices=new FileSystemActionServices();
                    return fileServices.PerformDelete(args);
                }
            }
        };
    }
}