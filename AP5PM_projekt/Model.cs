using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace AP5PM_projekt
{
    //model s propertami pro výsledky vyhledávání
    class Model
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Image_URL { get; set; }
        public string Type { get; set; }
    }

    //model s propertami pro detail knihy
    class ModelDetail
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Image_URL { get; set; }
        public string Type { get; set; }

        public string Authors { get; set; }
        public string Synopsis { get; set; }
        public string Genre { get; set; }

    }
}
