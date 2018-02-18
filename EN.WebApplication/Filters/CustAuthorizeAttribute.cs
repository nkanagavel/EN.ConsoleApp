using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EN.WebApplication.Utility;
using System.Web.Security;
using EN.WebApplication.DAL;
using Newtonsoft.Json;

namespace EN.WebApplication.Filters
{
    public class CustAuthorizeAttribute : AuthorizeAttribute
    {
        private bool _authendicated;
        private bool _authorized = false;
        public string _groups { get; set; }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //return base.AuthorizeCore(httpContext);
            _authendicated = base.AuthorizeCore(httpContext);
            if (_authendicated)
            {
                if (string.IsNullOrWhiteSpace(_groups))
                    return true;
                try
                {
                    var currentUserGroup = _groups.Split(',');
                    var userName = httpContext.User.Identity.Name;

                    //_authorized = IsUserMemberOfGroup(userName, currentUserGroup);
                    foreach (var role in currentUserGroup)
                    {
                        if (httpContext.User.IsInRole(role))
                            _authorized = true;

                    }
                      
                }
                catch (Exception ex)
                {
                    _authorized = false;
                    ErrorLogger.WriteToFile(ex.Message.ToString());
                }
            }

            return _authorized;
        }
        
        private bool IsUserMemberOfGroup(string username, string group)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    //var roles = authTicket.UserData.Split(',');
                    var roles = JsonConvert.DeserializeObject<UserModel>(authTicket.UserData);
                    // HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
                }
            }

            // DB Calls Go here.
            return true;
        }

    }
}