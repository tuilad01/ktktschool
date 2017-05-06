using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dao.News
{
    public class NewDtoResult
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public byte[] ImageId { get; set; }

        public string Short { get; set; }

        public string Detail { get; set; }

        public bool IsActive { get; set; }

        public int NewTypeId { get; set; }
    }
}
