using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTS.Host.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVoucherEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "Voucher");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Voucher",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Voucher",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Voucher");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Voucher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Voucher",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "Voucher",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Voucher",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Voucher",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "Voucher",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
