using System.ComponentModel.DataAnnotations;

namespace Practica02.DTOs.Articulo
{
    public class ProductUpdateDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal PrecioUnitario { get; set; }

        public bool Activo { get; set; }
    }
}
