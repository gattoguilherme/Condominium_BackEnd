using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumContext.Shared.Entities
{
    public class AppSettings
    {
        private Jwt _Jwt = null;
        public Jwt Jwt
        {
            get { return this._Jwt; }

            set { if (_Jwt == null) _Jwt = value; }
        }

        private ConnectionStrings _ConnectionStrings = null;
        public ConnectionStrings ConnectionStrings
        {
            get { return this._ConnectionStrings; }
            set { if (_ConnectionStrings == null) _ConnectionStrings = value; }
        }



        private static AppSettings _instance = null;
        private static readonly object SyncObj = new object();
        private AppSettings()
        {

        }

        public static AppSettings GetInstace()
        {
            if (_instance != null) return _instance;

            lock (SyncObj)
            {
                if (_instance == null)
                {
                    _instance = new AppSettings();
                }
            }

            return _instance;
        }
    }

    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
}
