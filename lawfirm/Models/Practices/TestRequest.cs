using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawfirm.Models.Practices
{
    public class TestRequest
    {
        /// <summary>
        /// Test type Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// lop hoc
        /// </summary>
        //public int ClassId { get; set; }

        /// <summary>
        /// Chu de
        /// </summary>
        public int SubjectId { get; set; }

        public int MonHocId { get; set; }

        /// <summary>
        /// Cap do: gioi, kha, tr.binh
        /// </summary>
        public int QuestionLevelId { get; set; }

        /// <summary>
        /// Lop hoc
        /// </summary>
        //public int LevelSchoolId { get; set; }

        /// <summary>
        /// Thoi gian
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// So luong cau hoi
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// ten bai test
        /// </summary>
        public string NameTest { get; set; }
    }
}