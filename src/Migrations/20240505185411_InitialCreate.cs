using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    published_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    publisher = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.book_id);
                });

            migrationBuilder.CreateTable(
                name: "price_offers",
                columns: table => new
                {
                    price_offer_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    new_price = table.Column<decimal>(type: "numeric", nullable: false),
                    promotional_text = table.Column<string>(type: "text", nullable: false),
                    book_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_price_offers", x => x.price_offer_id);
                    table.ForeignKey(
                        name: "FK_price_offers_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "booklazys",
                columns: table => new
                {
                    booklazy_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    published_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    publisher = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    PromotionPriceOfferId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booklazys", x => x.booklazy_id);
                    table.ForeignKey(
                        name: "FK_booklazys_price_offers_PromotionPriceOfferId",
                        column: x => x.PromotionPriceOfferId,
                        principalTable: "price_offers",
                        principalColumn: "price_offer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_authors",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "integer", nullable: false),
                    author_id = table.Column<int>(type: "integer", nullable: false),
                    order_num = table.Column<byte>(type: "smallint", nullable: false),
                    BookLazyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_authors", x => new { x.book_id, x.author_id });
                    table.ForeignKey(
                        name: "FK_book_authors_authors_author_id",
                        column: x => x.author_id,
                        principalTable: "authors",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_authors_booklazys_BookLazyId",
                        column: x => x.BookLazyId,
                        principalTable: "booklazys",
                        principalColumn: "booklazy_id");
                    table.ForeignKey(
                        name: "FK_book_authors_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    voter_name = table.Column<string>(type: "text", nullable: false),
                    num_stars = table.Column<int>(type: "integer", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: false),
                    book_id = table.Column<int>(type: "integer", nullable: false),
                    BookLazyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_reviews_booklazys_BookLazyId",
                        column: x => x.BookLazyId,
                        principalTable: "booklazys",
                        principalColumn: "booklazy_id");
                    table.ForeignKey(
                        name: "FK_reviews_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    tag_id = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    BookLazyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.tag_id);
                    table.ForeignKey(
                        name: "FK_tags_booklazys_BookLazyId",
                        column: x => x.BookLazyId,
                        principalTable: "booklazys",
                        principalColumn: "booklazy_id");
                });

            migrationBuilder.CreateTable(
                name: "BookTag",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "integer", nullable: false),
                    TagsTagId = table.Column<string>(type: "character varying(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTag", x => new { x.BooksBookId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_BookTag_books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "books",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTag_tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "tags",
                        principalColumn: "tag_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTag_TagsTagId",
                table: "BookTag",
                column: "TagsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_book_authors_BookLazyId",
                table: "book_authors",
                column: "BookLazyId");

            migrationBuilder.CreateIndex(
                name: "IX_book_authors_author_id",
                table: "book_authors",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_booklazys_PromotionPriceOfferId",
                table: "booklazys",
                column: "PromotionPriceOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_price_offers_book_id",
                table: "price_offers",
                column: "book_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_BookLazyId",
                table: "reviews",
                column: "BookLazyId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_book_id",
                table: "reviews",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_tags_BookLazyId",
                table: "tags",
                column: "BookLazyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTag");

            migrationBuilder.DropTable(
                name: "book_authors");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "booklazys");

            migrationBuilder.DropTable(
                name: "price_offers");

            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
