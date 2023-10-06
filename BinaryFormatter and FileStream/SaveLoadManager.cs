using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager : MonoBehaviour
{
    private string saveFileName = "lastPlayedScene.dat"; // The name of the save file
    private int lastPlayedSceneIndex; // The index of the last played scene

    public void Save()
    {
        // Save the index of the current scene
        lastPlayedSceneIndex = SceneManager.GetActiveScene().buildIndex;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveFileName);
        bf.Serialize(file, lastPlayedSceneIndex);
        file.Close();
    }

    public void Load()
    {
        // Load the index of the last played scene from the save file
        if (File.Exists(Application.persistentDataPath + "/" + saveFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveFileName, FileMode.Open);
            lastPlayedSceneIndex = (int)bf.Deserialize(file);
            file.Close();
            // Load the last played scene
            SceneManager.LoadScene(lastPlayedSceneIndex);
        }
    }
}
