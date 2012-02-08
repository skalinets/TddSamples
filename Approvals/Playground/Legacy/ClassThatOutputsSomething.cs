using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApprovalUtilities;

namespace Playground.Legacy
{
    public class ClassThatOutputsSomething
    {
        private static Connection _connection;

        public void MethodThatProduceSomeResults(string parameterOne, int parameterTwo)
        {
            if (!IsConnectionOpened())
            {
                OpenConnection();
            }

            var connection = GetConnection();

            var value = HugeAndScarryLegacyCode.TheUgliesMethodYouMightEverSeen(parameterOne, parameterTwo, 'c');

            var query = string.Format("INSERT INTO TableName (SomeColumn) VALUES ({0})", value);
            connection.ExecuteQuery(query);
            ApprovalUtilities.SimpleLogger.Logger.Event(query);
        }

        private static Connection GetConnection()
        {
            return _connection;
        }

        private static void OpenConnection()
        {
            _connection = new Connection();
        }

        private static bool IsConnectionOpened()
        {
            return _connection != null;
        }
    }

    class DummyData
    {
        public string Value { set; get; }
    }

    class Connection
    {
        public void ExecuteQuery(string query)
        {
        }
    }
}
