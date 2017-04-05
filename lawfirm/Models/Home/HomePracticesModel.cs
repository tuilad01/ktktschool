using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawfirm.Models.Home
{
    public class HomePracticesModel
    {
        public List<Practices> ListPracticeses { get; set; }
    }

    public class Practices
    {
        public int Id { get; set; }
        /// <summary>
        /// seo url
        /// </summary>
        public string SystemName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public string ImageUrl { get; set; }
    }
}