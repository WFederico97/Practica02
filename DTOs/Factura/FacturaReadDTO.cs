namespace Practica02.DTOs.Factura
{
    public class FacturaReadDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int FormaPagoId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQty { get; set; }
        public decimal Subtotal { get; set; }
    }
}
