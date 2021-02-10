using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using Rest;

namespace ConsoleAppRest
{
    class Program
    {
        static void Main(string[] args)
        {



            ServiceReference1.ingresarFacturaRequest obj = new ServiceReference1.ingresarFacturaRequest();

            ServiceReference1.ingresarFacturaRequest ingresarFacturaRequest;
            ingresarFacturaRequest.ingresarFactura
            //RestClient clie;


            //string data = "";
            //var url = $"http://localhost:8080/items";
            //var request = (HttpWebRequest)WebRequest.Create(url);
            //string json = $"{{\"data\":\"{data}\"}}";
            //request.Method = "POST";
            //request.ContentType = "application/json";
            //request.Accept = "application/json";


            Uri myUri = new Uri("http://ec2-3-23-113-248.us-east-2.compute.amazonaws.com:8080/ingresarFactura");
            WebRequest myWebRequest = HttpWebRequest.Create(myUri);
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;

            NetworkCredential myNetworkCredential = new NetworkCredential("userWS", "w3bs3rv1c3!");
            CredentialCache myCredentialCache = new CredentialCache();
            myCredentialCache.Add(myUri, "Basic", myNetworkCredential);

            myHttpWebRequest.PreAuthenticate = true;
            myHttpWebRequest.Credentials = myCredentialCache;
            myHttpWebRequest.Method = "POST";

            string json = "{dealerID: 'ASMTP',leadID: '1234567890', formaPago: 'CONTADO', tipoFactura: 'FACTURA', nombre: 'JUAN',apellido: 'PEREZ', documento: '20006659', modelo: 'RANGER', version: 'Diesel 4x4 At', color: 'AMARILLO', vin: 'AXT1234567890ARS1', fechaFactura: '2020-12-21', numeroFactura: '123456', moneda: 'USD', valorFacturaSinImpuestos: '1000000',valorFacturaConImpuestos: '190000'}";
            // turn our request string into a byte stream
            byte[] postBytes = Encoding.UTF8.GetBytes(json);
            // this is important - make sure you specify type this way
            myHttpWebRequest.ContentType = "application/json; charset=UTF-8";
            myHttpWebRequest.Accept = "application/json";
            myHttpWebRequest.ContentLength = postBytes.Length;
            //myHttpWebRequest.CookieContainer = Cookies;
            //myHttpWebRequest.UserAgent = currentUserAgent;
            Stream requestStream = myHttpWebRequest.GetRequestStream();

            // now send it
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();



            WebResponse myWebResponse = myWebRequest.GetResponse();

            Stream responseStream = myWebResponse.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

            string pageContent = myStreamReader.ReadToEnd();

            responseStream.Close();

            myWebResponse.Close();


            //using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            //{
            //    streamWriter.Write(json);
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //}


            //try
            //{
            //    using (WebResponse response = request.GetResponse())
            //    {
            //        using (Stream strReader = response.GetResponseStream())
            //        {
            //            if (strReader == null) return;
            //            using (StreamReader objReader = new StreamReader(strReader))
            //            {
            //                string responseBody = objReader.ReadToEnd();
            //                // Do something with responseBody
            //                Console.WriteLine(responseBody);
            //            }
            //        }
            //    }
            //}
            //catch (WebException ex)
            //{
            //    // Handle error
            //}


        }
    }
}
