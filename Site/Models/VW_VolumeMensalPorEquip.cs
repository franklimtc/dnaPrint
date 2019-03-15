namespace Site.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_VolumeMensalPorEquip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long? idVolumeMensal { get; set; }

        public string Modelo { get; set; }

        public int ano { get; set; }

        public int? jan { get; set; }

        public int? fev { get; set; }

        public int? mar { get; set; }

        public int? abr { get; set; }

        public int? mai { get; set; }

        public int? jun { get; set; }

        public int? jul { get; set; }

        public int? ago { get; set; }

        public int? set { get; set; }

        [Column("out")]
        public int? _out { get; set; }

        public int? nov { get; set; }

        public int? dez { get; set; }

        public int? Total { get; set; }
    }
}