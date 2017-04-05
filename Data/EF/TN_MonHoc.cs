namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_MonHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TN_MonHoc()
        {
            TN_CauHoi = new HashSet<TN_CauHoi>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TenMonHoc { get; set; }

        public int? LopHoc_Id { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public bool? KichHoat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_CauHoi> TN_CauHoi { get; set; }

        public virtual TN_KhoiLopHoc TN_KhoiLopHoc { get; set; }
    }
}
