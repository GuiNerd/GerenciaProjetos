﻿// <auto-generated />
using System;
using GerenciaProjetos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GerenciaProjetos.Migrations
{
    [DbContext(typeof(GerenciaContext))]
    partial class GerenciaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GerenciaProjetos.Models.Bug", b =>
                {
                    b.Property<int>("DesenvolvedorId");

                    b.Property<int>("RequisitoId");

                    b.Property<int>("CriadorId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<bool>("FoiResolvido");

                    b.Property<string>("Prioridade");

                    b.HasKey("DesenvolvedorId", "RequisitoId");

                    b.HasIndex("CriadorId");

                    b.HasIndex("RequisitoId");

                    b.ToTable("Bugs");
                });

            modelBuilder.Entity("GerenciaProjetos.Models.Desenvolvedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("EAdmin");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.ToTable("Desenvolvedores");
                });

            modelBuilder.Entity("GerenciaProjetos.Models.DesenvolvedorProjeto", b =>
                {
                    b.Property<int>("DesenvolvedorId");

                    b.Property<int>("ProjetoId");

                    b.HasKey("DesenvolvedorId", "ProjetoId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("DesenvolvedorProjeto");
                });

            modelBuilder.Entity("GerenciaProjetos.Models.DesenvolvedorRequisito", b =>
                {
                    b.Property<int>("DesenvolvedorId");

                    b.Property<int>("RequisitoId");

                    b.Property<TimeSpan>("TempoGasto");

                    b.HasKey("DesenvolvedorId", "RequisitoId");

                    b.HasIndex("RequisitoId");

                    b.ToTable("DesenvolvedorRequisito");
                });

            modelBuilder.Entity("GerenciaProjetos.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataEntrega");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Solicitante")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("GerenciaProjetos.Models.Requisito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataEntrega");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("EFuncional");

                    b.Property<string>("Observacoes")
                        .HasMaxLength(100);

                    b.Property<int>("ProjetoId");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Requisitos");
                });

            modelBuilder.Entity("GerenciaProjetos.Models.Bug", b =>
                {
                    b.HasOne("GerenciaProjetos.Models.Desenvolvedor", "Criador")
                        .WithMany()
                        .HasForeignKey("CriadorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GerenciaProjetos.Models.Desenvolvedor", "Desenvolvedor")
                        .WithMany()
                        .HasForeignKey("DesenvolvedorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GerenciaProjetos.Models.Requisito", "Requisito")
                        .WithMany()
                        .HasForeignKey("RequisitoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GerenciaProjetos.Models.DesenvolvedorProjeto", b =>
                {
                    b.HasOne("GerenciaProjetos.Models.Desenvolvedor", "Desenvolvedor")
                        .WithMany()
                        .HasForeignKey("DesenvolvedorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GerenciaProjetos.Models.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GerenciaProjetos.Models.DesenvolvedorRequisito", b =>
                {
                    b.HasOne("GerenciaProjetos.Models.Desenvolvedor", "Desenvolvedor")
                        .WithMany()
                        .HasForeignKey("DesenvolvedorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GerenciaProjetos.Models.Requisito", "Requisito")
                        .WithMany()
                        .HasForeignKey("RequisitoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GerenciaProjetos.Models.Requisito", b =>
                {
                    b.HasOne("GerenciaProjetos.Models.Projeto", "Projeto")
                        .WithMany("Requisitos")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}