namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_Questions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TN_Questions()
        {
            TN_Question_DapAn = new HashSet<TN_Question_DapAn>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool? Active { get; set; }

        public int? TestTypeId { get; set; }

        public int? QuestionLevelId { get; set; }

        public int? SubjectId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_Question_DapAn> TN_Question_DapAn { get; set; }

        public virtual TN_QuestionLevel TN_QuestionLevel { get; set; }

        public virtual TN_Subject TN_Subject { get; set; }

        public virtual TN_TestType TN_TestType { get; set; }
    }
}
