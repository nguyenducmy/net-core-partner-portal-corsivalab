using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace partnerportal.Migrations
{
    public partial class partnerportal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.CreateTable(
                name: "CLM_ApiLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(unicode: false, nullable: false),
                    LogDateTime = table.Column<DateTime>(nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_ApiLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Username = table.Column<string>(unicode: false, nullable: false),
                    Company = table.Column<string>(unicode: false, nullable: false),
                    Email = table.Column<string>(unicode: false, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: false),
                    FK_IndustryId = table.Column<int>(nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CLM_DomainProvider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, nullable: true),
                    SoftDelete = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_DomainProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_EmailSystem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailSystem = table.Column<string>(nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_EmailSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_HostingProvider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, nullable: true),
                    SoftDelete = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_HostingProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_Industry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustryName = table.Column<string>(unicode: false, nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CLM_LeadsFromCorsiva",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerEmail = table.Column<string>(nullable: true),
                    CustomerPhone = table.Column<string>(nullable: true),
                    AdditionalRemarks = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    ServiceRequired = table.Column<string>(nullable: true),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_LeadsFromCorsiva", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_LeadsStatusLogsToCorsiva",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeOfChange = table.Column<DateTime>(nullable: false),
                    FkLeadsId = table.Column<int>(nullable: false),
                    StatusCode = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_LeadsStatusLogsToCorsiva", x => x.Id);
                });*/

            migrationBuilder.CreateTable(
                name: "CLM_LeadsToCorsiva",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerEmail = table.Column<string>(nullable: true),
                    CustomerPhone = table.Column<string>(nullable: true),
                    AdditionalRemarks = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    ServiceRequired = table.Column<string>(nullable: true),
                    FkCorsivaStaffId = table.Column<string>(nullable: true),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_LeadsToCorsiva", x => x.Id);
                });

           /* migrationBuilder.CreateTable(
                name: "CLM_MaintenanceHourly",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_ProjectId = table.Column<int>(nullable: true),
                    ServiceHourLeft = table.Column<string>(nullable: true),
                    ExpiryTime = table.Column<DateTime>(nullable: true),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_MaintenanceHourly", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_MaintenanceLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_ProjectId = table.Column<int>(nullable: false),
                    FK_StaffId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(unicode: false, nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_MaintenanceLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_MaintenanceMonthly",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_ProjectId = table.Column<int>(nullable: true),
                    ExpiryTime = table.Column<DateTime>(nullable: true),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_MaintenanceMonthly", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_MaintenanceReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_ProjectId = table.Column<int>(nullable: false),
                    FK_StaffId = table.Column<int>(nullable: false),
                    Link = table.Column<string>(unicode: false, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    MonthYear = table.Column<DateTime>(nullable: true),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_MaintenanceReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_Partner",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
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
                    Remarks = table.Column<string>(unicode: false, nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_Partner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_PartnerSignedAgreement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_PartnerId = table.Column<string>(nullable: true),
                    SignedAgreementsURL = table.Column<string>(nullable: true),
                    TypeOfAgreement = table.Column<int>(nullable: false),
                    DateOfAgreement = table.Column<DateTime>(nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_PartnerSignedAgreement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(unicode: false, nullable: true),
                    Domain = table.Column<string>(unicode: false, nullable: true),
                    MaintExpire = table.Column<DateTime>(nullable: true),
                    ForecastStart = table.Column<string>(unicode: false, nullable: true),
                    Forecast = table.Column<int>(nullable: true),
                    MaintStart = table.Column<DateTime>(nullable: true),
                    ForecastAmount = table.Column<string>(unicode: false, nullable: true),
                    EmailSystemExpire = table.Column<DateTime>(nullable: true),
                    EmailSystemOwner = table.Column<string>(unicode: false, nullable: true),
                    FK_CustomerId = table.Column<int>(nullable: true),
                    MaintainBy = table.Column<string>(unicode: false, nullable: true),
                    FK_EmailSystemId = table.Column<int>(nullable: true),
                    SoftDelete = table.Column<bool>(nullable: true),
                    AMEmail = table.Column<string>(unicode: false, nullable: true),
                    Phase = table.Column<int>(nullable: true),
                    ProjectNature = table.Column<int>(nullable: true),
                    DomainCost = table.Column<string>(unicode: false, nullable: true),
                    HostingCost = table.Column<string>(unicode: false, nullable: true),
                    EmailCost = table.Column<string>(unicode: false, nullable: true),
                    MaintCost = table.Column<string>(unicode: false, nullable: true),
                    Remarks = table.Column<string>(unicode: false, nullable: true),
                    FKDomainProvider = table.Column<int>(nullable: true),
                    Code = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    ShortLink = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CLM_ProjectBackUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Link = table.Column<string>(unicode: false, nullable: true),
                    FK_ProjectId = table.Column<int>(nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CLM_ProjectCredential",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_ProjectId = table.Column<int>(nullable: false),
                    CredentialInfos = table.Column<string>(unicode: false, nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_ProjectCredential", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_ProjectCredentialLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_ProjectId = table.Column<int>(nullable: false),
                    FK_StaffId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(unicode: false, nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_ProjectCredentialLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_ProjectDomain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Domain = table.Column<string>(unicode: false, nullable: true),
                    Expiry = table.Column<DateTime>(nullable: true),
                    Provider = table.Column<int>(nullable: true),
                    Owner = table.Column<int>(nullable: true),
                    FK_ProjectID = table.Column<int>(nullable: true),
                    SoftDelete = table.Column<bool>(nullable: true),
                    Cost = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_ProjectDomain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_ProjectEmailSystem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provider = table.Column<int>(nullable: true),
                    Owner = table.Column<int>(nullable: true),
                    Expiry = table.Column<DateTime>(nullable: true),
                    FK_ProjectID = table.Column<int>(nullable: true),
                    SoftDelete = table.Column<bool>(nullable: true),
                    Cost = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_ProjectEmailSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_ProjectHosting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provider = table.Column<int>(nullable: true),
                    Owner = table.Column<int>(nullable: true),
                    Expiry = table.Column<DateTime>(nullable: true),
                    FK_ProjectID = table.Column<int>(nullable: true),
                    SoftDelete = table.Column<bool>(nullable: true),
                    Cost = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_ProjectHosting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_ProjectHourlyMaintenace",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HourPackge = table.Column<string>(unicode: false, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    PurchasedDate = table.Column<DateTime>(nullable: true),
                    HoursSpent = table.Column<double>(nullable: true),
                    FkProjectId = table.Column<int>(nullable: true),
                    SoftDelete = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_ProjectHourlyMaintenace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_ProjectHourlyMaintenaceRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoursSpent = table.Column<double>(nullable: true),
                    HourResonRequest = table.Column<string>(unicode: false, nullable: true),
                    SoftDelete = table.Column<bool>(nullable: true),
                    FkProjectHourlyMaintenaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_ProjectHourlyMaintenaceRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_ProjectMonthlyMaintenance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    FkProjectId = table.Column<int>(nullable: true),
                    Per = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Amount = table.Column<int>(nullable: true),
                    SoftDelete = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_ProjectMonthlyMaintenance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_Quotation",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    fkPreviousQuotationRef = table.Column<int>(nullable: false),
                    name = table.Column<string>(unicode: false, nullable: false),
                    quotationVersion = table.Column<decimal>(type: "decimal(18, 5)", nullable: false),
                    quotationJson = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    totalQuote = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    remarks = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    finalised = table.Column<DateTime>(type: "date", nullable: false),
                    softDelete = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CLM_ResetPasswordModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_ResetPasswordModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_SolutionBrochures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleOfBrochure = table.Column<string>(nullable: true),
                    TypeOfBrochure = table.Column<int>(nullable: false),
                    VersionNumber = table.Column<double>(nullable: false),
                    DateOfBrochure = table.Column<DateTime>(nullable: false),
                    BrochureURL = table.Column<string>(nullable: true),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_SolutionBrochures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_Staff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Username = table.Column<string>(unicode: false, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CLM_StaffCredentialRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_StaffId = table.Column<int>(nullable: false),
                    FK_ProjectId = table.Column<int>(nullable: false),
                    ExpiryTime = table.Column<DateTime>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_StaffCredentialRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_TechnolodyUsed",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Technology = table.Column<string>(unicode: false, nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLM_TechnolodyUsed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLM_TicketImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketImage = table.Column<string>(nullable: false),
                    FK_TicketId = table.Column<int>(nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CLM_TicketReply",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketNumber = table.Column<string>(unicode: false, nullable: false),
                    Messages = table.Column<string>(unicode: false, nullable: false),
                    PersonReplyed = table.Column<string>(unicode: false, nullable: false),
                    FK_TicketiId = table.Column<int>(nullable: false),
                    IsStaff = table.Column<int>(nullable: false),
                    Title = table.Column<string>(unicode: false, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Approve = table.Column<bool>(nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CLM_Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketNumber = table.Column<string>(unicode: false, nullable: false),
                    Subject = table.Column<string>(unicode: false, nullable: false),
                    Messages = table.Column<string>(unicode: false, nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    StaffAssigned = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    FK_ProjectId = table.Column<int>(nullable: false),
                    FK_CustomerId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    SoftDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                });*/
        }

        /*protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLM_ApiLog");

            migrationBuilder.DropTable(
                name: "CLM_Customer");

            migrationBuilder.DropTable(
                name: "CLM_DomainProvider");

            migrationBuilder.DropTable(
                name: "CLM_EmailSystem");

            migrationBuilder.DropTable(
                name: "CLM_HostingProvider");

            migrationBuilder.DropTable(
                name: "CLM_Industry");

            migrationBuilder.DropTable(
                name: "CLM_LeadsFromCorsiva");

            migrationBuilder.DropTable(
                name: "CLM_LeadsStatusLogsToCorsiva");

            migrationBuilder.DropTable(
                name: "CLM_LeadsToCorsiva");

            migrationBuilder.DropTable(
                name: "CLM_MaintenanceHourly");

            migrationBuilder.DropTable(
                name: "CLM_MaintenanceLog");

            migrationBuilder.DropTable(
                name: "CLM_MaintenanceMonthly");

            migrationBuilder.DropTable(
                name: "CLM_MaintenanceReport");

            migrationBuilder.DropTable(
                name: "CLM_Partner");

            migrationBuilder.DropTable(
                name: "CLM_PartnerSignedAgreement");

            migrationBuilder.DropTable(
                name: "CLM_Project");

            migrationBuilder.DropTable(
                name: "CLM_ProjectBackUp");

            migrationBuilder.DropTable(
                name: "CLM_ProjectCredential");

            migrationBuilder.DropTable(
                name: "CLM_ProjectCredentialLog");

            migrationBuilder.DropTable(
                name: "CLM_ProjectDomain");

            migrationBuilder.DropTable(
                name: "CLM_ProjectEmailSystem");

            migrationBuilder.DropTable(
                name: "CLM_ProjectHosting");

            migrationBuilder.DropTable(
                name: "CLM_ProjectHourlyMaintenace");

            migrationBuilder.DropTable(
                name: "CLM_ProjectHourlyMaintenaceRecord");

            migrationBuilder.DropTable(
                name: "CLM_ProjectMonthlyMaintenance");

            migrationBuilder.DropTable(
                name: "CLM_Quotation");

            migrationBuilder.DropTable(
                name: "CLM_ResetPasswordModel");

            migrationBuilder.DropTable(
                name: "CLM_SolutionBrochures");

            migrationBuilder.DropTable(
                name: "CLM_Staff");

            migrationBuilder.DropTable(
                name: "CLM_StaffCredentialRequest");

            migrationBuilder.DropTable(
                name: "CLM_TechnolodyUsed");

            migrationBuilder.DropTable(
                name: "CLM_TicketImages");

            migrationBuilder.DropTable(
                name: "CLM_TicketReply");

            migrationBuilder.DropTable(
                name: "CLM_Tickets");
        }*/
    }
}
