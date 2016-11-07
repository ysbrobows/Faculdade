namespace escola5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Aluno
    {
        public int ID { get; set; }

        [StringLength(10)]
        public string Nome { get; set; }

        [StringLength(10)]
        public string Matricula { get; set; }

        public int? ID_Curso { get; set; }

        public virtual tbl_Disciplina tbl_Disciplina { get; set; }
    }
}
