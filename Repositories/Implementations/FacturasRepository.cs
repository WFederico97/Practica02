using Practica02.DTOs.Factura;
using Practica02.Models;
using Practica02.Repositories.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace Practica02.Repositories.Implementations
{
    public class FacturasRepository : IFacturaAplicacion
    {
        const string CNN_STRING = "Server=FEDE_NOTE; Database= entrega_01; Integrated Security=True;";
        public List<Factura> facturas = new List<Factura>();

        public List<Factura> GetFacturasByQueries()
        {
            using (SqlConnection conn = new SqlConnection(CNN_STRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetFacturas", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    facturas.Add(new Factura
                    {
                        NroFactura = reader.GetInt32(reader.GetOrdinal("ID")),
                        Fecha = reader.GetDateTime(reader.GetOrdinal("PAYDAY")),
                        FormaPagoId = reader.GetInt32(reader.GetOrdinal("PAYMENT_METHOD")),
                        Cliente = reader.GetString(reader.GetOrdinal("CLIENT")),
                    });
                }
            }
            return facturas;
        }

        public void AgregarFactura(FacturaCreateDTO factura)
        {

        }

        public void EditarFactura(int Id,FacturaUpdateDTO factura)
        {

        }
    }
}
