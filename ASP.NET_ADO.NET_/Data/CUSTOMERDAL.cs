using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ASP.NET_ADO.NET_;
using System.Data;

namespace ADONETCORE.DataLayer
{
    public class CustomerDAL
    {
        public string cnn = "";
        public CustomerDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath
              (Directory.GetCurrentDirectory()).
              AddJsonFile("appsettings.json").Build();

            cnn = builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
        public List<Customers> GetAllCustomers()
        {
            List<Customers> ListOfCustomers = new List<Customers>();
            using (SqlConnection cn = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllCustomers", cn))
                {
                    if (cn.State == System.Data.ConnectionState.Closed)
                        cn.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListOfCustomers.Add(new Customers()
                        {
                            CustomerId = int.Parse(reader["CustomerId"].ToString()),
                            CustomerName = reader["CustomerName"].ToString(),
                            EmailAddress = reader["Mobile"].ToString(),
                            Mobile = reader["Mobile"].ToString(),
                        });
                    }
                    return ListOfCustomers;
                }
            }

            }

        }
    }