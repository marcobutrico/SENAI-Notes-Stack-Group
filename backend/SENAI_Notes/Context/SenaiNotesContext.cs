using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SENAI_Notes.Models;

namespace SENAI_Notes.Context;

public partial class SenaiNotesContext : DbContext
{
    public SenaiNotesContext()
    {
    }

    public SenaiNotesContext(DbContextOptions<SenaiNotesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<NotesUser> NotesUsers { get; set; }

    public virtual DbSet<Notetag> Notetags { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-0L5VRFL\\SQLEXPRESS;Initial Catalog=SENAI_NOTES;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.IdNote).HasName("PK__NOTE__4B2ACFF672AEEE8F");

            entity.ToTable("NOTE");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).IsUnicode(false);
            entity.Property(e => e.Title).IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Notes)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__NOTE__IdUser__398D8EEE");
        });

        modelBuilder.Entity<NotesUser>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__NOTES_US__B7C926386C9C20D9");

            entity.ToTable("NOTES_USER");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
        });

        modelBuilder.Entity<Notetag>(entity =>
        {
            entity.HasKey(e => e.IdNoteTag).HasName("PK__NOTETAG__B9937E197B961E91");

            entity.ToTable("NOTETAG");

            entity.HasOne(d => d.IdNoteNavigation).WithMany(p => p.Notetags)
                .HasForeignKey(d => d.IdNote)
                .HasConstraintName("FK__NOTETAG__IdNote__3E52440B");

            entity.HasOne(d => d.IdTagNavigation).WithMany(p => p.Notetags)
                .HasForeignKey(d => d.IdTag)
                .HasConstraintName("FK__NOTETAG__IdTag__3F466844");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.IdTag).HasName("PK__TAG__2BC60B0BD158B64E");

            entity.ToTable("TAG");

            entity.Property(e => e.Name).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
