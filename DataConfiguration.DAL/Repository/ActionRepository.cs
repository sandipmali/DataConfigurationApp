using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataConfiguration.DAL.Repository
{
    public class ActionRepository : IActionRepository
    {
        private readonly DataConfigurationContext dataConfigurationContext;

        public ActionRepository(DataConfigurationContext dataConfigurationContext)
        {
            this.dataConfigurationContext = dataConfigurationContext;
        }

        public async void ExecuteSp(string connectionString, string name, params object[] inputParams)
        {

            await dataConfigurationContext.Database.OpenConnectionAsync();
            await dataConfigurationContext.Database.ExecuteSqlRawAsync($"EXEC {name}");

        }
    }
}
