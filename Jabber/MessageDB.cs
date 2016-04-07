using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using agsXMPP;
namespace Jabber
{
    public class MessageDB
    {

        public void saveMessage(string sender_Address, string receiver_Address, string message_Body, string messageType)
        {
            SqlConnection conn;
            string connectionString = ConfigurationManager.ConnectionStrings["MessageConnection"].ConnectionString;
            conn = new SqlConnection(connectionString);
            try
            {
                //Open Connection to SQL database
                conn.Open();
                System.Diagnostics.Debug.WriteLine("connection opened");
                string insertString = @"INSERT INTO Message (Id_From, Id_To,Message_Body,Time,Message_Length,Message_Type)VALUES(@From, @Receiver, @MessageBody, @Time, @MessageLength, @MessageType)";
                SqlCommand cmd1 = new SqlCommand(insertString, conn);
                //Insert string has parameters which are set here
                System.Diagnostics.Debug.WriteLine("about to set values");
                cmd1.Parameters.AddWithValue("@From", sender_Address);
                cmd1.Parameters.AddWithValue("@Receiver", receiver_Address);
                cmd1.Parameters.AddWithValue("@MessageBody", message_Body);
                cmd1.Parameters.AddWithValue("@Time", DateTime.Now);
                cmd1.Parameters.AddWithValue("@MessageLength", message_Body.Length);
                cmd1.Parameters.AddWithValue("@MessageType", messageType);
                System.Diagnostics.Debug.WriteLine("values set");


                //command is executed
                cmd1.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("query executed");
                
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());

            }
            finally
            {
                conn.Close();
            }
        }
    }
        
}