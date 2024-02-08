using System;
using System.Data;
using System.Data.SqlClient;

public class Program {
    static void Main(string[] args) {
        // Program.connection();
        // Program.dataAdapterWithDataSet();
        Program.dataAdapterWithDataTable();
    }

    static void connection() {
        SqlConnection conn = null;
        try {

            string cs = "data source=PMCLAP1248; database=test; user id=sa; password=PmcIndia@123";
            using(conn = new SqlConnection(cs)) {
                
                // SqlCommand cmd = new SqlCommand("select * from adoCrud", conn);
                // SqlCommand cmd = new SqlCommand("select count(id) from adoCrud", conn);
                SqlCommand cmd = new SqlCommand("insert into adoCrud(name) values ('mandip')", conn);
                SqlCommand cmd2 = new SqlCommand("select * from adoCrud", conn);
                
                conn.Open();

                int count = (int)cmd.ExecuteNonQuery();
                SqlDataReader sdr = cmd2.ExecuteReader();
                Console.WriteLine("inserted: " + count);

                while(sdr.Read()){
                    Console.WriteLine(sdr["id"] + " " + sdr["name"]);
                }
            }


        } catch(Exception e) {
            Console.WriteLine("Error occured: " + e.Message);
        } finally {
            conn.Close();
        }
    }  

    static void dataAdapterWithDataSet() {
        string cs = "data source=PMCLAP1248; database=test; user id=sa; password=PmcIndia@123";

        SqlConnection conn = null;

        try {

            using(conn = new SqlConnection(cs)) {
                SqlDataAdapter sda = new SqlDataAdapter("select * from adoCrud", conn);
                DataSet ds = new DataSet();

                sda.Fill(ds);

                foreach(DataRow row in ds.Tables[0].Rows) {
                    Console.WriteLine(row[0] + " " + row[1]);
                }
            }

        } catch(Exception e) {
            Console.WriteLine("error occured: " + e.Message);
        }
    }

    static void dataAdapterWithDataTable() {
        string cs = "data source=PMCLAP1248 database=test; user id=sa; password=PmcIndia@123";

        SqlConnection conn = null;

        try{

            using(conn = new SqlConnection(cs)){
                SqlDataAdapter sda = new SqlDataAdapter("select * from adoCrud", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach(DataRow row in dt.Rows) {
                    Console.WriteLine(row["id"] + " " + row["name"]);
                }
            }

        } catch(Exception e){
            Console.WriteLine("Error occured: " + e.Message);
        }
    }
}

