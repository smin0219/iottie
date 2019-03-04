﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iottie.Controllers
{
    public class FileUploadController : Controller
    {
        public ActionResult UploadFiles()
        {
            if (Request.Files["file"] != null)
            {
                HttpPostedFileBase MyFile = Request.Files["file"];

                // Setting location to upload files
                string TargetLocation = Server.MapPath("~/Files/");

                try
                {
                    if (MyFile.ContentLength > 0)
                    {
                        // Get File Extension
                        string Extension = Path.GetExtension(MyFile.FileName);

                        // Determining file name. You can format it as you wish.
                        string FileName = Path.GetFileName(MyFile.FileName);
                        FileName = Guid.NewGuid().ToString().Substring(0, 8);

                        // Determining file size.
                        int FileSize = MyFile.ContentLength;

                        // Creating a byte array corresponding to file size.
                        byte[] FileByteArray = new byte[FileSize];

                        // Basic validation for file extension
                        string[] AllowedExtension = { ".txt", ".pdf", ".doc", ".json", ".html" };
                        string[] AllowedMimeType = { "text/plain", "application/msword", "application/x-pdf", "application/pdf", "application/json", "text/html" };

                        if (AllowedExtension.Contains(Extension) && AllowedMimeType.Contains(MimeMapping.GetMimeMapping(MyFile.FileName)))
                        {
                            // Posted file is being pushed into byte array.
                            MyFile.InputStream.Read(FileByteArray, 0, FileSize);

                            // Uploading properly formatted file to server.
                            MyFile.SaveAs(TargetLocation + FileName + Extension);
                            string json = "";
                            Hashtable resp = new Hashtable();
                            string urlPath = MapURL(TargetLocation) + FileName + Extension;

                            // Make the response an json object
                            resp.Add("link", urlPath);
                            json = JsonConvert.SerializeObject(resp);

                            // Clear and send the response back to the browser.
                            Response.Clear();
                            Response.ContentType = "application/json; charset=utf-8";
                            Response.Write(json);
                            Response.End();
                        }
                        else
                        {
                            // Handle validation errors
                        }
                    }
                }

                catch (Exception ex)
                {
                    // Handle errors
                }
            }
            return View();
        }

        // Convert file path to url
        // http://stackoverflow.com/questions/16007/how-do-i-convert-a-file-path-to-a-url-in-asp-net
        private string MapURL(string path)
        {
            string appPath = Server.MapPath("/").ToLower();
            return string.Format("/{0}", path.ToLower().Replace(appPath, "").Replace(@"\", "/"));
        }
    }
}