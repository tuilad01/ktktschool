namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_Wards
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TN_Wards()
        {
            TN_User = new HashSet<TN_User>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? DistricId { get; set; }

        public virtual TN_Districts TN_Districts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_User> TN_User { get; set; }
    }
}
