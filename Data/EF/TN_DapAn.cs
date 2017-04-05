namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_DapAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TN_DapAn()
        {
            TN_CauHoi_DapAn = new HashSet<TN_CauHoi_DapAn>();
            TN_Question_DapAn = new HashSet<TN_Question_DapAn>();
            TN_TestDetails = new HashSet<TN_TestDetails>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DapAn { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public bool? KichHoat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_CauHoi_DapAn> TN_CauHoi_DapAn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_Question_DapAn> TN_Question_DapAn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_TestDetails> TN_TestDetails { get; set; }
    }
}
