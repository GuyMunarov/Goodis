using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastracture.Data.migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BpTypes",
                columns: table => new
                {
                    TypeCode = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false),
                    TypeName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BpTypes", x => x.TypeCode);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ItemName = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemCode);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPartners",
                columns: table => new
                {
                    BpCode = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    BPName = table.Column<string>(type: "TEXT", nullable: false),
                    BpTypeTypeCode = table.Column<string>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPartners", x => x.BpCode);
                    table.ForeignKey(
                        name: "FK_BusinessPartners_BpTypes_BpTypeTypeCode",
                        column: x => x.BpTypeTypeCode,
                        principalTable: "BpTypes",
                        principalColumn: "TypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BpCode = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    LastUpdatedById = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_BusinessPartners_BpCode",
                        column: x => x.BpCode,
                        principalTable: "BusinessPartners",
                        principalColumn: "BpCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BpCode = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    LastUpdatedById = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOrders_BusinessPartners_BpCode",
                        column: x => x.BpCode,
                        principalTable: "BusinessPartners",
                        principalColumn: "BpCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOrders_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOrders_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderLines",
                columns: table => new
                {
                    LineID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdatedById = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    DocID = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemCode = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "decimal(38,18)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderLines", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLines_Items_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "Items",
                        principalColumn: "ItemCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLines_PurchaseOrders_DocID",
                        column: x => x.DocID,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLines_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLines_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleOrderLines",
                columns: table => new
                {
                    LineID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdatedById = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    DocID = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemCode = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "decimal(38,18)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrderLines", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_SaleOrderLines_Items_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "Items",
                        principalColumn: "ItemCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOrderLines_SaleOrders_DocID",
                        column: x => x.DocID,
                        principalTable: "SaleOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOrderLines_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOrderLines_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleOrderLinesComments",
                columns: table => new
                {
                    CommentLineID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DocId = table.Column<int>(type: "INTEGER", nullable: false),
                    LineID = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrderLinesComments", x => x.CommentLineID);
                    table.ForeignKey(
                        name: "FK_SaleOrderLinesComments_SaleOrderLines_LineID",
                        column: x => x.LineID,
                        principalTable: "SaleOrderLines",
                        principalColumn: "LineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOrderLinesComments_SaleOrders_DocId",
                        column: x => x.DocId,
                        principalTable: "SaleOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPartners_BpTypeTypeCode",
                table: "BusinessPartners",
                column: "BpTypeTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLines_CreatedById",
                table: "PurchaseOrderLines",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLines_DocID",
                table: "PurchaseOrderLines",
                column: "DocID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLines_ItemCode",
                table: "PurchaseOrderLines",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLines_LastUpdatedById",
                table: "PurchaseOrderLines",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_BpCode",
                table: "PurchaseOrders",
                column: "BpCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_CreatedById",
                table: "PurchaseOrders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_LastUpdatedById",
                table: "PurchaseOrders",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLines_CreatedById",
                table: "SaleOrderLines",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLines_DocID",
                table: "SaleOrderLines",
                column: "DocID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLines_ItemCode",
                table: "SaleOrderLines",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLines_LastUpdatedById",
                table: "SaleOrderLines",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLinesComments_DocId",
                table: "SaleOrderLinesComments",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLinesComments_LineID",
                table: "SaleOrderLinesComments",
                column: "LineID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_BpCode",
                table: "SaleOrders",
                column: "BpCode");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_CreatedById",
                table: "SaleOrders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_LastUpdatedById",
                table: "SaleOrders",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrderLines");

            migrationBuilder.DropTable(
                name: "SaleOrderLinesComments");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "SaleOrderLines");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "SaleOrders");

            migrationBuilder.DropTable(
                name: "BusinessPartners");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BpTypes");
        }
    }
}
