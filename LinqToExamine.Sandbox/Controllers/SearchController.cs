using LinqToExamine.Sandbox.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Examine.Linq;
using Umbraco.Examine.Linq.Models;
using Umbraco.Examine.Linq.Extensions;
using Umbraco.Web.Mvc;

namespace LinqToExamine.Sandbox.Controllers
{
    public class SearchController : SurfaceController
    {
        const string SearchResultsKey = "FullSiteSearchResults";

        public ActionResult Render()
        {
            var model = new SearchViewModel();

            if (TempData[SearchResultsKey] != null)
                model.Results = TempData[SearchResultsKey] as IEnumerable<Result>;

            return PartialView("search/searchlist", model);
        }

        public ActionResult PerformSearch(SearchCriteriaViewModel criteria)
        {
            if (!ModelState.IsValid) return CurrentUmbracoPage();

            //get a generic result from the external index where the Name contains the query (fuzzy it!)
            var results = new Index<Result>().Where(r => r.Name.Contains(criteria.Query).Fuzzy(0.6));
            TempData[SearchResultsKey] = results.ToList();

            return CurrentUmbracoPage();
        }
    }
}