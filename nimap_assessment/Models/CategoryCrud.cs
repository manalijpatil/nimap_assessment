using System.Data.SqlClient;

namespace nimap_assessment.Models
{
    public class CategoryCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public CategoryCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        //get all Category list
        public List<Category>GetCategories()
        {
            List<Category> list = new List<Category>();
            cmd = new SqlCommand("select * from Category", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Category category = new Category();
                    category.CategoryId = Convert.ToInt32(dr["categoryid"]);
                    category.CategoryName = dr["categoryname"].ToString();
                    list.Add(category);
                }
            }
            con.Close();
            return list;
        }
        //Add category
        public int  AddCategory(Category category)
        {
            int result = 0;
            string qry = "insert into Category values(@categoryname)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@categoryname", category.CategoryName);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //get category by id
        public Category GetCategoryById(int categoryId)
        {
            Category category = new Category();
            cmd = new SqlCommand("select * from Category where categoryid=@categoryId", con);
            cmd.Parameters.AddWithValue("@categoryId", categoryId);
            con.Open();
            dr =cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    category.CategoryId = Convert.ToInt32(dr["categoryid"]);
                    category.CategoryName = dr["categoryname"].ToString();
                }

            }
            con.Close();
            return category;
        }
        //update category
        public int UpdateCategory(Category category)
        {
            int result = 0;
            string qry = "update Category set categoryname=@categoryname where categoryid=@categoryid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@categoryid", category.CategoryName);
            con.Open();
            result= cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //Delete category
        public int DeleteCategory(int categoryId)
        {
            int result = 0;
            string qry = "delete from Category where categoryid =@categoryid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@categoryid", categoryId);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
       
    }
}
