namespace ConsoleAppRestWinService
{
    internal class facturaEnt
    {
        public string dealerID { get; set; }
        public string leadID { get; set; }
        public string formaPago { get; set; }
        public string tipoFactura { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string documento { get; set; }
        public string modelo { get; set; }
        public string version { get; set; }
        public string color { get; set; }
        public string vin { get; set; }
        public string fechaFactura { get; set; }
        public string numeroFactura { get; set; }
        public string moneda { get; set; }
        public string valorFacturaSinImpuestos { get; set; }
        public string valorFacturaConImpuestos { get; set; }
    }
}