using Examine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Examine.Linq.SearchProviders;

namespace LinqToExamine.Sandbox.Demo
{
    /// <summary>
    /// A custom searcher allows you to perform the lucene query yourself.  You may have your own lucene search provider that you want to use.
    /// </summary>
    public class CustomSearcher : Umbraco.Examine.Linq.ISearcher
    {
        public string LuceneQuery { get; set; }

        public IEnumerable<SearchResult> Search(string query)
        {
            LuceneQuery = query;
            return new LuceneSearch("ExternalSearcher").Search(query);
        }
    }
}