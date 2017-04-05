namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_KhoiLopHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TN_KhoiLopHoc()
        {
            TN_MonHoc = new HashSet<TN_MonHoc>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TenKhoiLop { get; set; }

        public int? CapHoc_Id { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public virtual TN_CapHoc TN_CapHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_MonHoc> TN_MonHoc { get; set; }
    }
}
