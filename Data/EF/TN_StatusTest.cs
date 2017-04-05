namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_StatusTest
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
    }
}
