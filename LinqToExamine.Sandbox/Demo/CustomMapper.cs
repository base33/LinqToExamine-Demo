using Examine;
using LinqToExamine.Sandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Examine.Linq;
using Umbraco.Web;

namespace LinqToExamine.Sandbox.Demo
{
    /// <summary>
    /// A custom mapper allows you to map the SearchResult to the model you are using to query.
    /// This is not required, but if you were using something like Ditto or Model Builder you may want to use it
    /// </summary>
    public class CustomMapper : IMapper<PatientQueryModel>
    {
        public IEnumerable<PatientQueryModel> Map(IEnumerable<SearchResult> results)
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            return results.Select(r => new PatientQueryModel(umbracoHelper.TypedContent(r.Id)));
        }
    }
}