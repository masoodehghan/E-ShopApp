using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopApp.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalPriceToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "TEXT",
                nullable: true,
                defaultValue: "Buyer",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValue: "Buyer");

            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                type: "TEXT",
                nullable: true,
                defaultValue: "UnPaid",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValue: "UnPaid");

            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "Orders",
                type: "REAL",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "Buyer",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true,
                oldDefaultValue: "Buyer");

            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "UnPaid",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true,
                oldDefaultValue: "UnPaid");
        }
    }
}
