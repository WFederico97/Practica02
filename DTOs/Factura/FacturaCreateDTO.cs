using System.ComponentModel.DataAnnotations;

namespace Practica02.DTOs.Factura
{
    public class FacturaCreateDTO
    {
        [Required(ErrorMessage = "La fecha de factura es requerida")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El identificador de fecha de pago es obligatorio")]
        public int FormaPagoId { get; set; }
        [MaxLength(50,ErrorMessage = "El nombre del cliente no puede exceder los 50 caracteres")]
        public string Cliente { get; set; }
    }
}
