using Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Helper
{
    public class SessionFecade
    {
        #region Private Constants
        //---------------------------------------------------------------------
        private const string adminAuthorisation = "AdminAuthorisation";
        //---------------------------------------------------------------------
        #endregion

        #region Public Properties
        public static Admin admin
        {
            get
            {
                return (Admin)HttpContext.Current.Session[adminAuthorisation];
            }

            set
            {
                HttpContext.Current.Session[adminAuthorisation] = value;
            }
        }
       
        #endregion
    }
}