using BL;
using Entities.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Models
{
    public class AuditAttribute : ActionFilterAttribute
    {
        public Repository<TBL_Audit> repoAudit = new Repository<TBL_Audit>();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Stores the Request in an Accessible object
            var request = filterContext.HttpContext.Request;
            // Generate an audit
            TBL_Audit audit = new TBL_Audit()
            {
                // Your Audit Identifier     
                AuditID = Guid.NewGuid(),
                // Our Username (if available)
                UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
                // The IP Address of the Request
                IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                Browser = request.Browser.Browser,

                // The URL that was accessed
                AreaAccessed = request.RawUrl,
                // Creates our Timestamp
                Timestamp = DateTime.Now
            };

            // Stores the Audit in the Database
            repoAudit.Insert(audit); 

            // Finishes executing the Action as normal 
            base.OnActionExecuting(filterContext);
        }
    }
}