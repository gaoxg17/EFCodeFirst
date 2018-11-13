namespace EFCodeFirst.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Other")]
    public partial class Other
    {
        [StringLength(15)]
        public string Id { get; set; }

        [StringLength(50)]
        public string Column { get; set; }

        [StringLength(1024)]
        public string URL { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(200)]
        public string Number { get; set; }

        [StringLength(30)]
        public string PublishDate { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public string Type { get; set; }

        public DateTime? CTime { get; set; }

        [NotMapped]
        public string Test { get; set; }
    }
}
