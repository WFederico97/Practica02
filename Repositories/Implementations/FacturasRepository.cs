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

        public FacturaReadDTO GetFacturaByQueries(DateTime payday, int paymentMethod)
        {
            FacturaReadDTO factura = new FacturaReadDTO();
            using (SqlConnection conn = new SqlConnection(CNN_STRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetFacturaByQueries", conn);
                cmd.Parameters.AddWithValue("@PAYDAY", payday);
                cmd.Parameters.AddWithValue("@PAYMENT_METHOD", paymentMethod);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    factura.Id = (int)reader["ID"];
                    factura.Fecha = (DateTime)reader["PAYDAY"];
                    factura.FormaPagoId = (int)reader["PAYMENT_METHOD"];
                    factura.ProductName = (string)reader["PNAME"];
                    factura.ProductPrice = (decimal)reader["PRICE"];
                    factura.ProductQty = (int)reader["QUANTITY"];
                    factura.Subtotal = (decimal)reader["SUBTOTAL"];
                }
                
            }
            return factura;
        }

        public void AgregarFactura(FacturaCreateDTO factura)
        {
            using (SqlConnection conn = new SqlConnection(CNN_STRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CreateFacturas", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PAYDAY", factura.Fecha);
                cmd.Parameters.AddWithValue("@PAYMENT_METHOD", factura.FormaPagoId);
                cmd.Parameters.AddWithValue("@CLIENT", factura.Cliente);
                cmd.ExecuteNonQuery();
            }

        }

        public void EditarFactura(int Id,FacturaUpdateDTO factura)
        {
            using(SqlConnection conn = new SqlConnection(CNN_STRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetFacturaById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DateTime fechaActual = (DateTime)reader["PAYDAY"];
                    int metodoPagoActual = (int)reader["PAYMENT_METHOD"];
                    string clienteActual = (string)reader["CLIENT"];

                    reader.Close();

                    SqlCommand updateCmd = new SqlCommand("sp_UpdateFacturas", conn);
                    updateCmd.CommandType = CommandType.StoredProcedure;
                    updateCmd.Parameters.AddWithValue("@Id", Id);

                    bool requireUpdate = false;


                    if ( factura.Fecha.HasValue && factura.Fecha != fechaActual)
                    {
                        updateCmd.Parameters.AddWithValue("@PAYDAY", factura.Fecha.Value);
                        requireUpdate = true;
                    }

                    if (factura.FormaPagoId.HasValue &&  factura.FormaPagoId != metodoPagoActual)
                    {
                        updateCmd.Parameters.AddWithValue("@PAYMENT_METHOD", factura.FormaPagoId.Value);
                        requireUpdate = true;
                    }

                    if (!string.IsNullOrEmpty(factura.Cliente) &&  factura.Cliente != clienteActual)
                    {
                        updateCmd.Parameters.AddWithValue("@CLIENT", factura.Cliente);
                        requireUpdate = true;
                    }

                    if (requireUpdate)
                    {
                        updateCmd.ExecuteNonQuery();
                    }
                }
     
            }
        }

    }
}
