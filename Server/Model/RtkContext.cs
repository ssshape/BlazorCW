using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorCW.Server.Model;

public partial class RtkContext : DbContext
{
    public RtkContext()
    {
    }

    public RtkContext(DbContextOptions<RtkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientAdress> ClientAdresses { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Sell> Sells { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Subscriber> Subscribers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SHAPE\\SQLEXPRESS;Database=RTK;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("client");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BornDate)
                .HasColumnType("date")
                .HasColumnName("born_date");
            entity.Property(e => e.Lastneme)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("lastneme");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Passport)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("passport");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("phone_number");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("sex");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.Surname)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("surname");
        });

        modelBuilder.Entity<ClientAdress>(entity =>
        {
            entity.ToTable("client_adress");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ApartmentNumber)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("apartment_number");
            entity.Property(e => e.City)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("city");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.HouseNumber)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("house_number");
            entity.Property(e => e.Street)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("street");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientAdresses)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_client_adress_client");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employees");

            entity.Property(e => e.CountOfCells).HasColumnName("countOfCells");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Position)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("position");
            entity.Property(e => e.Salary)
                .HasColumnType("money")
                .HasColumnName("salary");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("surname");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("type");
        });

        modelBuilder.Entity<Sell>(entity =>
        {
            entity.ToTable("sells");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClientAdressId).HasColumnName("client_adress_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.EmployeesId).HasColumnName("employees_id");
            entity.Property(e => e.IsConnected)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("is_connected");
            entity.Property(e => e.IsPayed)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("is_payed");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");

            entity.HasOne(d => d.ClientAdress).WithMany(p => p.Sells)
                .HasForeignKey(d => d.ClientAdressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sells_client_adress");

            entity.HasOne(d => d.Client).WithMany(p => p.Sells)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sells_client");

            entity.HasOne(d => d.Employees).WithMany(p => p.Sells)
                .HasForeignKey(d => d.EmployeesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sells_employees");

            entity.HasOne(d => d.Service).WithMany(p => p.Sells)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sells_service");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("service");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("description");
            entity.Property(e => e.IsArchive)
                .HasMaxLength(1)
                .HasColumnName("is_archive");
            entity.Property(e => e.Price)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("price");
            entity.Property(e => e.Title)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("title");
        });

        modelBuilder.Entity<Subscriber>(entity =>
        {
            entity.ToTable("subscriber");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Lastname)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
