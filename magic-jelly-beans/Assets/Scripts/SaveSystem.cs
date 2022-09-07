using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    [SerializeField]
    private CharacterData characterData;

    [SerializeField]
    private FloatSO stressLevelSO;

    [SerializeField]
    private StoredDataEvent updateDataBecauseOfSavedFileEvent;

    public void save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        Debug.Log(this.getPath());
        FileStream stream = new FileStream(this.getPath(), FileMode.Create); // stream of data contained in a file

        StoredData dataThatWillBeWritten = new StoredData(characterData, stressLevelSO);
        formatter.Serialize(stream, dataThatWillBeWritten); // write info
        stream.Close();
    }

    public int load()
    {
        if (existsData()) // check if file exists
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(this.getPath(), FileMode.Open); // changed to .Open because we want to open an existing file

            StoredData data = (StoredData)formatter.Deserialize(stream);
            stream.Close();
            Debug.Log("Need to send this data to update CData");
            updateDataBecauseOfSavedFileEvent.Raise(data);
            return 1;
        }
        else
        {
            Debug.LogError("Save file not found in " + this.getPath());
            return 0;
        }
    }

    public string getPath()
    {
        string path = Application.persistentDataPath + "/savedGame"; // persistentDataPath is a built-in funct from unity, it gives a path to a specific folder in the OS that you're sure that is not going to change unexpectedly 
        return path;
    }
    public bool existsData()
    {
        if (File.Exists(this.getPath()))
        {
            return true;
        }
        return false;
    }
}