using System;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlueConsultingManagementSystemLogic
{
    public class DatabaseHandler
    {
        private SqlConnection SQLConnection;
        public DatabaseHandler()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var con = new SqlConnection(connectionString);
            //string pathToData = ConfigurationManager.AppSettings["DataDirectoryLocation"];
            //string dataDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathToData));
            //AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory);
            this.SQLConnection = con;
        }

        public DataSet doThis()
        {

           
            var selectCommand = new SqlCommand("SELECT DISTINCT ReportName, ConsultantName, StatusReport, Dept_type FROM ExpenseDB WHERE StatusReport = 'Approved'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            SQLConnection.Close();

            return resultSet;

        }

    }
}
