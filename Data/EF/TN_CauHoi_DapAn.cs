namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TN_CauHoi_DapAn
    {
        public int Id { get; set; }

        public int CauHoi_Id { get; set; }

        public int DapAn_Id { get; set; }

        public bool IsDung { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public virtual TN_CauHoi TN_CauHoi { get; set; }

        public virtual TN_DapAn TN_DapAn { get; set; }
    }
}
