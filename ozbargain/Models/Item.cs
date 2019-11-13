using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ozbargain.Persistance;
using SQLite;

namespace ozbargain.Models
{
    public class Item
    {
        [PrimaryKey, Indexed, Unique]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }
    }
}
