using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarshTestUserApp
{
    public sealed class Logger
    {
        //private static Logger _instance;
        private static readonly object obj = new object();
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

        private Logger()
        {
        }
        public static Logger GetInstance
        {
            get
            {
                //if (_instance == null)
                //{
                //    lock (obj)
                //    {
                //        if (_instance == null)
                //        {
                //            _instance = new Logger();
                //        }
                //    }
                //}

                return _instance.Value;
            }
        }



        public void WriteToFileOrSendEmail(Exception ex)
        {
            // do something
        }
    }
}