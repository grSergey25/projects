using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using System.IO;

namespace GetExchangeRate
{
    internal class myClasses
    {
        /// <summary>
        /// Получить тело web-сайта по заданному URL
        /// </summary>
        /// <param name="url">Адрес web-сайта</param>
        /// <returns>Возвращается тело сайта по заданному url</returns>
        public static string getBodyHTML(string url)
        {
            try
            {
                // Отправляем GET запрос и получаем в ответ HTML-код сайта с курсом валюты
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                StreamReader myStreamReader = new StreamReader(myHttpWebResponse.GetResponseStream());

                return myStreamReader.ReadToEnd();
            }
            catch
            {
                return "NOT FOUND";
            }
        }
    }

    class DB
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        public DB(string serv, string db, string log, string psw)
        {
            builder.DataSource = serv;
            builder.UserID = log;
            builder.Password = psw;
            builder.InitialCatalog = db;
        }

        public int execQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
