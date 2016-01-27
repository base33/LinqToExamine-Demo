using LinqToExamine.Sandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Examine.Linq;
using Umbraco.Examine.Linq.Extensions;
using Umbraco.Web.Mvc;
using Examine;
using Umbraco.Web;
using System.Diagnostics;
using Umbraco.Examine.Linq.SearchProviders;

namespace LinqToExamine.Sandbox.Controllers
{
    public class PatientsLinqController : SurfaceController
    {
        public ActionResult Render()
        {
            var searchModel = (PatientListSearchModel)TempData["patientSearchQuery"] ?? new PatientListSearchModel();

            return PartialView("PatientList", searchModel);
        }

        public ActionResult Search(PatientListSearchModel model)
        {
            TempData["patientSearchQuery"] = model;            

            return CurrentUmbracoPage();
        }
    }


    public class SearchMapper : IMapper<PatientQueryModel>
    {
        public IEnumerable<PatientQueryModel> Map(IEnumerable<SearchResult> results)
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            return results
                    .Select(r => new PatientQueryModel(umbracoHelper.TypedContent(r.Id)));
        }
    }


    #region Show Lucene Query
    public class Searcher : Umbraco.Examine.Linq.ISearcher
    {
        public string LuceneQuery { get; set; }

        public IEnumerable<SearchResult> Search(string query)
        {
            LuceneQuery = query;
            return new LuceneSearch("ExternalSearcher").Search(query);
        }
    }
    #endregion
}