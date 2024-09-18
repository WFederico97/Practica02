using Practica02.DTOs.Factura;
using Practica02.Models;

namespace Practica02.Repositories.Interfaces
{
    public interface IFacturaAplicacion
    {
        List<Factura> GetFacturasByQueries();
        void AgregarFactura(FacturaCreateDTO factura);
        void EditarFactura(int Id, FacturaUpdateDTO factura);
    }
}
