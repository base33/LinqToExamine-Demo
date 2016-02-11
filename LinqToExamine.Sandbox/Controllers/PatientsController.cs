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
    public class PatientsController : SurfaceController
    {
        public ActionResult Render()
        {
            var searchModel = (PatientListSearchModel)TempData["patientSearchQuery"] ?? new PatientListSearchModel();

            return PartialView("Patients/PatientList", searchModel);
        }

        public ActionResult Search(PatientListSearchModel model)
        {
            TempData["patientSearchQuery"] = model;            

            return CurrentUmbracoPage();
        }
    }
}