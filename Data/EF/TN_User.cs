namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TN_User()
        {
            TN_Test = new HashSet<TN_Test>();
        }

        public int Id { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(150)]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        public string LowerUserName { get; set; }

        [Required]
        [StringLength(200)]
        public string LowerEmail { get; set; }

        public int? BirthYear { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public int? UserTypeId { get; set; }

        public int? CountryId { get; set; }

        public int? ProvinceId { get; set; }

        public int? DistrictId { get; set; }

        public int? WardId { get; set; }

        public int? JobId { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual TN_Country TN_Country { get; set; }

        public virtual TN_Districts TN_Districts { get; set; }

        public virtual TN_Job TN_Job { get; set; }

        public virtual TN_Provinces TN_Provinces { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TN_Test> TN_Test { get; set; }

        public virtual TN_UserType TN_UserType { get; set; }

        public virtual TN_Wards TN_Wards { get; set; }
    }
}
