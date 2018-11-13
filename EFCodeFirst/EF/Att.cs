namespace EFCodeFirst.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Att
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Article_Id { get; set; }

        [StringLength(200)]
        public string ShowName { get; set; }

        [StringLength(200)]
        public string FileName { get; set; }

        public bool Grabed { get; set; }

        public DateTime? CTime { get; set; }
    }
}
