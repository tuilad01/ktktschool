namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_TinTuc
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Short { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreateAt { get; set; }

        public int? TypeId { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public virtual TN_TinTucLoai TN_TinTucLoai { get; set; }
    }
}
