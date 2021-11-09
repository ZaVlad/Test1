using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IDbContext 
    {
        public DbSet<Person> Person { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
