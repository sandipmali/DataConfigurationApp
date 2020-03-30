using DataConfiguration.Business.Engines.Interfaces;
using DataConfiguration.Business.Services;
using DataConfiguration.DAL;
using DataConfiguration.DAL.Repository;
using DataConfiuguration.Parser;
using System;
using System.Linq;

namespace DataConfiguration.Business.Engines
{
    public class ActionDataEngine : IActionDataEngine
    {
        private readonly JsonParser _jsonParser;
        private readonly IRestClientService _restClientService;
        private readonly IActionRepository _actionRepository;

        public ActionDataEngine(JsonParser jsonParser,
            IRestClientService restClientService, IActionRepository actionRepository)
        {
            this._jsonParser = jsonParser;
            this._restClientService = restClientService;
            _actionRepository = actionRepository;
        }

        public void ExecuteAction(string actionName)
        {
            var actions = _jsonParser.Configuration.actions;

            if (actions?.Any() == false)
                throw new Exception("No action found!");

            if (actions != null)
            {
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

                            _restClientService.Execute(new Uri(httpStep.url), httpStep.method)
                                .GetAwaiter()
                                .GetResult();
                            break;

                        case "Excecute Stored Procedure":
                            var azureSqlSetp = action.azureSql.FirstOrDefault(x => x.step.Equals(step.stepNumber));

                            if (azureSqlSetp == null)
                                throw new Exception($"no matching step found  for step id : {step.stepNumber}");

                            var dbContext = new DataConfigurationContext(azureSqlSetp.connectionString);

                            _actionRepository.ExecuteSp(dbContext, azureSqlSetp.commandText, azureSqlSetp.type)
                                .GetAwaiter()
                                .GetResult();
                            break;
                    }
                }
            }
        }
    }
}
