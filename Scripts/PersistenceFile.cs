using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class PersistenceFile
{
    public static void Save<T>(T data, string filename) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = $"{Application.persistentDataPath}/{filename}.save";
        Debug.Log(path);

        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static T Load<T>(string filename)
    {
        string path = $"{Application.persistentDataPath}/{filename}.save";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            var data = (T) formatter.Deserialize(stream);
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file not found int " + path);
            return default(T);
        }
    }
}
