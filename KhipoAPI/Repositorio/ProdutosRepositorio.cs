using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhipoAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace KhipoAPI.Repositorio
{
    public static class ProdutosRepositorio
    {
        public static List<Produto> All()
        {
            List<Produto> result = new List<Produto>();

            using (SqlConnection con = new SqlConnection(ConexaoBanco.ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "pr_s_produtos";
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Produto c = new Produto();
                            c.id = !string.IsNullOrEmpty(dr["id"].ToString()) ? Convert.ToInt32(dr["id"].ToString()) : 0;
                            c.name = !string.IsNullOrEmpty(dr["name"].ToString()) ? dr["name"].ToString() : string.Empty;
                            c.price = !string.IsNullOrEmpty(dr["price"].ToString()) ? Decimal.Parse(dr["price"].ToString()) : 0;
                            c.brand = !string.IsNullOrEmpty(dr["brand"].ToString()) ? dr["brand"].ToString() : string.Empty;
                            if (dr["createdAt"] != DBNull.Value) c.createdAt = DateTime.Parse(dr["createdAt"].ToString());
                            if (dr["updatedAt"] != DBNull.Value) c.updatedAt = DateTime.Parse(dr["createdAt"].ToString());

                            result.Add(c);
                        }
                    }
                }
                con.Close();
            }
            return result;
        }

        public static Produto Get(int id)
        {
            Produto result = null;

            using (SqlConnection con = new SqlConnection(ConexaoBanco.ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "pr_s_produtos_id";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Produto c = new Produto();
                            c.id = !string.IsNullOrEmpty(dr["id"].ToString()) ? Convert.ToInt32(dr["id"].ToString()) : 0;
                            c.name = !string.IsNullOrEmpty(dr["name"].ToString()) ? dr["name"].ToString() : string.Empty;
                            c.price = !string.IsNullOrEmpty(dr["price"].ToString()) ? Decimal.Parse(dr["price"].ToString()) : 0;
                            c.brand = !string.IsNullOrEmpty(dr["brand"].ToString()) ? dr["brand"].ToString() : string.Empty;
                            if (dr["createdAt"] != DBNull.Value) c.createdAt = DateTime.Parse(dr["createdAt"].ToString());
                            if (dr["updatedAt"] != DBNull.Value) c.updatedAt = DateTime.Parse(dr["createdAt"].ToString());

                            result = c;
                        }
                    }
                }
                con.Close();
            }
            return result;
        }

        public static Produto Update(Produto produto)
        {
            Produto result = new Produto();

            using (SqlConnection con = new SqlConnection(ConexaoBanco.ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "pr_u_produtos";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", produto.id);
                    cmd.Parameters.AddWithValue("@name", produto.name);
                    cmd.Parameters.AddWithValue("@price", produto.price);
                    cmd.Parameters.AddWithValue("@brand", produto.brand);
                    cmd.Parameters.AddWithValue("@updatedAt", produto.updatedAt);

                    int affectedData = cmd.ExecuteNonQuery();

                    if (affectedData > 0)
                        result = produto;
                }
            }

            return result;
        }

        public static Produto Inserir(Produto produto)
        {

            using (SqlConnection con = new SqlConnection(ConexaoBanco.ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "pr_i_produtos";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", produto.name);
                    cmd.Parameters.AddWithValue("@price", produto.price);
                    cmd.Parameters.AddWithValue("@brand", produto.brand);
                    cmd.Parameters.AddWithValue("@createdAt", produto.createdAt);

                    produto.id = int.Parse(cmd.ExecuteScalar().ToString());
                }

                con.Close();
            }

            return produto;
        }

        public static bool Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(ConexaoBanco.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    
                    cmd.CommandText = "pr_d_produtos";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0) return true;
                    else return false;

                }
                con.Close();
            }            
        }
    }
}