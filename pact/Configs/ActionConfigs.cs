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
                Description="Delete file or directory",
                Code="delete",
                PerformAction = async (args)=>
                {
                    var fileServices=new FileSystemActionServices();
                    return await fileServices.PerformDelete(args);
                },
                ActionArgs=new Dictionary<string, ActionArgDef>
                {
                    {"-path", new ActionArgDef{ Name="path", Value=null, Type=TypeCode.String, Set="path", Description="File or directory path." } },
                    {"-p", new ActionArgDef{ Name="path", Value=null, Type=TypeCode.String, Set="path", Description = "File or directory path." } },
                    {"-pm", new ActionArgDef{ Name="permanent", Value=null, Type=TypeCode.Boolean, Description="Delete permanent. Use -pm to delete permanently." } },
                }
            },
            new ActionUnit
            {
                NumericID=2,
                Description="Show actions",
                Code="show",
                PerformAction = async (args)=>
                {
                    var fileServices=new ActionHelperServices();
                    await fileServices.ShowActions();
                    return true;
                },
                ActionArgs=new Dictionary<string, ActionArgDef>
                {
                    {"-t", new ActionArgDef{ Name="path", Value=null, Type=TypeCode.String, Set="path", Description="This is test" } },
                }
            },
            new ActionUnit
            {
                NumericID=2,
                Description="Show actions",
                Code="help",
                PerformAction = async (args)=>
                {
                    var fileServices=new ActionHelperServices();
                    await fileServices.ShowActions();
                    return true;
                },
                ActionArgs=new Dictionary<string, ActionArgDef>
                {
                    {"-t", new ActionArgDef{ Name="path", Value=null, Type=TypeCode.String, Set="path", Description="This is test" } },
                }
            }
        };
    }
}