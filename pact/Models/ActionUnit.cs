using pact.Configs;

namespace pact.Models
{
    public class ActionUnit
    {
        public Guid ID { get; set; }
        public int NumericID { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public Func<Dictionary<string, ActionArgDef>, object> PerformAction { get; set; }
        public Dictionary<string, ActionArgDef> ActionArgs { get; set; }
        
    }
    public class ActionArgDef
    {
        public string Name { get; set; }
        public object Type { get; set; }
        public string Description { get; set; }
        public object Value { get; set; }
        public bool IsRequired { get; set; }
        public string Set { get; set; }
    }
}