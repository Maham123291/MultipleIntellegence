using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ModelLayer
{
    public class Modelsurveyresult
    {
       public string userid { get; set; }
        public string username { get; set; }
        public string? Category{ get; set; }
        public decimal Percentage { get; set; }


    }
}
