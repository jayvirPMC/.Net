using System;
using System.Data;
using System.Data.SqlClient;

public class Program {
    static void Main(string[] args) {
        // Console.WriteLine("jay mataji");
        Program.connection();
    }

    static void connection() {
        string cs = "data source=PMCLAP1248;database=test;user id=sa;password=PmcIndia@123";

        SqlConnection conn = null;
        try {
            conn = new SqlConnection(cs);
            conn.Open();

            // -------------------insert data in table -------------------

            // string insertSql = "insert into adoCrud(name) values ('meet')";

            // SqlCommand cmd = new SqlCommand(insertSql, conn);

            // int isInserted = cmd.ExecuteNonQuery();
            // Console.WriteLine(isInserted);
            // Console.WriteLine("inserted success");


            // -------------------select data from table -----------------
            string selectSql = "select * from adoCrud";
            SqlCommand cmd1 = new SqlCommand(selectSql, conn);

            SqlDataReader sdr = cmd1.ExecuteReader();
            Console.WriteLine();
            while(sdr.Read()) {
                Console.WriteLine(sdr["id"] + " " + sdr["name"]);
            }



            // -------------------delete data from table ---------------
            // string deleteSql = "delete from adoCrud where id = 3";
            // SqlCommand cmd3 = new SqlCommand(deleteSql, conn);

            // int dlt = cmd3.ExecuteNonQuery();
            // Console.WriteLine(dlt);
            // Console.WriteLine("delete");




            // if(isInserted) {
            //     Console.WriteLine("inserted success");
            // } else {
            //     Console.WriteLine("inserted fail");
            // }

        } catch(Exception e) {
            Console.WriteLine(e.Message);
        } finally {
            conn.Close();
        }
    }  
}

