using PostCommect.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PostCommect.DBAccess
{
    public class CommentDB
    {
        public string InsertData(CommentTbl comTbl)
        {

            SqlConnection con = null;

            string result = "";
            try

            {
                DateTime currentTime = DateTime.Now;

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PostCommentCon"].ToString());

                SqlCommand cmd = new SqlCommand("InsertComment", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PostId", comTbl.PostId);

                cmd.Parameters.AddWithValue("@CreatedDateTime", currentTime);

                cmd.Parameters.AddWithValue("@Author", comTbl.Author);

                cmd.Parameters.AddWithValue("@TotalLike", comTbl.TotalLike);
                cmd.Parameters.AddWithValue("@TotalDislike", comTbl.TotalDislike);
                cmd.Parameters.AddWithValue("@Comment", comTbl.Comment);

                cmd.Parameters.Add("@new_identity", SqlDbType.Int).Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                string id = cmd.Parameters["@new_identity"].Value.ToString();

                result = id;

                return result;

            }

            catch (Exception r)
            {

                return result = "";

            }
            finally
            {

                con.Close();

            }

        }
    }
}