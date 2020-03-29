using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DataConfiguration.DAL
{
    public class DataConfigurationContext : DbContext
    {
        public DataConfigurationContext([NotNull] DbContextOptions options)
            : base(options)
        {

        }
    }
}
