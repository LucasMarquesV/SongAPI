using Microsoft.EntityFrameworkCore;
using Model.Musica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Config
{
    public class ContextBase : DbContext

    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConnectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<SongViewModel> SongViewModels { get; set; }

        private string GetStringConnectionConfig()
        {
            string strCon = "Server=CTS1A519661\\SQLEXPRESS;Database=DB_Song; Integrated Security=True;TrustServerCertificate=True";
            return strCon;
        }
    }
}
