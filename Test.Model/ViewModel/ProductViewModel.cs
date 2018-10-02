using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Test.Model
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CreatedDate { get; set; }


        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
