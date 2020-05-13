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
    public class PostTblDB
    {

        public string InsertData(PostTbl postTbl)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                DateTime currentTime = DateTime.Now;
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PostCommentCon"].ToString());
                SqlCommand cmd = new SqlCommand("Insertpost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", postTbl.Title);
                cmd.Parameters.AddWithValue("@CreatedDateTime", currentTime);
                cmd.Parameters.AddWithValue("@Post", postTbl.Post);
                cmd.Parameters.AddWithValue("@Author", postTbl.Author);
                cmd.Parameters.Add("@new_identity", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                string id = cmd.Parameters["@new_identity"].Value.ToString();

                result = id;

                return result;

            }
            catch(Exception r)
            {
                return result = "";
            }
            finally
            {

                con.Close();

            }

        }

        public List<PostTbl> Selectalldata()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<PostTbl> postList = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PostCommentCon"].ToString());
                SqlCommand cmd = new SqlCommand("GetAllPostAndComments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                postList = new List<PostTbl>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    PostTbl cobj = new PostTbl();

                    cobj.PostId = Convert.ToInt32(ds.Tables[0].Rows[i]["PostId"].ToString());
                    cobj.Author = ds.Tables[0].Rows[i]["Author"].ToString();
                    cobj.CreatedDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["CreatedDateTime"].ToString());
                    cobj.Post = ds.Tables[0].Rows[i]["Post"].ToString();
                    cobj.commentTbl.CommentId = Convert.ToInt32(ds.Tables[0].Rows[i]["CommentId"].ToString());
                    cobj.commentTbl.Comment = ds.Tables[0].Rows[i]["Comment"].ToString();
                    cobj.commentTbl.CreatedDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["CommentDateTime"].ToString());
                    cobj.commentTbl.CommentAuthor = ds.Tables[0].Rows[i]["CommentAuthor"].ToString();
                    cobj.commentTbl.TotalLike = Convert.ToInt32(ds.Tables[0].Rows[i]["TotalLike"].ToString());
                    cobj.commentTbl.TotalDislike = Convert.ToInt32(ds.Tables[0].Rows[i]["TotalDislike"].ToString());

                    postList.Add(cobj);

                }

                return postList;

            }
            catch (Exception r)
            {

                return postList;

            }
            finally
            {

                con.Close();

            }

        }
    }
}