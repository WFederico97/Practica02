using Practica02.DTOs.Articulo;
using Practica02.Models;
using Practica02.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Practica02.Repositories.Implementations
{
    public class ArticuloRepository : IArticuloAplicacion
    {
        const string CNN_STRING = "Server=FEDE_NOTE; Database= entrega_01; Integrated Security=True;";
        public List<Articulo> articulos = new List<Articulo>();

        public List<Articulo> GetArticulos()
        {
            using (SqlConnection conn = new SqlConnection(CNN_STRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    articulos.Add(new Articulo
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("ID")),
                        Nombre = reader.GetString(reader.GetOrdinal("PNAME")),
                        PrecioUnitario = reader.GetDecimal(reader.GetOrdinal("PRICE")),
                        Activo = reader.GetBoolean(reader.GetOrdinal("AVAILABLE"))
                    });
                }
            }
            return articulos;
        }

        public Articulo GetArticuloById(int Id)
        {
            Articulo articulo = new Articulo();
            using (SqlConnection conn = new SqlConnection(CNN_STRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetProductById", conn);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    articulo.Id = (int)reader["Id"];
                    articulo.Nombre = (string)reader["PNAME"];
                    articulo.PrecioUnitario = (decimal)reader["PRICE"];
                    articulo.Activo = (bool)reader["AVAILABLE"];
                }

            }
            return articulo;
        }

        public void AgregarArticulo(ProductCreateDTO articulo)
        {
            using (SqlConnection conn = new SqlConnection(CNN_STRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_AddProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", articulo.Nombre);
                cmd.Parameters.AddWithValue("@Price", articulo.PrecioUnitario);
                cmd.Parameters.AddWithValue("@Available", articulo.Activo);
                int affectedRows = cmd.ExecuteNonQuery();
            }
        }
        public void EditarArticulo(int Id, ProductUpdateDTO articulo)
        {
            using (SqlConnection conn = new SqlConnection(CNN_STRING))
            {
                conn.Open();

                SqlCommand selectCmd = new SqlCommand("sp_GetProductById", conn);
                selectCmd.CommandType = CommandType.StoredProcedure;
                selectCmd.Parameters.AddWithValue("@Id", Id);
                SqlDataReader reader = selectCmd.ExecuteReader();

                if (reader.Read())
                {
                   
                    string nombreActual = reader["PNAME"].ToString();
                    decimal precioActual = (decimal)reader["PRICE"];
                    bool disponibleActual = (bool)reader["AVAILABLE"];

                    reader.Close(); 

                    
                    SqlCommand updateCmd = new SqlCommand("sp_UpdateProduct", conn);
                    updateCmd.CommandType = CommandType.StoredProcedure;
                    updateCmd.Parameters.AddWithValue("@Id", Id);

                    bool requireUpdate = false;

                    
                    if (articulo.Nombre != null && articulo.Nombre != nombreActual)
                    {
                        updateCmd.Parameters.AddWithValue("@ProductName", articulo.Nombre);
                        requireUpdate = true;
                    }

                    if (articulo.PrecioUnitario != precioActual)
                    {
                        updateCmd.Parameters.AddWithValue("@Price", articulo.PrecioUnitario);
                        requireUpdate = true;
                    }

                    if (articulo.Activo != disponibleActual)
                    {
                        updateCmd.Parameters.AddWithValue("@Available", articulo.Activo);
                        requireUpdate = true;
                    }

                    if (requireUpdate)
                    {
                        updateCmd.ExecuteNonQuery();
                    }
                }
            }
            
        }

        public void EliminarArticulo(int Id)
        {
            using (SqlConnection conn = new SqlConnection(CNN_STRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                int affectedRows = cmd.ExecuteNonQuery();
            }
        }
    }
}
