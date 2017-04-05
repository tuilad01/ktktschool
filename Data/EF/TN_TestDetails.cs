namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_TestDetails
    {
        public int Id { get; set; }

        public int? TestId { get; set; }

        public int? CauHoiId { get; set; }

        public int? DapAnId { get; set; }

        public bool? IsDung { get; set; }

        public virtual TN_CauHoi TN_CauHoi { get; set; }

        public virtual TN_DapAn TN_DapAn { get; set; }

        public virtual TN_Test TN_Test { get; set; }
    }
}
