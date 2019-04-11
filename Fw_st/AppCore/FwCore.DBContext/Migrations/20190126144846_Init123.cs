using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FwCore.DBContext.Migrations
{
    public partial class Init123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pCategory",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CatName = table.Column<string>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    InsseredDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsVisiable = table.Column<bool>(nullable: false),
                    ParentCatID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pCategory", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_pCategory_pCategory_ParentCatID",
                        column: x => x.ParentCatID,
                        principalTable: "pCategory",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pColor",
                columns: table => new
                {
                    ColorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pColor", x => x.ColorID);
                });

            migrationBuilder.CreateTable(
                name: "pOrder",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderPlaceDate = table.Column<DateTime>(nullable: false),
                    DelevaryDate = table.Column<DateTime>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    IsDelevered = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pOrder", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "pBrand",
                columns: table => new
                {
                    BrandID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandName = table.Column<string>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pBrand", x => x.BrandID);
                    table.ForeignKey(
                        name: "FK_pBrand_pCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "pCategory",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoice_pOrder_OrderID",
                        column: x => x.OrderID,
                        principalTable: "pOrder",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oShipingAddress",
                columns: table => new
                {
                    OSAID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    OrderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oShipingAddress", x => x.OSAID);
                    table.ForeignKey(
                        name: "FK_oShipingAddress_pOrder_OrderID",
                        column: x => x.OrderID,
                        principalTable: "pOrder",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransID = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    OrderID = table.Column<int>(nullable: true),
                    PaymentTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_pOrder_OrderID",
                        column: x => x.OrderID,
                        principalTable: "pOrder",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Feature = table.Column<string>(nullable: true),
                    ReturnPolicy = table.Column<string>(nullable: true),
                    WarrentyPolicy = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    QRCode = table.Column<string>(nullable: true),
                    ManufactureDate = table.Column<DateTime>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    InsertdDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsVisiable = table.Column<bool>(nullable: false),
                    CategoryID = table.Column<int>(nullable: true),
                    BrandID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_pBrand_BrandID",
                        column: x => x.BrandID,
                        principalTable: "pBrand",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_pCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "pCategory",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "paymentType",
                columns: table => new
                {
                    PaymentTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentTypeName = table.Column<string>(nullable: true),
                    PaymentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentType", x => x.PaymentTypeID);
                    table.ForeignKey(
                        name: "FK_paymentType_Payment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustFavoredList",
                columns: table => new
                {
                    FavoredListID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustFavoredList", x => x.FavoredListID);
                    table.ForeignKey(
                        name: "FK_CustFavoredList_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Caption = table.Column<string>(nullable: true),
                    FilePathOrLink = table.Column<string>(nullable: true),
                    ThumbnailPathOrLink = table.Column<string>(nullable: true),
                    ShortDetails = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Images_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pOrderDetails",
                columns: table => new
                {
                    OrderDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UnitQuantity = table.Column<int>(nullable: false),
                    perUnitSellingPrice = table.Column<double>(nullable: false),
                    OrderID = table.Column<int>(nullable: true),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pOrderDetails", x => x.OrderDetailsID);
                    table.ForeignKey(
                        name: "FK_pOrderDetails_pOrder_OrderID",
                        column: x => x.OrderID,
                        principalTable: "pOrder",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pOrderDetails_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pProductColor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false),
                    ColorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pProductColor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_pProductColor_pColor_ColorID",
                        column: x => x.ColorID,
                        principalTable: "pColor",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pProductColor_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pReview",
                columns: table => new
                {
                    ReviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<double>(nullable: false),
                    AveRating = table.Column<double>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pReview", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_pReview_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductExtraInfo",
                columns: table => new
                {
                    PInfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RAM = table.Column<string>(nullable: true),
                    ROM = table.Column<string>(nullable: true),
                    StoreCapacity = table.Column<string>(nullable: true),
                    NumberOFSIM = table.Column<string>(nullable: true),
                    ProcessorType = table.Column<string>(nullable: true),
                    OperatingSystem = table.Column<string>(nullable: true),
                    FCamera = table.Column<string>(nullable: true),
                    BCamera = table.Column<string>(nullable: true),
                    Display = table.Column<string>(nullable: true),
                    CPUSpeed = table.Column<string>(nullable: true),
                    GraphicCard = table.Column<string>(nullable: true),
                    TvResulation = table.Column<string>(nullable: true),
                    Battery = table.Column<string>(nullable: true),
                    PowerBankCapacity = table.Column<string>(nullable: true),
                    HeadPhonFeature = table.Column<string>(nullable: true),
                    PortableSpeakerFeature = table.Column<string>(nullable: true),
                    AirCapacity = table.Column<string>(nullable: true),
                    PrintSpeed = table.Column<string>(nullable: true),
                    PenConnectorType = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductExtraInfo", x => x.PInfoID);
                    table.ForeignKey(
                        name: "FK_ProductExtraInfo_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pStock",
                columns: table => new
                {
                    StockID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tQuantity = table.Column<int>(nullable: false),
                    tpQuantity = table.Column<int>(nullable: false),
                    mlQuantity = table.Column<int>(nullable: false),
                    InsertdDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pStock", x => x.StockID);
                    table.ForeignKey(
                        name: "FK_pStock_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pUnitPrice",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MarketPrice = table.Column<decimal>(nullable: false),
                    SellingPrice = table.Column<decimal>(nullable: false),
                    InsertdDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pUnitPrice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_pUnitPrice_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustFavoredList_ProductID",
                table: "CustFavoredList",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductID",
                table: "Images",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_OrderID",
                table: "Invoice",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_oShipingAddress_OrderID",
                table: "oShipingAddress",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderID",
                table: "Payment",
                column: "OrderID",
                unique: true,
                filter: "[OrderID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_paymentType_PaymentID",
                table: "paymentType",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_pBrand_CategoryID",
                table: "pBrand",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_pCategory_ParentCatID",
                table: "pCategory",
                column: "ParentCatID");

            migrationBuilder.CreateIndex(
                name: "IX_pOrderDetails_OrderID",
                table: "pOrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_pOrderDetails_ProductID",
                table: "pOrderDetails",
                column: "ProductID",
                unique: true,
                filter: "[ProductID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_pProductColor_ColorID",
                table: "pProductColor",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_pProductColor_ProductID",
                table: "pProductColor",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_pReview_ProductID",
                table: "pReview",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandID",
                table: "Product",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductExtraInfo_ProductID",
                table: "ProductExtraInfo",
                column: "ProductID",
                unique: true,
                filter: "[ProductID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_pStock_ProductID",
                table: "pStock",
                column: "ProductID",
                unique: true,
                filter: "[ProductID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_pUnitPrice_ProductID",
                table: "pUnitPrice",
                column: "ProductID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustFavoredList");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "oShipingAddress");

            migrationBuilder.DropTable(
                name: "paymentType");

            migrationBuilder.DropTable(
                name: "pOrderDetails");

            migrationBuilder.DropTable(
                name: "pProductColor");

            migrationBuilder.DropTable(
                name: "pReview");

            migrationBuilder.DropTable(
                name: "ProductExtraInfo");

            migrationBuilder.DropTable(
                name: "pStock");

            migrationBuilder.DropTable(
                name: "pUnitPrice");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "pColor");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "pOrder");

            migrationBuilder.DropTable(
                name: "pBrand");

            migrationBuilder.DropTable(
                name: "pCategory");
        }
    }
}
