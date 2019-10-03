using System;
using System.Collections.Generic;

namespace HealthCare.Model
{
    public partial class Translation
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
    }
}
