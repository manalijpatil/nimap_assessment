using nimap_assessment.Models;
using System.Data.SqlClient;

namespace nimap_assessment.Service
{
    public class CategoryService : ICategoryService
    {

    
        private readonly IConfiguration configuration;
        private readonly string connectionstring;


        public CategoryService(IConfiguration configuration)
        {
            
           
            this.connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        public int AddCategory(Category category)
        {
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("insert into Category values(@categoryname)",con);
                cmd.Parameters.AddWithValue("@categoryname", category.CategoryName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteCategory(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("sp_del_category",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@categoryid", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Category> GetAllCaterories()
        {
            List<Category> list = new List<Category>();
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("select * from category", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Category
                    {
                        CategoryId = Convert.ToInt32(dr["categoryid"]),
                        CategoryName = dr["categoryname"].ToString()
                    });
                }
                con.Close();
            }
            return list;
        }

        public Category GetCategoryById(int categoryId)
        {
            Category category = new Category();
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("select * from Category where categoryid=@categoryId", con);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    category.CategoryId = Convert.ToInt32(dr["categoryid"]);
                    category.CategoryName = dr["categoryname"].ToString();
                }
               
            }
            return category;
        }

        public int UpdateCategory(Category category)
        {
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("update Category set categoryname=@categoryname where categoryid=@categoryid",con);
                cmd.Parameters.AddWithValue("@categoryid", category.CategoryName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
