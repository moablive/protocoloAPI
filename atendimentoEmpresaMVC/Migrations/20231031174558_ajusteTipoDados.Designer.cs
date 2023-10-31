﻿// <auto-generated />
using System;
using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace atendimentoEmpresaMVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231031174558_ajusteTipoDados")]
    partial class ajusteTipoDados
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PessoaFisicaID")
                        .HasColumnType("int");

                    b.Property<int>("PessoaJuridicaID")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("EnderecoID");

                    b.HasIndex("PessoaFisicaID");

                    b.HasIndex("PessoaJuridicaID");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Models.PessoaFisica", b =>
                {
                    b.Property<int>("PessoaFisicaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DatadeNasc")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("PessoaFisicaID");

                    b.ToTable("PessoasFisicas");
                });

            modelBuilder.Entity("Models.PessoaJuridica", b =>
                {
                    b.Property<int>("PessoaJuridicaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("PessoaJuridicaID");

                    b.ToTable("PessoasJuridicas");
                });

            modelBuilder.Entity("Protocolo", b =>
                {
                    b.Property<int>("ProtocoloID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PessoaFisicaID")
                        .HasColumnType("int");

                    b.Property<int>("PessoaJuridicaID")
                        .HasColumnType("int");

                    b.HasKey("ProtocoloID");

                    b.HasIndex("PessoaFisicaID");

                    b.HasIndex("PessoaJuridicaID");

                    b.ToTable("Protocolos");
                });

            modelBuilder.Entity("Models.Endereco", b =>
                {
                    b.HasOne("Models.PessoaFisica", "PessoaFisica")
                        .WithMany("Enderecos")
                        .HasForeignKey("PessoaFisicaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.PessoaJuridica", "PessoaJuridica")
                        .WithMany("Enderecos")
                        .HasForeignKey("PessoaJuridicaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PessoaFisica");

                    b.Navigation("PessoaJuridica");
                });

            modelBuilder.Entity("Protocolo", b =>
                {
                    b.HasOne("Models.PessoaFisica", "PessoaFisica")
                        .WithMany()
                        .HasForeignKey("PessoaFisicaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.PessoaJuridica", "PessoaJuridica")
                        .WithMany()
                        .HasForeignKey("PessoaJuridicaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PessoaFisica");

                    b.Navigation("PessoaJuridica");
                });

            modelBuilder.Entity("Models.PessoaFisica", b =>
                {
                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("Models.PessoaJuridica", b =>
                {
                    b.Navigation("Enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
