﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Alura.Loja.Testes.ConsoleApp;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    [DbContext(typeof(LojaContext))]
    [Migration("20190619184919_Promocao")]
    partial class Promocao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Preco");

                    b.Property<int>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Categoria");

                    b.Property<string>("Nome");

                    b.Property<double>("PrecoUnitario");

                    b.Property<string>("Unidade");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Promocao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataFim");

                    b.Property<DateTime>("DataInicio");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("promocoes");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.PromocaoProduto", b =>
                {
                    b.Property<int>("PromocaoId");

                    b.Property<int>("ProdutoId");

                    b.HasKey("PromocaoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PromocaoProduto");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Compra", b =>
                {
                    b.HasOne("Alura.Loja.Testes.ConsoleApp.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.PromocaoProduto", b =>
                {
                    b.HasOne("Alura.Loja.Testes.ConsoleApp.Produto", "Produto")
                        .WithMany("Promocao")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Alura.Loja.Testes.ConsoleApp.Promocao", "Promocao")
                        .WithMany("Produto")
                        .HasForeignKey("PromocaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
