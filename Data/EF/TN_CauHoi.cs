namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_CauHoi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TN_CauHoi()
        {
            TN_CauHoi_DapAn = new HashSet<TN_CauHoi_DapAn>();
            TN_TestDetails = new HashSet<TN_TestDetails>();
        }

        public int Id { get; set; }

        [Required]
        public string TenCauHoi { get; set; }

        public int? MonHoc_Id { get; set; }

        public string GhiChu { get; set; }

        public bool? KichHoat { get; set; }

        public int? TestTypeId { get; set; }

        public int? QuestionLevelId { get; set; }

        public string A { get; set; }

        public string B { get; set; }

        public string C { get; set; }

        public string D { get; set; }

        public string E { get; set; }

        public string F { get; set; }

        public string Dung { get; set; }

        public string Sai { get; set; }

        public string CauDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_CauHoi_DapAn> TN_CauHoi_DapAn { get; set; }

        public virtual TN_MonHoc TN_MonHoc { get; set; }

        public virtual TN_QuestionLevel TN_QuestionLevel { get; set; }

        public virtual TN_TestType TN_TestType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_TestDetails> TN_TestDetails { get; set; }
    }
}
