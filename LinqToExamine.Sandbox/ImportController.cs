using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace LinqToExamine.Sandbox
{
    public class ImportController : SurfaceController
    {
        public ActionResult Import()
        {
            FileInfo file = new FileInfo(Server.MapPath("/MOCK_DATA.csv"));
            Random random = new Random();
            using (var r = new StreamReader(file.OpenRead()))
            {
                string line = "";
                while((line = r.ReadLine()) != null)
                {
                    var data = line.Split(new[] { ',' }, StringSplitOptions.None);
                    var patient = Services.ContentService.CreateContent($"{data[0]} {data[1]}", 3083, "Patient");
                    patient.SetValue("firstName", data[0]);
                    patient.SetValue("lastName", data[1]);
                    patient.SetValue("email", data[2]);
                    patient.SetValue("gender", data[3]);
                    patient.SetValue("title", data[4]);
                    patient.SetValue("dateOfBirth", DateTime.ParseExact(data[5], "dd/MM/yyyy", CultureInfo.CurrentCulture));
                    patient.SetValue("isUKCitizen", random.Next(0, 1) == 1);
                    Services.ContentService.Save(patient, 0, false);
                }
                
            }
            return Content("Success");
        }
    }
}