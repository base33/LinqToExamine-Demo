using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Examine.Linq.Attributes;
using Umbraco.Web;

namespace LinqToExamine.Sandbox.Models
{
    [NodeTypeAlias("Patient")]
    public class PatientQueryModel
    {
        [Field("firstName")]
        public string FirstName { get; set; }
        [Field("lastName")]
        public string LastName { get; set; }
        [Field("title")]
        public string Title { get; set; }
        [Field("email")]
        public string Email { get; set; }
        [Field("gender")]
        public string Gender { get; set; }
        [Field("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [Field("isUKCitizen")]
        public bool IsUKCitizen { get; set; }

        [Field("createDate")]
        public DateTime CreatedDate { get; set; }

        public PatientQueryModel()
        {

        }

        public PatientQueryModel(IPublishedContent content)
        {
            FirstName = content.GetPropertyValue<string>("firstName");
            LastName = content.GetPropertyValue<string>("lastName");
            Title = content.GetPropertyValue<string>("title");
            Gender = content.GetPropertyValue<string>("gender");
            Email = content.GetPropertyValue<string>("email");
            DateOfBirth = content.GetPropertyValue<DateTime>("dateOfBirth");
            IsUKCitizen = content.GetPropertyValue<bool>("isUKCitizen");
        }
    }
}