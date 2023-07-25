﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sender.InfraData.Context;

#nullable disable

namespace Sender.InfraData.Migrations
{
    [DbContext(typeof(SenderApplicationDbContext))]
    [Migration("20230720115424_InitialSender")]
    partial class InitialSender
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sender.Domain.Entities.SenderConfigDomain", b =>
                {
                    b.Property<int>("Sender_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Sender_id"));

                    b.Property<string>("Sender_password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Sender_port")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("Sender_smtp")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Sender_user")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Sender_id");

                    b.ToTable("SenderConfigDomain");

                    b.HasData(
                        new
                        {
                            Sender_id = 1,
                            Sender_password = "We@172839",
                            Sender_port = "587",
                            Sender_smtp = "smtp.futurasistemas.com.br",
                            Sender_user = "welington.campos@futurasistemas.com.br"
                        });
                });

            modelBuilder.Entity("Sender.Domain.Entities.SenderMailDomain", b =>
                {
                    b.Property<int>("Sender_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Sender_id"));

                    b.Property<string>("Sender_email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Sender_message")
                        .IsRequired()
                        .HasMaxLength(999)
                        .HasColumnType("character varying(999)");

                    b.Property<string>("Sender_title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("senderConfigDomainSender_id")
                        .HasColumnType("integer");

                    b.HasKey("Sender_id");

                    b.HasIndex("senderConfigDomainSender_id");

                    b.ToTable("SenderMailDomain");
                });

            modelBuilder.Entity("Sender.Domain.Entities.SenderMailDomain", b =>
                {
                    b.HasOne("Sender.Domain.Entities.SenderConfigDomain", "senderConfigDomain")
                        .WithMany()
                        .HasForeignKey("senderConfigDomainSender_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("senderConfigDomain");
                });
#pragma warning restore 612, 618
        }
    }
}