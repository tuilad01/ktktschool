namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_TestType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TN_TestType()
        {
            TN_CauHoi = new HashSet<TN_CauHoi>();
            TN_Questions = new HashSet<TN_Questions>();
            TN_Subject = new HashSet<TN_Subject>();
            TN_Test = new HashSet<TN_Test>();
        }

        public int Id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? TypeId { get; set; }

        [StringLength(50)]
        public string ImageUrl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_CauHoi> TN_CauHoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_Questions> TN_Questions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_Subject> TN_Subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_Test> TN_Test { get; set; }

        public virtual TN_Type TN_Type { get; set; }
    }
}
