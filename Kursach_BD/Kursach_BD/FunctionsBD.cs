using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;

namespace Kursach_BD
{
    public static class FunctionsBD
    {
        static public int GetInt(string value, MySqlDataReader reader) 
        {
            List<KeyValuePair<int, string>> buff = new List<KeyValuePair<int, string>>();
            while (reader.Read())
            {
                int buff1 = reader.GetInt32(0);
                string buff2 = (string)reader.GetValue(1) + " (" + buff1.ToString() + ")";
                buff.Add(new KeyValuePair<int, string>(buff1, buff2));
            }
            foreach (var i in buff) 
            {
                if (value == i.Value) 
                {
                    reader.Close();
                    return i.Key;
                }
            }
            reader.Close();
            return 0; 
        }
    }
}
