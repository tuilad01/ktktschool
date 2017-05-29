namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_Test
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TN_Test()
        {
            TN_TestDetails = new HashSet<TN_TestDetails>();
        }

        public int Id { get; set; }

        public int? UserId { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? TestTypeId { get; set; }

        public int? QuestionLevelId { get; set; }

        public int? TotalQuestion { get; set; }

        public int? TotalRigth { get; set; }
       
        public string Description { get; set; }

        public int? ResultId { get; set; }

        public int? StatusTestId { get; set; }

        public virtual TN_QuestionLevel TN_QuestionLevel { get; set; }

        public virtual TN_Result TN_Result { get; set; }

        public virtual TN_TestType TN_TestType { get; set; }

        public virtual TN_User TN_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_TestDetails> TN_TestDetails { get; set; }
    }
}
