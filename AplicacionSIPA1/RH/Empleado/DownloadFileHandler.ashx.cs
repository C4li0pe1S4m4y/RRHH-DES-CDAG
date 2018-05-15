using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AplicacionSIPA1.RH.Empleado
{
    /// <summary>
    /// Handler de descarga de archivo.
    /// </summary>
    public class DownloadFileHandler : IHttpHandler
    {
        /// <summary>
        /// Procesar 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            string url = "";

            // obtener el archivo del query string
            if (context.Request.QueryString["FileName"] != null)
            {
                url = "" + context.Request.QueryString["FileName"].ToString();
            }

            string filename = "";
            filename = context.Request.QueryString["FileName"].ToString();


            try
            {

                context.Response.Clear();
                context.Response.ClearContent();

                //context.Response.AddHeader("Content-Disposition", "attachment;filename=\"" + fileInfo.Name + "\"");
                context.Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                //context.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                //context.Response.ContentType = "application/octet-stream";
                context.Response.ContentType = "text/plain";
                //context.Response.TransmitFile(fileInfo.FullName);
                context.Response.TransmitFile(url);
                context.Response.Flush();
                //  }
                // else
                // {
                //     throw new Exception("File not found");
                // }
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write(ex.Message);
            }
            finally
            {
                context.Response.End();
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