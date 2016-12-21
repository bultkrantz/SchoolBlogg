using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BloggInlämning.Models;

namespace BloggInlämning.Migrations
{
    [DbContext(typeof(BloggContext))]
    [Migration("20161220093827_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BloggInlämning.Models.BloggPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BloggDate");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Heading")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<string>("Image");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("BloggPosts");
                });

            modelBuilder.Entity("BloggInlämning.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BloggInlämning.Models.BloggPost", b =>
                {
                    b.HasOne("BloggInlämning.Models.Category", "Category")
                        .WithMany("BloggPosts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
