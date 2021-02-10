using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var client = new RestClient("http://ec2-3-23-113-248.us-east-2.compute.amazonaws.com:8080");
            client.Authenticator = new HttpBasicAuthenticator("userWS", "w3bs3rv1c3!");

            var request = new RestRequest("ingresarFactura", Method.POST);
            var param = new MyClass
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
            string cad = result.Content.ToString();
        }
    }
}