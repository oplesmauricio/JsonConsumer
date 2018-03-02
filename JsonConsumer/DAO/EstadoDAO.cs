using JsonConsumer.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JsonConsumer.DAO
{
    public class EstadoDAO
    {
        protected string StringConnection { get; } =
            ConfigurationManager.ConnectionStrings["JsonConsumer"].ConnectionString;

        public void InserirEstado(Estado estado)
        {
            try
            {
                SqlConnection conn = new SqlConnection(StringConnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERIR_ESTADO", conn);

                cmd.Parameters.AddWithValue("@Id", estado.RestResponse.result.id);
                cmd.Parameters.AddWithValue("@Country", estado.RestResponse.result.country);
                cmd.Parameters.AddWithValue("@Name", estado.RestResponse.result.name);
                cmd.Parameters.AddWithValue("@Abbr", estado.RestResponse.result.abbr);
                cmd.Parameters.AddWithValue("@Area", estado.RestResponse.result.area);
                cmd.Parameters.AddWithValue("@Largest_City", estado.RestResponse.result.largest_city);
                cmd.Parameters.AddWithValue("@Capital", estado.RestResponse.result.capital);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Estado SelecionarEstado(Estado estado)
        {
            try
            {
                SqlConnection conn = new SqlConnection(StringConnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECIONAR_ESTADO", conn);

                cmd.Parameters.AddWithValue("@Country", estado.RestResponse.result.country);
                cmd.Parameters.AddWithValue("@Abbr", estado.RestResponse.result.abbr);

                cmd.CommandType = CommandType.StoredProcedure;
                
                var leitor =  cmd.ExecuteReader();

                Estado est = new Estado();

                while (leitor.Read())
                {
                    est.RestResponse.result.id = (int)leitor[0];
                    est.RestResponse.result.country = leitor[1].ToString();
                    est.RestResponse.result.name = leitor[2].ToString();
                    est.RestResponse.result.abbr = leitor[3].ToString();
                    est.RestResponse.result.area = leitor[4].ToString();
                    est.RestResponse.result.largest_city = leitor[5].ToString();
                    est.RestResponse.result.capital = leitor[6].ToString();
                }

                return est;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}