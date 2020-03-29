using DataConfiguration.Business.Engines.Interfaces;
using DataConfiguration.Business.Services;
using DataConfiuguration.Parser;
using System;
using System.Linq;

namespace DataConfiguration.Business.Engines
{
    public class ActionDataEngine : IActionDataEngine
    {
        private readonly JsonParser jsonParser;
        private readonly IRestClientService restClientService;

        public ActionDataEngine(JsonParser jsonParser,
            IRestClientService restClientService)
        {
            this.jsonParser = jsonParser;
            this.restClientService = restClientService;
        }

        public void ExecuteAction(string actionName)
        {
            try
            {
                var actions = jsonParser.Configuration.actions;

                if (actions?.Any() == false)
                    throw new Exception("No action found!");

                var action = actions.FirstOrDefault(x => string.CompareOrdinal(x.name, actionName) == 0);

                if (action == null) return;

                foreach (var step in action.steps)
                {
                    switch (step.name)
                    {
                        case "Invoke Azure Function":
                        case "Makes REST API request":

                            var httpStep = action.http.FirstOrDefault(x => x.step.Equals(step.stepNumber));

                            if (httpStep == null)
                                throw new Exception($"no matching step found  for step id : {step.stepNumber}");

                            restClientService.Execute(new Uri(httpStep.url), httpStep.method)
                                .GetAwaiter()
                                .GetResult();
                            break;

                        case "Excecute Stored Procedure":
                            var azureSqlSetp = action.azureSql.FirstOrDefault(x => x.step.Equals(step.stepNumber));

                            if (azureSqlSetp == null)
                                throw new Exception($"no matching step found  for step id : {step.stepNumber}");
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
