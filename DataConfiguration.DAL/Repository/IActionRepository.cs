using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataConfiguration.DAL.Repository
{
    public interface IActionRepository
    {
        Task ExecuteSp(DbContext context, string name, params object[] inputParams);
    }
}
