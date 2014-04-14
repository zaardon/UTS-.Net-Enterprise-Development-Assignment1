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

        public DatabaseHandler()
        {
            //string pathToData = ConfigurationManager.AppSettings["DataDirectoryLocation"];
            //string dataDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathToData));
            //AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory);
        }

        public DataSet doThis()
        {

            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT DISTINCT ReportName, ConsultantName, StatusReport, Dept_type FROM ExpenseDB WHERE StatusReport = 'Approved'", connection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            connection.Close();

            return resultSet;

        }

    }
}
