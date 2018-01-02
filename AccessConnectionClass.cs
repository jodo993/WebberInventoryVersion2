//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.OleDb;

//namespace Webber_Inventory_Search_2017_2018
//{
//    class AccessConnectionClass
//    {
//        private OleDbConnection _connection;
//        private OleDbCommand _command;
        
//        public AccessConnectionClass()
//        {
//            _connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Webber Inventory\V4\WebberMainDatabase.accdb;Jet OLEDB:Database Password=web1234;";
//            _connection.Open();
//        }

//        public void AccessQuery(string queryString)
//        {
//            _command = new OleDbCommand(queryString, _connection);
//        }

//        public void ExecuteNonQuery()
//        {
//            _command.ExecuteNonQuery();
//        }
//    }
//}
