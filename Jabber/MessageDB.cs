using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using agsXMPP;
using System.IO;
using System.Collections;
using System.Threading;
using System.Web.UI.WebControls;

using System.Web.UI;
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
                
                string insertString = @"INSERT INTO Message (Id_From, Id_To,Message_Body,Time,Message_Length,Message_Type)VALUES(@From, @Receiver, @MessageBody, @Time, @MessageLength, @MessageType)";
                SqlCommand cmd1 = new SqlCommand(insertString, conn);
                //Insert string has parameters which are set here
                
                cmd1.Parameters.AddWithValue("@From", sender_Address);
                cmd1.Parameters.AddWithValue("@Receiver", receiver_Address);
                cmd1.Parameters.AddWithValue("@MessageBody", message_Body);
                cmd1.Parameters.AddWithValue("@Time", DateTime.Now);
                cmd1.Parameters.AddWithValue("@MessageLength", message_Body.Length);
                cmd1.Parameters.AddWithValue("@MessageType", messageType);
                


                //command is executed
                cmd1.ExecuteNonQuery();
                
                
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
        public void loadMessage(string user, string contact, List<string> conversation, string path)
        {
            SqlConnection conn;
            string connectionString = ConfigurationManager.ConnectionStrings["MessageConnection"].ConnectionString;
            conn = new SqlConnection(connectionString);
            try
            {
                //Open Connection to SQL database
                conn.Open();
                string selectString = @"SELECT Id_From,Message_Body,Time FROM Message WHERE (Id_From=@user AND Id_To=@recipient) OR (Id_From=@recipient AND Id_To=@user)";
                SqlCommand cmd1 = new SqlCommand(selectString, conn);
                cmd1.Parameters.AddWithValue("@user", user);
                cmd1.Parameters.AddWithValue("@recipient", contact);
                SqlDataReader rdr = null;
                rdr = cmd1.ExecuteReader();

                //load conversation history into file
                
                
                //Only store five conversations at a time
                //Delete the oldest               
                
                if (conversation.Count <= 5)
                {
                    if (!conversation.Contains(path) == true)
                    {
                        conversation.Insert(0, path);
                    }
                }
                else
                {

                    if (!conversation.Contains(path) == true)
                    {
                        conversation.Insert(0, path);
                    }
                    File.Delete(conversation[5]);
                    conversation.RemoveAt(5);
                    
                }
                
                
                if (!File.Exists(path))
                {
                    System.Diagnostics.Debug.WriteLine("File about to be created");
                    FileStream fs = File.Create(path);
                    fs.Close();
                }
                StreamWriter sw = File.CreateText(path);
                while (rdr.Read())
                {
                    
                        sw.WriteLine(rdr[0]+ " : " + rdr[1] + "\t" + rdr[2]);
                    
                        
                    
                }
                sw.Close();
                

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