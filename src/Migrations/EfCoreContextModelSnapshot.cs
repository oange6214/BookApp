﻿// <auto-generated />
using System;
using BookApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookApp.Migrations
{
    [DbContext(typeof(EfCoreContext))]
    partial class EfCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookApp.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("AuthorId");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("BookApp.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("published_on");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("publisher");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("BookId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("BookApp.Models.BookAuthor", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    b.Property<int?>("BookLazyId")
                        .HasColumnType("integer");

                    b.Property<byte>("Order")
                        .HasColumnType("smallint")
                        .HasColumnName("order_num");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookLazyId");

                    b.ToTable("book_authors");
                });

            modelBuilder.Entity("BookApp.Models.BookLazy", b =>
                {
                    b.Property<int>("BookLazyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("booklazy_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookLazyId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<int>("PromotionPriceOfferId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("published_on");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("publisher");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("BookLazyId");

                    b.HasIndex("PromotionPriceOfferId");

                    b.ToTable("booklazys");
                });

            modelBuilder.Entity("BookApp.Models.PriceOffer", b =>
                {
                    b.Property<int>("PriceOfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("price_offer_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PriceOfferId"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<decimal>("NewPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("new_price");

                    b.Property<string>("PromotionalText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("promotional_text");

                    b.HasKey("PriceOfferId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("price_offers");
                });

            modelBuilder.Entity("BookApp.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("review_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReviewId"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<int?>("BookLazyId")
                        .HasColumnType("integer");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<int>("NumStars")
                        .HasColumnType("integer")
                        .HasColumnName("num_stars");

                    b.Property<string>("VoterName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("voter_name");

                    b.HasKey("ReviewId");

                    b.HasIndex("BookId");

                    b.HasIndex("BookLazyId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("BookApp.Models.Tag", b =>
                {
                    b.Property<string>("TagId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("tag_id");

                    b.Property<int?>("BookLazyId")
                        .HasColumnType("integer");

                    b.HasKey("TagId");

                    b.HasIndex("BookLazyId");

                    b.ToTable("tags");
                });

            modelBuilder.Entity("BookTag", b =>
                {
                    b.Property<int>("BooksBookId")
                        .HasColumnType("integer");

                    b.Property<string>("TagsTagId")
                        .HasColumnType("character varying(40)");

                    b.HasKey("BooksBookId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("BookTag");
                });

            modelBuilder.Entity("BookApp.Models.BookAuthor", b =>
                {
                    b.HasOne("BookApp.Models.Author", "Author")
                        .WithMany("BooksLink")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookApp.Models.Book", "Book")
                        .WithMany("AuthorsLink")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookApp.Models.BookLazy", null)
                        .WithMany("AuthorsLink")
                        .HasForeignKey("BookLazyId");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookApp.Models.BookLazy", b =>
                {
                    b.HasOne("BookApp.Models.PriceOffer", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionPriceOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("BookApp.Models.PriceOffer", b =>
                {
                    b.HasOne("BookApp.Models.Book", null)
                        .WithOne("Promotion")
                        .HasForeignKey("BookApp.Models.PriceOffer", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookApp.Models.Review", b =>
                {
                    b.HasOne("BookApp.Models.Book", null)
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookApp.Models.BookLazy", null)
                        .WithMany("Reviews")
                        .HasForeignKey("BookLazyId");
                });

            modelBuilder.Entity("BookApp.Models.Tag", b =>
                {
                    b.HasOne("BookApp.Models.BookLazy", null)
                        .WithMany("Tags")
                        .HasForeignKey("BookLazyId");
                });

            modelBuilder.Entity("BookTag", b =>
                {
                    b.HasOne("BookApp.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookApp.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookApp.Models.Author", b =>
                {
                    b.Navigation("BooksLink");
                });

            modelBuilder.Entity("BookApp.Models.Book", b =>
                {
                    b.Navigation("AuthorsLink");

                    b.Navigation("Promotion")
                        .IsRequired();

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BookApp.Models.BookLazy", b =>
                {
                    b.Navigation("AuthorsLink");

                    b.Navigation("Reviews");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}