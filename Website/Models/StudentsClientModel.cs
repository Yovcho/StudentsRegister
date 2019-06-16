using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Security;

namespace Website.Models
{
    public class StudentsClientModel
    {
        public StudentService.StudentClient Service { get; set; }

        public StudentsClientModel()
        {
            this.Service = new StudentService.StudentClient();
            this.Service.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            this.Service.ClientCredentials.UserName.UserName = "acc1";
            this.Service.ClientCredentials.UserName.Password = "123";

        }
    }
}