using System.ComponentModel.DataAnnotations;

namespace Practica02.DTOs.Factura
{
    public class FacturaUpdateDTO
    {
        public DateTime? Fecha { get; set; }

        public int? FormaPagoId { get; set; }

        [MaxLength(50, ErrorMessage = "El nombre del cliente no puede exceder los 50 caracteres")]
        public string Cliente { get; set; }
    }
}
