using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureDocxWeb
{
    class Functions
    {
        private SqlConnection Sc;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter da;
        private string Str;
        public Functions()
        {
            Str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vaibh\OneDrive\Documents\UserInformation.mdf;Integrated Security=True;Connect Timeout=30";
            Sc=new SqlConnection(Str);
            Cmd = new SqlCommand();
            Cmd.Connection= Sc;

        }

        public DataTable GetData(string Query)
        {
            dt= new DataTable();
            da= new SqlDataAdapter(Query,Str);
            da.Fill(dt);
            return dt;
        }

        public int SetData(string Query)
        {
            int count = 0;
            if(Sc.State==ConnectionState.Closed)
            {
                Sc.Open();
            }
            Cmd.CommandText=Query;
            count=Cmd.ExecuteNonQuery();
            return count;
        }

    }
}
