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

    public virtual DbSet<AuditoriaGeral> AuditoriaGerals { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<NotesUser> NotesUsers { get; set; }

    public virtual DbSet<Notetag> Notetags { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:senainotesdb.database.windows.net,1433;Initial Catalog=SENAI_NOTES;Persist Security Info=False;User ID=LoginSenaiNotes_Backend;Password=Senai@134;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditoriaGeral>(entity =>
        {
            entity.HasKey(e => e.IdLog).HasName("PK__Auditori__0C54DBC6C44B7389");

            entity.ToTable("AuditoriaGeral");

            entity.Property(e => e.DataAcao).HasColumnType("datetime");
            entity.Property(e => e.NomeTabela)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoAcao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.IdNote).HasName("PK__NOTE__4B2ACFF64C62CD63");

            entity.ToTable("NOTE");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).IsUnicode(false);
            entity.Property(e => e.Title).IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Notes)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__NOTE__IdUser__2EDAF651");
        });

        modelBuilder.Entity<NotesUser>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__NOTES_US__B7C9263897AE6D1F");

            entity.ToTable("NOTES_USER");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
        });

        modelBuilder.Entity<Notetag>(entity =>
        {
            entity.HasKey(e => e.IdNoteTag).HasName("PK__NOTETAG__B9937E19B39BBCD1");

            entity.ToTable("NOTETAG");

            entity.HasOne(d => d.IdNoteNavigation).WithMany(p => p.Notetags)
                .HasForeignKey(d => d.IdNote)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__NOTETAG__IdNote__3493CFA7");

            entity.HasOne(d => d.IdTagNavigation).WithMany(p => p.Notetags)
                .HasForeignKey(d => d.IdTag)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__NOTETAG__IdTag__3587F3E0");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.IdTag).HasName("PK__TAG__2BC60B0B525BDF31");

            entity.ToTable("TAG");

            entity.Property(e => e.Name).IsUnicode(false);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Tags)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__TAG__IdUser__31B762FC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
