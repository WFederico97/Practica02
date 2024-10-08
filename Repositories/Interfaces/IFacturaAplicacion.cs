﻿using Practica02.DTOs.Factura;

namespace Practica02.Repositories.Interfaces
{
    public interface IFacturaAplicacion
    {
        FacturaReadDTO GetFacturaByQueries(DateTime payday, int paymentMethod);
        void AgregarFactura(FacturaCreateDTO factura);
        void EditarFactura(int Id, FacturaUpdateDTO factura);
    }
}
