using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataConfiguration.Business.Services
{
    public interface IRestClientService
    {
        Task Execute(Uri endpoindUrl, string method, string data = null);
    }
}
