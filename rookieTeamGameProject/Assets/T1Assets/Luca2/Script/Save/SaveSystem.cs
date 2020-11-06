using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void saveLogo(LogoSystem logoSystem){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/logo.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveLogo data = new SaveLogo(logoSystem);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveLogo LoadLogo(){
        string path = Application.persistentDataPath + "/logo.save";

        if(File.Exists(path)){

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveLogo data = formatter.Deserialize(stream) as SaveLogo;
            stream.Close();

            return data;

        }else{
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

}
