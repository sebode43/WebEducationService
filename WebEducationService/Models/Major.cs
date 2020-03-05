using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEducationService.Models {
    public class Major {

        public int ID { get; set; }
        public string Description { get; set; }
        public int MinSat { get; set; }

        public Major() {}
    }
}
