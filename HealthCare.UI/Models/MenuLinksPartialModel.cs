using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.UI.Models
{
    public class MenuLinksPartialModel
    {

        public string ULClass { get; set; }
        public string LIClass { get; set; }

        public MenuLinksPartialModel(string ulclass = "", string liclass = "")
        {
            ULClass = ulclass;
            LIClass = liclass;
        }
    }
}
