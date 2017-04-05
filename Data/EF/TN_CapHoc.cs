namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_CapHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TN_CapHoc()
        {
            TN_KhoiLopHoc = new HashSet<TN_KhoiLopHoc>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TenCap { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public bool? KichHoat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_KhoiLopHoc> TN_KhoiLopHoc { get; set; }
    }
}
