
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Orcamento.API.Models;

namespace Orcamento.API.Context
{
    public class AppDbContext : IdentityDbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {}
     public DbSet<Cliente> Clientes {get; set;}

     public DbSet<Item> items{ get; set;}

     public DbSet <ListaItem> listaItems {get; set;}

     public DbSet <Tborcamento> tborcamentos {get; set;}


    }
}