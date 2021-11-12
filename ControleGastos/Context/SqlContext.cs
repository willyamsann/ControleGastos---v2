using ControleGastos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace ControleGastos.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() : base("ControleFinanceiro")
        {
        }

        public DbSet<Gasto> Gastos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
