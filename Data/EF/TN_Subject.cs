namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_Subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TN_Subject()
        {
            TN_Questions = new HashSet<TN_Questions>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? TestTypeId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_Questions> TN_Questions { get; set; }

        public virtual TN_TestType TN_TestType { get; set; }
    }
}
