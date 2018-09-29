namespace CommitteesManager.DAL.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CMDB : DbContext
    {
        public CMDB()
            : base("name=CMDB")
        {
        }

        public virtual DbSet<AccessType> AccessTypes { get; set; }
        public virtual DbSet<Agenda> Agendas { get; set; }
        public virtual DbSet<Committee> Committees { get; set; }
        public virtual DbSet<Counterparty> Counterparties { get; set; }
        public virtual DbSet<Covenant> Covenants { get; set; }
        public virtual DbSet<DealType> DealTypes { get; set; }
        public virtual DbSet<Environment> Environments { get; set; }
        public virtual DbSet<Mode> Modes { get; set; }
        public virtual DbSet<Protocol> Protocols { get; set; }
        public virtual DbSet<Reason> Reasons { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<RegisterOfApproved> RegisterOfApproveds { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessType>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.AccessType)
                .HasForeignKey(e => e.Access_typeID);

            modelBuilder.Entity<Agenda>()
                .Property(e => e.AgendaID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Agenda>()
                .Property(e => e.Contract_id)
                .HasPrecision(8, 0);

            modelBuilder.Entity<Agenda>()
                .HasMany(e => e.Covenants)
                .WithRequired(e => e.Agenda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Agenda>()
                .HasMany(e => e.Deals)
                .WithRequired(e => e.Agenda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Committee>()
                .HasMany(e => e.Protocols)
                .WithRequired(e => e.Committee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Covenant>()
                .Property(e => e.AgendaID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DealType>()
                .Property(e => e.Deal_name_US)
                .IsUnicode(false);

            modelBuilder.Entity<DealType>()
                .Property(e => e.Question_type_US)
                .IsUnicode(false);

            modelBuilder.Entity<DealType>()
                .Property(e => e.Deal_type)
                .IsUnicode(false);

            modelBuilder.Entity<DealType>()
                .HasMany(e => e.Deals)
                .WithRequired(e => e.DealType)
                .HasForeignKey(e => e.Deal_typeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DealType>()
                .HasMany(e => e.Deals1)
                .WithOptional(e => e.DealType1)
                .HasForeignKey(e => e.Agreed_deal_typeID);

            modelBuilder.Entity<Environment>()
                .Property(e => e.EnvName)
                .IsUnicode(false);

            modelBuilder.Entity<Environment>()
                .Property(e => e.EnvValue)
                .IsUnicode(false);

            modelBuilder.Entity<Mode>()
                .Property(e => e.Mode_name_US)
                .IsUnicode(false);

            modelBuilder.Entity<Mode>()
                .HasMany(e => e.Protocols)
                .WithRequired(e => e.Mode)
                .HasForeignKey(e => e.Protocol_mode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Protocol>()
                .Property(e => e.ResponsibleID)
                .IsUnicode(false);

            modelBuilder.Entity<Protocol>()
                .Property(e => e.ReporterID)
                .IsUnicode(false);

            modelBuilder.Entity<Protocol>()
                .HasMany(e => e.Agendas)
                .WithRequired(e => e.Protocol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Protocol>()
                .HasMany(e => e.Protocols1)
                .WithOptional(e => e.Protocol1)
                .HasForeignKey(e => e.ProtocolID_longation);

            modelBuilder.Entity<Protocol>()
                .HasMany(e => e.RegisterOfApproveds)
                .WithRequired(e => e.Protocol)
                .HasForeignKey(e => e.ProtocolID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegisterOfApproved>()
                .Property(e => e.Protocol_number)
                .IsUnicode(false);

            modelBuilder.Entity<RegisterOfApproved>()
                .HasMany(e => e.Protocols)
                .WithOptional(e => e.RegisterOfApproved)
                .HasForeignKey(e => e.RegisterID);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Deals)
                .WithOptional(e => e.Status)
                .HasForeignKey(e => e.DecisionID);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Deals1)
                .WithOptional(e => e.Status1)
                .HasForeignKey(e => e.Deal_statusID);

            modelBuilder.Entity<User>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.User_name_US)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.HeadID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Protocols)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ReporterID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Protocols1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.ResponsibleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Users1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.HeadID);

            modelBuilder.Entity<Deal>()
                .Property(e => e.AgendaID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Deal>()
                .Property(e => e.Revision_status)
                .IsUnicode(false);

            modelBuilder.Entity<Deal>()
                .Property(e => e.Revision_comment)
                .IsUnicode(false);
        }
    }
}
