using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiExtensionChrome.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    MetaTitle = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Descriptions = table.Column<string>(maxLength: 250, nullable: true),
                    Detail = table.Column<string>(type: "ntext", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    MetaKeywords = table.Column<string>(maxLength: 250, nullable: true),
                    MetaDescriptions = table.Column<string>(fixedLength: true, maxLength: 250, nullable: true),
                    Status = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    Image = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Decriptions = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.RoleId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    Dob = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    MetaTilte = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ParentID = table.Column<long>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    SeoTilte = table.Column<string>(maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    MetaKeywords = table.Column<string>(maxLength: 250, nullable: true),
                    MetaDescriptions = table.Column<string>(fixedLength: true, maxLength: 250, nullable: true),
                    Status = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    ShowOnHome = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "ntext", nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    MetaTitle = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Descriptions = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    CategoryID = table.Column<long>(nullable: true),
                    Detail = table.Column<string>(type: "ntext", nullable: true),
                    Warranty = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    MetaKeywords = table.Column<string>(maxLength: 250, nullable: true),
                    MetaDescriptions = table.Column<string>(fixedLength: true, maxLength: 250, nullable: true),
                    Status = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    TopHot = table.Column<DateTime>(type: "datetime", nullable: true),
                    ViewCount = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true, defaultValueSql: "((0))"),
                    Tags = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContentTag",
                columns: table => new
                {
                    ContentID = table.Column<long>(nullable: false),
                    TagID = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentTag", x => new { x.ContentID, x.TagID });
                });

            migrationBuilder.CreateTable(
                name: "Credential",
                columns: table => new
                {
                    UserGroupID = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    RoleID = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credential", x => new { x.UserGroupID, x.RoleID });
                });

            migrationBuilder.CreateTable(
                name: "FeedBack",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Content = table.Column<string>(maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Status = table.Column<bool>(nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBack", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Footer",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true),
                    Status = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 50, nullable: true),
                    Link = table.Column<string>(maxLength: 250, nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    Target = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    TypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MenuType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerID = table.Column<long>(nullable: true),
                    ShipName = table.Column<string>(maxLength: 50, nullable: true),
                    ShipMobile = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ShipAddress = table.Column<string>(maxLength: 50, nullable: true),
                    ShipEmail = table.Column<string>(maxLength: 50, nullable: true),
                    TotalPrice = table.Column<long>(nullable: true),
                    Status = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    ProductID = table.Column<long>(nullable: false),
                    OrderID = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: true, defaultValueSql: "((1))"),
                    Price = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => new { x.ProductID, x.OrderID });
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Code = table.Column<string>(maxLength: 10, nullable: true),
                    MetaTitle = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Descriptions = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    MoreImages = table.Column<string>(type: "xml", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 0)", nullable: true, defaultValueSql: "((0))"),
                    PromotionPrice = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    IncludedVAT = table.Column<bool>(nullable: true),
                    Quantity = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    CategoryID = table.Column<long>(nullable: true),
                    Detail = table.Column<string>(type: "ntext", nullable: true),
                    Warranty = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    MetaKeywords = table.Column<string>(maxLength: 250, nullable: true),
                    MetaDescriptions = table.Column<string>(fixedLength: true, maxLength: 250, nullable: true),
                    Status = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    TopHot = table.Column<DateTime>(type: "datetime", nullable: true),
                    ViewCount = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    MetaTilte = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ParentID = table.Column<long>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    SeoTilte = table.Column<string>(maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    MetaKeywords = table.Column<string>(maxLength: 250, nullable: true),
                    MetaDescriptions = table.Column<string>(fixedLength: true, maxLength: 250, nullable: true),
                    Status = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    ShowOnHome = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Slide",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    Link = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Status = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    CreateBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slide", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SystemConfig",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    Value = table.Column<string>(maxLength: 250, nullable: true),
                    Status = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemConfig", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(unicode: false, maxLength: 32, nullable: true),
                    GroupID = table.Column<string>(unicode: false, maxLength: 20, nullable: true, defaultValueSql: "('MEMBER')"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<bool>(nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "ContentTag");

            migrationBuilder.DropTable(
                name: "Credential");

            migrationBuilder.DropTable(
                name: "FeedBack");

            migrationBuilder.DropTable(
                name: "Footer");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "MenuType");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Slide");

            migrationBuilder.DropTable(
                name: "SystemConfig");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserGroup");
        }
    }
}
