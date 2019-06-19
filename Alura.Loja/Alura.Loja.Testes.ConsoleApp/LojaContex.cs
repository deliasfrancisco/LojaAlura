using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{

    public class LojaContext : DbContext //1º Criação do contexto e permite fazer uso da API do Entity herdando de DbContext()
    {
        public DbSet<Produto> Produtos { get; set; }// 2º Criação da propriedade para a persistencia da classe Produto
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Promocao> promocoes { get; set; }

        public LojaContext()
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PromocaoProduto>()
                .HasKey(pp => new {pp.PromocaoId, pp.ProdutoId}); //aqui esta dizendo paras o construtor de modelo que para a entidade promocaoProduto tem como chave a composiçãodas duas chaves, produtoId e PromocaoId
            base.OnModelCreating(modelBuilder);
        }

        public LojaContext(DbContextOptions<LojaContext> options) : base (options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
        }
    }
}
