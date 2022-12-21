using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExtensionChrome.Data.Entities
{
    public class ResponseData
    {
        public int Id { get; set; }
        public string UserName { set; get; }
        public string ProductTitle { get; set; }
        public string Url { get; set; }
        public string ProductImageSrc { get; set; }
        public string Availability { get; set; }
        public string Price { get; set; }
        public DateTime GetDate { get; set; }
        public string PageName { set; get; }
        public string Status { get; set; }
    }
}
