using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager
{
    public class FtpReader

    {
        private string pass;
        private string login;
        private string uri;
        private int buffsize = 1024;

        public bool passive = true;
        public bool binary = true;
        public bool enableSsl = false;
        public bool hash = false;

        public FtpReader(string uri, string pass, string login)
        {
            this.uri = uri;
            this.login = login;
            this.pass = pass;
        }

        public string WorkingDirectory(string path)
        {
            uri = Combine(uri, path);

        }


        private FtpWebRequest createRequest(string method)
        {
            return createRequest(uri, method);
        }

        private FtpWebRequest createRequest(string uri, string method)
        {
            var r = (FtpWebRequest) WebRequest.Create(uri);

            r.Credentials = new NetworkCredential(login, pass);
            r.Method = method;
            r.UseBinary = binary;
            r.EnableSsl = enableSsl;
            r.UsePassive = passive;

            return r;
        }

        public string PrintWorkingDirectory()
        {
            var request = createRequest(WebRequestMethods.Ftp.PrintWorkingDirectory);
            return getStatusDescription(request);
        }

        string Combine(string path1, string path2)
        {
            return Path.Combine(path1, path2).Replace("\\", "/");
        }




    }
}
