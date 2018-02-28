using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApi
{
    public class DigestAuthenticationFilterAttribute : ActionFilterAttribute
    {
        private const string AUTH_HEADER_NAME = "Authorization";
        private const string AUTH_METHOD_NAME = "Digest ";
        //private AuthenticationSettings _settings;

        //public DigestAuthenticationFilterAttribute(IOptions<AuthenticationSettings> settings)
        //{
        //    _settings = settings.Value;
        //}

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ValidateSecureChannel(context?.HttpContext?.Request);
            ValidateAuthenticationHeaders(context?.HttpContext?.Request);
            base.OnActionExecuting(context);
        }

        private void ValidateSecureChannel(HttpRequest request)
        {
            //if (_settings.RequireSSL && !request.IsHttps)
            //{
            //    throw new AuthenticationException("This service must be called using HTTPS");
            //}
        }

        private void ValidateAuthenticationHeaders(HttpRequest request)
        {
            string authHeader = GetRequestAuthorizationHeaderValue(request);
            string digest = (authHeader != null && authHeader.StartsWith(AUTH_METHOD_NAME)) ? authHeader.Substring(AUTH_METHOD_NAME.Length) : null;
            if (string.IsNullOrEmpty(digest))
            {
                throw new AuthenticationException("You must send your credentials using Authorization header");
            }
            //if (digest != CalculateSHA1($"{_settings.UserName}:{_settings.Password}"))
            //{
            //    throw new AuthenticationException("Invalid credentials");
            //}

        }

        private string GetRequestAuthorizationHeaderValue(HttpRequest request)
        {
            return request.Headers.Keys.Contains(AUTH_HEADER_NAME) ? request.Headers[AUTH_HEADER_NAME].First() : null;
        }

        public static string CalculateSHA1(string text)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Convert.ToBase64String(hash);
        }
    }
}
