using pact.Models;

namespace pact.Services
{
    public interface IBaseActionServices
    {
        public Task StartAction(Dictionary<string, ActionArgDef> actionArgs);
    }
}