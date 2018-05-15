using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Spreadsheet;

namespace AplicacionSIPA1.RH.Empleado
{
    /// <summary>
    /// Handler para carga de archivo
    /// </summary>
    public class FileUploadHandler : IHttpHandler
    {
        /// <summary>
        /// Procesar requerimiento
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                string fname = string.Empty;
                string imageUrl = string.Empty;
                for (int i = 0; i < files.Count; i++)
                {
                    //Guardar archivo
                    HttpPostedFile file = files[i];
                    imageUrl = "/RH/Archivos/" + DateTime.Now.Ticks.ToString() + file.FileName;
                    fname = context.Server.MapPath("~" + imageUrl);
                    file.SaveAs(fname);
                }
                //context.Response.ContentType = "text/plain";
                context.Response.ContentType = "image/jpeg";
                context.Response.Write("/RRHH" + imageUrl);
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}