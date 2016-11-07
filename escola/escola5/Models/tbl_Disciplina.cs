namespace escola5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Disciplina
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Disciplina()
        {
            tbl_Aluno = new HashSet<tbl_Aluno>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Disciplina { get; set; }

        public int? ID_Curso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Aluno> tbl_Aluno { get; set; }

        public virtual tbl_Curso tbl_Curso { get; set; }
    }
}
