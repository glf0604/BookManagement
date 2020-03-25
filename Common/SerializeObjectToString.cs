using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Introducing three namespaces
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Common
{
    public class SerializeObjectToString
    {
        //Convert Object Type objects (note: Must be serializable objects) to binary sequence strings
        public string SerializeObject(object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            string result = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                byte[] byt = new byte[stream.Length];
                byt = stream.ToArray();
                //result = Encoding.UTF8.GetString(byt, 0, byt.Length);
                result = Convert.ToBase64String(byt);
                stream.Flush();
            }
            return result;
        }
        
    }
}
