namespace Site.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ArquivoImpresso")]
    public partial class ArquivoImpresso
    {
        public int id { get; set; }

        public int? Color { get; set; }

        public int? Copies { get; set; }

        public string DataType { get; set; }

        public int? Deleted { get; set; }

        public int? Deleting { get; set; }

        public string Document { get; set; }

        public string DriverName { get; set; }

        public int? InError { get; set; }

        public int? JobId { get; set; }

        public int? JobSize { get; set; }

        public int? Landscape { get; set; }

        public string MachineName { get; set; }

        public string NotifyUserName { get; set; }

        public int? Offline { get; set; }

        public int? PagesPrinted { get; set; }

        public string PaperKind { get; set; }

        public int? PaperLength { get; set; }

        public int? PaperOut { get; set; }

        public string PaperSource { get; set; }

        public int? PaperWidth { get; set; }

        public string Parameters { get; set; }

        public int? Paused { get; set; }

        public int? Position { get; set; }

        public int? Printed { get; set; }

        public string PrinterName { get; set; }

        public string PrinterResolutionKind { get; set; }

        public int? PrinterResolutionX { get; set; }

        public int? PrinterResolutionY { get; set; }

        public int? Printing { get; set; }

        public string PrintProcessorName { get; set; }

        public int? Priority { get; set; }

        public int? QueuedTime { get; set; }

        public int? Spooling { get; set; }

        public string StatusDescription { get; set; }

        public DateTime Submitted { get; set; }

        public string TimeWindow { get; set; }

        public int? TotalPages { get; set; }

        public int? UserInterventionRequired { get; set; }

        public string UserName { get; set; }

        public string server { get; set; }

        public bool? inserida { get; set; }
    }
}
