using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Security;

namespace Website.Models
{
    public class FacultiesClientModel
    {
        public FaculctyService.FacultyClient Service { get; set; }

        public FacultiesClientModel()
        {
            this.Service = new FaculctyService.FacultyClient();
            this.Service.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            this.Service.ClientCredentials.UserName.UserName = "acc12";
            this.Service.ClientCredentials.UserName.Password = "123";

        }
    }
}