﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Collections.Concurrent;
using _58HouseSearch.Core.Models;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net.Http.Headers;

namespace _58HouseSearch.Core
{
    public class HTTPHelper
    {

        public static string GetHTMLByURL(string Url, string type = "UTF-8")
        {
            try
            {
                Url = Url.ToLower();

                System.Net.WebRequest wRequest = System.Net.WebRequest.Create(Url);
                wRequest.ContentType = "text/html; charset=utf-8";
                
                wRequest.Method = "get";
                wRequest.UseDefaultCredentials = true;
                // Get the response instance.
                var task = wRequest.GetResponseAsync();
                System.Net.WebResponse wResp = task.Result;
                System.IO.Stream respStream = wResp.GetResponseStream();
                using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream, Encoding.GetEncoding(type)))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return string.Empty;
            }

        }


        public static string GetHTML(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "4.0"));
                client.DefaultRequestHeaders.ExpectContinue = true;
                var task = client.GetStringAsync(url);
                return task.Result; 
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return string.Empty;
            }
        }
       
    }


}