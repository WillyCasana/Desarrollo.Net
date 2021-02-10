using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Topshelf;

namespace ConsoleAppRestWinService
{


    public class WinServiceGeneric
    {
        readonly Timer _timer;
        public WinServiceGeneric()
        {
            _timer = new Timer(10000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) =>
            {

                try
                {
                    var client = new RestClient("http://ec2-3-23-113-248.us-east-2.compute.amazonaws.com:8080");
                    client.Authenticator = new HttpBasicAuthenticator("userWS", "w3bs3rv1c3!");

                    var request = new RestRequest("ingresarFactura", Method.POST);
                    var param = new facturaEnt
                    {
                        dealerID = "ASMTP",
                        leadID = "1234567890",
                        formaPago = "CONTADO",
                        tipoFactura = "FACTURA",
                        nombre = "JUAN",
                        apellido = "PEREZ",
                        documento = "20006659",
                        modelo = "RANGER",
                        version = "Diesel 4x4 At",
                        color = "AMARILLO",
                        vin = "AXT1234567890ARS1",
                        fechaFactura = "2020-12-21",
                        numeroFactura = "123456",
                        moneda = "USD",
                        valorFacturaSinImpuestos = "1000000",
                        valorFacturaConImpuestos = "190000"
                    };

                    request.AddJsonBody(param);
                    var result = client.Execute(request);
                    //IRestResponse r = client.Execute(request);
                    string cadStatus = result.StatusCode.ToString(); // OK

                    if (cadStatus != "OK")
                    {
                        WinServiceRepo.RegistrarLog(result.Content);
                    }

                }
                catch (Exception ex)
                {

                    WinServiceRepo.RegistrarLog(ex.Message);
                }

               

            };
        }
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>                                   //1
            {
                x.Service<WinServiceGeneric>(s =>                                   //2
                {
                    s.ConstructUsing(name => new WinServiceGeneric());              //3
                    s.WhenStarted(tc => tc.Start());                        //4
                    s.WhenStopped(tc => tc.Stop());                         //5
                });
                x.RunAsLocalSystem();                                       //6

                x.SetDescription("Ejemplo de uso del  Topshelf Host");                  //7
                x.SetDisplayName("WinServiceTest");                                  //8
                x.SetServiceName("WinServiceTest");                                  //9
            });                                                             //10

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());   //11
            Environment.ExitCode = exitCode;
        }
    }
}
