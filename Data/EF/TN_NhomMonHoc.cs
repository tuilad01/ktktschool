namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_NhomMonHoc
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNhomMonHoc { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public bool? KichHoat { get; set; }
    }
}
