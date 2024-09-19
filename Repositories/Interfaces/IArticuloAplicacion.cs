using Practica02.DTOs.Articulo;
using Practica02.Models;

namespace Practica02.Repositories.Interfaces
{
    public interface IArticuloAplicacion
    {
        
        List<Articulo> GetArticulos();
        Articulo GetArticuloById(int Id);
        void AgregarArticulo(ProductCreateDTO articulo);
        void EditarArticulo(int Id, ProductUpdateDTO articulo);
        void EliminarArticulo(int Id);

    }
}
