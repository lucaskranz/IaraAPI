using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IaraAPI.Models;

namespace IaraAPI.Data
{
    public class IaraAPIContext : DbContext
    {
        public IaraAPIContext (DbContextOptions<IaraAPIContext> options)
            : base(options)
        {
        }

        public DbSet<IaraAPI.Models.CotacaoItem> CotacaoItem { get; set; }
    }
}
