using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhipoAPI.Models
{

    public class Produto
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string brand { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
    }
}
