using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinqToExamine.Sandbox.Models
{
    public class PatientListSearchModel
    {
        public string Query { get; set; }
        public DateTime? DOBFrom { get; set; }
        public DateTime? DOBTo { get; set; }
        public bool UKCitizenOnly { get; set; }

        public PatientListSearchModel()
        {
            Query = "";
            DOBFrom = null;
            DOBTo = null;
            UKCitizenOnly = false;
        }
    }
}