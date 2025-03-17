namespace pact.Configs.CmdArg
{
    public class DeleteArg
    {
        public string Path 
        { 
            get 
            {
                return "-path" ?? "-p";
            }
        }
        public string Permanent 
        {
            get
            {
                return "-permanent" ?? "pm";
            }
        }
    }
}