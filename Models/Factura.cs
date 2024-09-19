using System.ComponentModel.DataAnnotations;

namespace Practica02.Models
{
    public class Factura
    {

        public int NroFactura { get; set; }

        public DateTime Fecha { get; set; }

        public int FormaPagoId { get; set; }

        public string Cliente { get; set; }
    }
}
