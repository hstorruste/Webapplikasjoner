using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace DAL
{
    public class ErrorHandler
    {
        public static void logError(Exception feil)
        {
            StringBuilder err = new StringBuilder();
            err.AppendLine("Source: " + feil.Source);
            err.AppendLine("Error message: " + feil.Message);
            if(feil.InnerException != null) {
                err.AppendLine("Inner message: " + feil.InnerException.ToString());
            }
            err.AppendLine("Stack: " + feil.StackTrace);
            var filnavn = Path.Combine(HostingEnvironment.MapPath("~/Errors"), "error_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".txt");
            File.WriteAllText(filnavn, err.ToString());
        }
    }
}
