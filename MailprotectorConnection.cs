using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CloudPanel.Spam.Mailprotector
{
    public class MailprotectorConnection : IDisposable
    {
        private bool _disposed = false;

        protected RestClient client = null;

        public MailprotectorConnection(string url, string token)
        {
            client = new RestClient(url);
            client.Authenticator = new MailProtectorAuthenticator(token);
        }

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                client = null;
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~MailprotectorConnection()
        {
            Dispose(false);
        }

        #endregion
    }

    class MailProtectorAuthenticator : IAuthenticator
    {
        private readonly string token;

        public MailProtectorAuthenticator(string token)
        {
            this.token = token;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.Credentials = new System.Net.NetworkCredential(this.token, "X");
            request.AddHeader("AUTHENTICATION_TOKEN", this.token);
        }
    }

    static class ExtensionMethods
    {
        private static bool IsSuccess(this IRestResponse response)
        {
            return response.StatusCode.IsSuccessCode() && response.ResponseStatus == ResponseStatus.Completed;
        }

        private static bool IsSuccessCode(this HttpStatusCode code)
        {
            int responseCode = (int)code;
            return responseCode == 200 || responseCode == 201;
        }

        public static void HandleErrors(this IRestResponse response)
        {
            if (!response.IsSuccess())
            {
                if (response.StatusCode == HttpStatusCode.Forbidden)
                    throw new UnauthorizedAccessException();

                throw new Exception(response.StatusDescription);

            }
        }
    }
}
