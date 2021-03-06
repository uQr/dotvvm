using System.Net;
using Microsoft.Owin;

namespace DotVVM.Framework.Hosting
{
    public class DotvvmAuthenticationHelper
    {
        /// <summary>
        /// Ensures the redirect required by the OWIN Security middleware is properly handled by DotVVM client library.
        /// </summary>
        public static void ApplyRedirectResponse(IOwinContext context, string redirectUri)
        {
            if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                DotvvmRequestContext.SetRedirectResponse(DotvvmMiddleware.ConvertHttpContext(context), redirectUri, (int)HttpStatusCode.Redirect, true);
            }
        }
    }
}