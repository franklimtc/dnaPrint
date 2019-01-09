namespace Site.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [Key]
        public int idUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string senha { get; set; }

        public DateTime? data { get; set; }

        public bool? status { get; set; }

        public int idGrupoUsuario { get; set; }
    }
}
