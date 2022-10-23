using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupB_A2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });
            //Insert Initial Data
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Grocery"},
                    { 2, "Technology"},
                    { 3, "Clothes" },
                    { 4, "Beauty" }
                });
            
            
            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryID = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberPhone = table.Column<string>(type: "TEXT", nullable: false),
                    Website = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Business_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_CategoryID",
                table: "Business",
                column: "CategoryID");
            
            migrationBuilder.InsertData(
                table: "Business",
                columns: new[] { "ID", "Name" , "CategoryID", "NumberPhone", "Website"},
                values: new object[,]
                {
                    { 1, "The Game Shop", 2, "5551234567","www.thegameshop.com"},
                    { 2, "Walmart", 1, "4449876543","www.walmart.com"}
                });
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "Category");
        }


    }
}
