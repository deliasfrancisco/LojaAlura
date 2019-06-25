using CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) //quando for criado o modelo ele vai acessa esse metodo para fazer o mapeamento
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Produto>().HasKey(k => k.Id); //vai registrar uma classe do modelo para o entity fazer uso e criar as tabelas e atributos do banco de dados

			modelBuilder.Entity<Pedido>().HasKey(k => k.Id); //representa a chave primaria que sera gerada pelo entity framework
			modelBuilder.Entity<Pedido>().HasMany(k => k.Itens).WithOne(e => e.Pedido); //indica que a entidade é de muitoa para muitos
			modelBuilder.Entity<Pedido>().HasOne(k => k.Cadastro).WithOne(e => e.Pedido).IsRequired();  //relacionamento de um para um
			//WithOne() - Indica o relacionamento de volta, ou seja, cada item de pedido se relaciona a um pedido individual

			modelBuilder.Entity<ItemPedido>().HasKey(k => k.Id);
			modelBuilder.Entity<ItemPedido>().HasOne(k => k.Pedido);
			modelBuilder.Entity<ItemPedido>().HasOne(k => k.Produto);

			modelBuilder.Entity<Cadastro>().HasKey(k => k.Id);
			modelBuilder.Entity<Cadastro>().HasOne(k => k.Pedido);

		}
	}
}
