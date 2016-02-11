using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinqToExamine.Sandbox.Models.ViewModels
{
    public class SearchCriteriaViewModel
    {
        [Required]
        public string Query { get; set; }

        public SearchCriteriaViewModel()
        {
            Query = "";
        }
    }
}