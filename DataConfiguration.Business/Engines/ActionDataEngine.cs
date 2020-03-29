using DataConfiguration.Business.Engines.Interfaces;
using DataConfiuguration.Parser;

namespace DataConfiguration.Business.Engines
{
    public class ActionDataEngine : IActionDataEngine
    {
        private readonly JsonParser jsonParser;

        public ActionDataEngine(JsonParser jsonParser)
        {
            this.jsonParser = jsonParser;
        }

        public bool ExecuteActions()
        {
            return true;
        }
    }
}
