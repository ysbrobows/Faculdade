namespace escola5.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class modelo : DbContext
    {
        public modelo()
            : base("name=modelo")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbl_Aluno> tbl_Aluno { get; set; }
        public virtual DbSet<tbl_Curso> tbl_Curso { get; set; }
        public virtual DbSet<tbl_Disciplina> tbl_Disciplina { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Aluno>()
                .Property(e => e.Nome)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Aluno>()
                .Property(e => e.Matricula)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Curso>()
                .HasMany(e => e.tbl_Disciplina)
                .WithOptional(e => e.tbl_Curso)
                .HasForeignKey(e => e.ID_Curso);

            modelBuilder.Entity<tbl_Disciplina>()
                .HasMany(e => e.tbl_Aluno)
                .WithOptional(e => e.tbl_Disciplina)
                .HasForeignKey(e => e.ID_Curso);
        }
    }
}
