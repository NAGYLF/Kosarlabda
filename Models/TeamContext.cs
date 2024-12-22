using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kosarlabda.Models;

public partial class TeamContext : DbContext
{
    public TeamContext()
    {
    }

    public TeamContext(DbContextOptions<TeamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Data> Data { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=team;user=root;password=;sslmode=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Data>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("data");

            entity.HasIndex(e => e.PlayerId, "PlayerId");

            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime");
            entity.Property(e => e.Fault)
                .HasColumnType("int(11)")
                .HasColumnName("fault");
            entity.Property(e => e.Goal)
                .HasColumnType("int(11)")
                .HasColumnName("goal");
            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.In)
                .HasColumnType("int(11)")
                .HasColumnName("In_");
            entity.Property(e => e.Out)
                .HasColumnType("int(11)")
                .HasColumnName("Out_");
            entity.Property(e => e.PlayerId).HasMaxLength(36);
            entity.Property(e => e.Try)
                .HasColumnType("int(11)")
                .HasColumnName("try");
            entity.Property(e => e.UpdatedTime).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("player");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime");
            entity.Property(e => e.Height)
                .HasColumnType("int(11)")
                .HasColumnName("height");
            entity.Property(e => e.Name).HasMaxLength(37);
            entity.Property(e => e.Weight)
                .HasColumnType("int(11)")
                .HasColumnName("weight");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
