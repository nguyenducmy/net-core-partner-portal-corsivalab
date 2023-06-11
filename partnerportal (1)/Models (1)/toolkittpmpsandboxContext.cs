using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace partnerportal.Models
{
    public partial class toolkittpmpsandboxContext : DbContext/*IdentityDbContext<ClmPartner>*/
    {
        public toolkittpmpsandboxContext()
        {
        }

        public toolkittpmpsandboxContext(DbContextOptions<toolkittpmpsandboxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClmApiLog> ClmApiLog { get; set; }
        public virtual DbSet<ClmCustomer> ClmCustomer { get; set; }
        public virtual DbSet<ClmDomainProvider> ClmDomainProvider { get; set; }
        public virtual DbSet<ClmEmailSystem> ClmEmailSystem { get; set; }
        public virtual DbSet<ClmHostingProvider> ClmHostingProvider { get; set; }
        public virtual DbSet<ClmIndustry> ClmIndustry { get; set; }
        public virtual DbSet<ClmMaintenanceHourly> ClmMaintenanceHourly { get; set; }
        public virtual DbSet<ClmMaintenanceLog> ClmMaintenanceLog { get; set; }
        public virtual DbSet<ClmMaintenanceMonthly> ClmMaintenanceMonthly { get; set; }
        public virtual DbSet<ClmMaintenanceReport> ClmMaintenanceReport { get; set; }
        public virtual DbSet<ClmProject> ClmProject { get; set; }
        public virtual DbSet<ClmProjectBackUp> ClmProjectBackUp { get; set; }
        public virtual DbSet<ClmProjectCredential> ClmProjectCredential { get; set; }
        public virtual DbSet<ClmProjectCredentialLog> ClmProjectCredentialLog { get; set; }
        public virtual DbSet<ClmProjectDomain> ClmProjectDomain { get; set; }
        public virtual DbSet<ClmProjectEmailSystem> ClmProjectEmailSystem { get; set; }
        public virtual DbSet<ClmProjectHosting> ClmProjectHosting { get; set; }
        public virtual DbSet<ClmProjectHourlyMaintenace> ClmProjectHourlyMaintenace { get; set; }
        public virtual DbSet<ClmProjectHourlyMaintenaceRecord> ClmProjectHourlyMaintenaceRecord { get; set; }
        public virtual DbSet<ClmProjectMonthlyMaintenance> ClmProjectMonthlyMaintenance { get; set; }
        public virtual DbSet<ClmQuotation> ClmQuotation { get; set; }
        public virtual DbSet<ClmStaff> ClmStaff { get; set; }
        public virtual DbSet<ClmStaffCredentialRequest> ClmStaffCredentialRequest { get; set; }
        public virtual DbSet<ClmTechnolodyUsed> ClmTechnolodyUsed { get; set; }
        public virtual DbSet<ClmTicketImages> ClmTicketImages { get; set; }
        public virtual DbSet<ClmTicketReply> ClmTicketReply { get; set; }
        public virtual DbSet<ClmTickets> ClmTickets { get; set; }
        public virtual DbSet<ClmPartner> ClmPartner { get; set; }
        public virtual DbSet<ClmPartnerSignedAgreements> ClmPartnerSignedAgreements { get; set; }
        public virtual DbSet<ClmLeadsFromCorsiva> ClmLeadsFromCorsiva { get; set; }
        public virtual DbSet<ClmLeadsToCorsiva> ClmLeadsToCorsiva { get; set; }
        public virtual DbSet<ClmLeadsStatusLogsToCorsiva> ClmLeadsStatusLogsToCorsiva { get; set; }
        public virtual DbSet<ClmSolutionBrochures> ClmSolutionBrochures { get; set; }
        public virtual DbSet<ClmResetPasswordModel> ClmResetPasswordModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=tcp:toolkittpmp.database.windows.net;Database=toolkittpmpsandbox;User ID=toolkittpmp;Password=corsiva_LAB_999;Trusted_Connection=False;Encrypt=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClmApiLog>(entity =>
            {
                entity.ToTable("CLM_ApiLog");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClmCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CLM_Customer");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FkIndustryId).HasColumnName("FK_IndustryId");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClmDomainProvider>(entity =>
            {
                entity.ToTable("CLM_DomainProvider");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<ClmEmailSystem>(entity =>
            {
                entity.ToTable("CLM_EmailSystem");

                entity.Property(e => e.EmailSystem).IsRequired();
            });

            modelBuilder.Entity<ClmHostingProvider>(entity =>
            {
                entity.ToTable("CLM_HostingProvider");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<ClmIndustry>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CLM_Industry");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IndustryName)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClmMaintenanceHourly>(entity =>
            {
                entity.ToTable("CLM_MaintenanceHourly");

                entity.Property(e => e.FkProjectId).HasColumnName("FK_ProjectId");
            });

            modelBuilder.Entity<ClmMaintenanceLog>(entity =>
            {
                entity.ToTable("CLM_MaintenanceLog");

                entity.Property(e => e.FkProjectId).HasColumnName("FK_ProjectId");

                entity.Property(e => e.FkStaffId).HasColumnName("FK_StaffId");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClmMaintenanceMonthly>(entity =>
            {
                entity.ToTable("CLM_MaintenanceMonthly");

                entity.Property(e => e.FkProjectId).HasColumnName("FK_ProjectId");
            });

            modelBuilder.Entity<ClmMaintenanceReport>(entity =>
            {
                entity.ToTable("CLM_MaintenanceReport");

                entity.Property(e => e.FkProjectId).HasColumnName("FK_ProjectId");

                entity.Property(e => e.FkStaffId).HasColumnName("FK_StaffId");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClmProject>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CLM_Project");

                entity.Property(e => e.Amemail)
                    .HasColumnName("AMEmail")
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Domain).IsUnicode(false);

                entity.Property(e => e.DomainCost).IsUnicode(false);

                entity.Property(e => e.EmailCost).IsUnicode(false);

                entity.Property(e => e.EmailSystemOwner).IsUnicode(false);

                entity.Property(e => e.FkCustomerId).HasColumnName("FK_CustomerId");

                entity.Property(e => e.FkEmailSystemId).HasColumnName("FK_EmailSystemId");

                entity.Property(e => e.FkdomainProvider).HasColumnName("FKDomainProvider");

                entity.Property(e => e.ForecastAmount).IsUnicode(false);

                entity.Property(e => e.ForecastStart).IsUnicode(false);

                entity.Property(e => e.HostingCost).IsUnicode(false);

                entity.Property(e => e.MaintCost).IsUnicode(false);

                entity.Property(e => e.MaintainBy).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.ShortLink).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<ClmProjectBackUp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CLM_ProjectBackUp");

                entity.Property(e => e.FkProjectId).HasColumnName("FK_ProjectId");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Link).IsUnicode(false);
            });

            modelBuilder.Entity<ClmProjectCredential>(entity =>
            {
                entity.ToTable("CLM_ProjectCredential");

                entity.Property(e => e.CredentialInfos).IsUnicode(false);

                entity.Property(e => e.FkProjectId).HasColumnName("FK_ProjectId");
            });

            modelBuilder.Entity<ClmProjectCredentialLog>(entity =>
            {
                entity.ToTable("CLM_ProjectCredentialLog");

                entity.Property(e => e.FkProjectId).HasColumnName("FK_ProjectId");

                entity.Property(e => e.FkStaffId).HasColumnName("FK_StaffId");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClmProjectDomain>(entity =>
            {
                entity.ToTable("CLM_ProjectDomain");

                entity.Property(e => e.Cost).IsUnicode(false);

                entity.Property(e => e.Domain).IsUnicode(false);

                entity.Property(e => e.FkProjectId).HasColumnName("FK_ProjectID");
            });

            modelBuilder.Entity<ClmProjectEmailSystem>(entity =>
            {
                entity.ToTable("CLM_ProjectEmailSystem");

                entity.Property(e => e.Cost).IsUnicode(false);

                entity.Property(e => e.FkProjectId).HasColumnName("FK_ProjectID");
            });

            modelBuilder.Entity<ClmProjectHosting>(entity =>
            {
                entity.ToTable("CLM_ProjectHosting");

                entity.Property(e => e.Cost).IsUnicode(false);

                entity.Property(e => e.FkProjectId).HasColumnName("FK_ProjectID");
            });

            modelBuilder.Entity<ClmProjectHourlyMaintenace>(entity =>
            {
                entity.ToTable("CLM_ProjectHourlyMaintenace");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.HourPackge).IsUnicode(false);
            });

            modelBuilder.Entity<ClmProjectHourlyMaintenaceRecord>(entity =>
            {
                entity.ToTable("CLM_ProjectHourlyMaintenaceRecord");

                entity.Property(e => e.HourResonRequest).IsUnicode(false);
            });

            modelBuilder.Entity<ClmProjectMonthlyMaintenance>(entity =>
            {
                entity.ToTable("CLM_ProjectMonthlyMaintenance");

                entity.Property(e => e.Per)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClmQuotation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CLM_Quotation");

                entity.Property(e => e.Finalised)
                    .HasColumnName("finalised")
                    .HasColumnType("date");

                entity.Property(e => e.FkPreviousQuotationRef).HasColumnName("fkPreviousQuotationRef");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.QuotationJson)
                    .IsRequired()
                    .HasColumnName("quotationJson")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.QuotationVersion)
                    .HasColumnName("quotationVersion")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasColumnName("remarks")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SoftDelete).HasColumnName("softDelete");

                entity.Property(e => e.TotalQuote)
                    .HasColumnName("totalQuote")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<ClmStaff>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CLM_Staff");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClmStaffCredentialRequest>(entity =>
            {
                entity.ToTable("CLM_StaffCredentialRequest");

                entity.Property(e => e.FkProjectId).HasColumnName("FK_ProjectId");

                entity.Property(e => e.FkStaffId).HasColumnName("FK_StaffId");
            });

            modelBuilder.Entity<ClmTechnolodyUsed>(entity =>
            {
                entity.ToTable("CLM_TechnolodyUsed");

                entity.Property(e => e.Technology)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClmTicketImages>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CLM_TicketImages");

                entity.Property(e => e.FkTicketId).HasColumnName("FK_TicketId");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TicketImage).IsRequired();
            });

            modelBuilder.Entity<ClmTicketReply>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CLM_TicketReply");

                entity.Property(e => e.FkTicketiId).HasColumnName("FK_TicketiId");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Messages)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PersonReplyed)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TicketNumber)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClmTickets>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CLM_Tickets");

                entity.Property(e => e.FkCustomerId).HasColumnName("FK_CustomerId");

                entity.Property(e => e.FkProjectId).HasColumnName("FK_ProjectId");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Messages)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TicketNumber)
                    .IsRequired()
                    .IsUnicode(false);
            });
            modelBuilder.Entity<ClmPartner>(entity =>
            {
                entity.ToTable("CLM_Partner");
                
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.NormalizedUserName).HasColumnName("NormalizedUserName");
                entity.Property(e => e.EmailConfirmed).HasColumnName("EmailConfirmed");
                entity.Property(e => e.PasswordHash).HasColumnName("PasswordHash");
                entity.Property(e => e.SecurityStamp).HasColumnName("SecurityStamp");
                entity.Property(e => e.ConcurrencyStamp).HasColumnName("ConcurrencyStamp");
                entity.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber");
                entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed");
                entity.Property(e => e.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
                entity.Property(e => e.LockoutEnd).HasColumnName("LockoutEnd");
                entity.Property(e => e.LockoutEnabled).HasColumnName("LockoutEnabled");
                entity.Property(e => e.AccessFailedCount).HasColumnName("AccessFailedCount");
/*
                entity.Property(e => e.Username).HasColumnName("Username");

                entity.Property(e => e.Password).HasColumnName("Password");*/

                entity.Property(e => e.Email).HasColumnName("Email");
/*
                entity.Property(e => e.Phone).HasColumnName("Phone");*/

                entity.Property(e => e.Remarks).HasColumnName("Remarks")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SoftDelete).HasColumnName("SoftDelete");
            });
            modelBuilder.Entity<ClmPartnerSignedAgreements>(entity =>
            {
                entity.ToTable("CLM_PartnerSignedAgreement");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.SignedAgreementsURL).HasColumnName("SignedAgreementsURL");

                entity.Property(e => e.TypeOfAgreement).HasColumnName("TypeOfAgreement");

                entity.Property(e => e.DateOfAgreement).HasColumnName("DateOfAgreement");

                entity.Property(e => e.SoftDelete).HasColumnName("SoftDelete");

                entity.Property(e => e.FkPartnerId).HasColumnName("FK_PartnerId");
            });
            modelBuilder.Entity<ClmLeadsFromCorsiva>(entity =>
            {
                entity.ToTable("CLM_LeadsFromCorsiva");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerName).HasColumnName("CustomerName");

                entity.Property(e => e.CustomerEmail).HasColumnName("CustomerEmail");

                entity.Property(e => e.CustomerPhone).HasColumnName("CustomerPhone");

                entity.Property(e => e.AdditionalRemarks).HasColumnName("AdditionalRemarks");

                entity.Property(e => e.DateAdded).HasColumnName("DateAdded");

                entity.Property(e => e.Remarks).HasColumnName("Remarks");

                entity.Property(e => e.ServiceRequired).HasColumnName("ServiceRequired");

                entity.Property(e => e.SoftDelete).HasColumnName("SoftDelete");

            });
            modelBuilder.Entity<ClmLeadsToCorsiva>(entity =>
            {
                entity.ToTable("CLM_LeadsToCorsiva");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerName).HasColumnName("CustomerName");

                entity.Property(e => e.CustomerEmail).HasColumnName("CustomerEmail");

                entity.Property(e => e.CustomerPhone).HasColumnName("CustomerPhone");

                entity.Property(e => e.AdditionalRemarks).HasColumnName("AdditionalRemarks");

                entity.Property(e => e.DateAdded).HasColumnName("DateAdded");

                entity.Property(e => e.Remarks).HasColumnName("Remarks");

                entity.Property(e => e.ServiceRequired).HasColumnName("ServiceRequired");

                entity.Property(e => e.FkCorsivaStaffId).HasColumnName("FkCorsivaStaffId");

                entity.Property(e => e.SoftDelete).HasColumnName("SoftDelete");

            });
            modelBuilder.Entity<ClmLeadsStatusLogsToCorsiva>(entity =>
            {
                entity.ToTable("CLM_LeadsStatusLogsToCorsiva");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.DateTimeOfChange).HasColumnName("DateTimeOfChange");

                entity.Property(e => e.FkLeadsId).HasColumnName("FkLeadsId");

                entity.Property(e => e.StatusCode).HasColumnName("StatusCode");

                entity.Property(e => e.Message).HasColumnName("Message");

                entity.Property(e => e.SoftDelete).HasColumnName("SoftDelete");
             });
            modelBuilder.Entity<ClmSolutionBrochures>(entity =>
            {
                entity.ToTable("CLM_SolutionBrochures");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TitleOfBrochure).HasColumnName("TitleOfBrochure");

                entity.Property(e => e.TypeOfBrochure).HasColumnName("TypeOfBrochure");

                entity.Property(e => e.VersionNumber).HasColumnName("VersionNumber");

                entity.Property(e => e.DateOfBrochure).HasColumnName("DateOfBrochure");

                entity.Property(e => e.BrochureURL).HasColumnName("BrochureURL");

                entity.Property(e => e.SoftDelete).HasColumnName("SoftDelete");
            });


            modelBuilder.Entity<ClmResetPasswordModel>(entity =>
            {
                entity.ToTable("CLM_ResetPasswordModel");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Email).HasColumnName("Email");

                entity.Property(e => e.Token).HasColumnName("Token");

                entity.Property(e => e.Password).HasColumnName("Password");

                entity.Property(e => e.ConfirmPassword).HasColumnName("ConfirmPassword");

            });














            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
