namespace AllPlatformsSave
{
#if JSONSerializationPlayerPrefs
using UnityEngine;
using UnityEngine.Events;

public class JSONSerializationPlayerPrefs : ISaveClass
{

    public void Save<T>(T dataToSave, string path, UnityAction<SaveResult, string> CompleteMethod, bool encrypted) where T : class, new()
    {
        byte[] bytes = BinarySerializationUtility.GetBytes(JsonUtility.ToJson(dataToSave));

        if (encrypted)
        {
            BinarySerializationUtility.EncryptData(ref bytes);
        }
        string serializedData = ConvertToString(bytes);
        PlayerPrefs.SetString(path, serializedData);
        if (CompleteMethod != null)
        {
            CompleteMethod(SaveResult.Success, "");
        }
    }


    public void Load<T>(string path, UnityAction<T, SaveResult, string> LoadCompleteMethod, bool encrypted) where T : class, new()
    {
        byte[] bytes = ReadFromPlayerPrefs<T>(path);

        if (bytes != null)
        {
            if (encrypted)
            {
                BinarySerializationUtility.DecryptData(ref bytes);
            }
            LoadCompleteMethod(JsonUtility.FromJson<T>(BinarySerializationUtility.GetString(bytes)), SaveResult.Success,"");
            return;
        }
        LoadCompleteMethod(new T(), SaveResult.Success, "File Was Created");
    }


    public void ClearFile(string path)
    {
        if (PlayerPrefs.HasKey(path))
        {
            PlayerPrefs.DeleteKey(path);
        }
        else
        {
            Debug.Log(path + " does not exist");
        }
    }


    public void ClearAllData(string path)
    {
        PlayerPrefs.DeleteAll();
    }


    byte[] ReadFromPlayerPrefs<T>(string fileName) where T : class, new()
    {
        if (!PlayerPrefs.HasKey(fileName))
        {
            Debug.Log(fileName + " does not exist-> set default value");
        }
        else
        {
            string serializedData = PlayerPrefs.GetString(fileName);
            return ConvertToBytes(serializedData);
        }
        return null;
    }


    string ConvertToString(byte[] bytes)
    {
        return System.Convert.ToBase64String(bytes);
    }


    byte[] ConvertToBytes(string content)
    {
        return System.Convert.FromBase64String(content);
    }


}
#endif
}
