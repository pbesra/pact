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
        public Func<Dictionary<string, string>, object> PerformAction { get; set; }
    }
}