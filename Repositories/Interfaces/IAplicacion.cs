using Practica02.DTOs;
using Practica02.Models;

namespace Practica02.Repositories.Interfaces
{
    public interface IAplicacion
    {
        
        List<Articulo> GetArticulos();
        Articulo GetArticuloById(int Id);
        void AgregarArticulo(ProductCreateDTO articulo);
        void EditarArticulo(int Id, ProductUpdateDTO articulo);
        void EliminarArticulo(int Id);
    }
}
