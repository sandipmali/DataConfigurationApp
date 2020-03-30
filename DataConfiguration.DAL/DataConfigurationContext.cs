using Microsoft.EntityFrameworkCore;

namespace DataConfiguration.DAL
{
    public class DataConfigurationContext : DbContext
    {
        public DataConfigurationContext(string connectionString) :
            base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
        }
    }
}
