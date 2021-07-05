using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriberAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubscriberProduct",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    SubscriberID = table.Column<int>(nullable: false),
                    PaymentIntervalID = table.Column<int>(nullable: false),
                    SubscribtionStart = table.Column<DateTime>(nullable: false),
                    SubscribtionEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberProduct", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriberProduct");
        }
    }
}
