using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class FileManager
{
    public static void SaveToBinaryFile(string path, object data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        try { formatter.Serialize(stream, data); }
        catch (Exception e) { Debug.Log(e.Message); }
        finally { stream.Close(); }
    }

    public static void LoadFromBinaryFile(string path, out object data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        try { data = formatter.Deserialize(stream); }
        catch (Exception e) { Debug.Log(e.Message); data = new object(); }
        finally { stream.Close(); }
    }
}
