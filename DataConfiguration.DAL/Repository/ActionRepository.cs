using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DataConfiguration.DAL.Repository
{
    public class ActionRepository : IActionRepository{


        public async Task ExecuteSp(DbContext context, string name, params object[] inputParams)
        {
            if (context == null) throw new Exception("DataConfigurationContext Null");

            await context.Database.OpenConnectionAsync();
            await context.Database.ExecuteSqlRawAsync($"EXEC {name}");

        }
    }
}
