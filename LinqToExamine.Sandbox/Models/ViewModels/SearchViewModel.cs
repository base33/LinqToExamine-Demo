using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Examine.Linq.Models;

namespace LinqToExamine.Sandbox.Models.ViewModels
{
    public class SearchViewModel
    {
        public IEnumerable<Result> Results { get; set; }
        public SearchCriteriaViewModel Criteria { get; set; }

        public SearchViewModel()
        {
            Results = new List<Result>();
            Criteria = new SearchCriteriaViewModel();
        }
    }
}