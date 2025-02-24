using nimap_assessment.Models;
using System.Data.SqlClient;

namespace nimap_assessment.Service
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration configuration;
        private readonly string connectionstring;
        public ProductService(IConfiguration configuration)
        {
            this.connectionstring = configuration.GetConnectionString("DefaultConnection");

        }
        public int AddProduct(Product product)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("insert into product(productname, categoryid) values(@productname,@categoryid)", con);
                cmd.Parameters.AddWithValue("@productname", product.ProductName);
                con.Open();
                return cmd.ExecuteNonQuery();

            }
        }

        public int DeleteProduct(int productid)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("delete from Product where productid=@productid", con);
                cmd.Parameters.AddWithValue("@productid", productid);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("select * from Product", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Product
                    {
                        ProductId = Convert.ToInt32(dr["productid"]),
                        ProductName = dr["productname"].ToString()
                    });
                }
                con.Close();
            }
            return list;

        }
    

        public Product GetProductById(int id)
        {
        Product prod = new Product();
        using (SqlConnection con = new SqlConnection(connectionstring))

        {
            SqlCommand cmd = new SqlCommand("select * from Product where categoryid=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                prod.CategoryId = Convert.ToInt32(dr["productid"]);
                prod.CategoryName = dr["productname"].ToString();
            }

        }
        return prod;

    }


        public int UpdateProduct(Product product)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("update Product set productname=@productname where productid=@productid", con);
                cmd.Parameters.AddWithValue("@productid", product.ProductName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }

        }
    }
}
