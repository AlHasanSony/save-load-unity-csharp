using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    private string playerPrefsKey = "lastPlayedSceneIndex"; // The PlayerPrefs key for storing the last played scene index

    public void Save()
    {
        // Save the index of the current scene
        int lastPlayedSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt(playerPrefsKey, lastPlayedSceneIndex);
        PlayerPrefs.Save(); // Save changes to PlayerPrefs immediately
    }

    public void Load()
    {
        // Load the index of the last played scene from PlayerPrefs
        if (PlayerPrefs.HasKey(playerPrefsKey))
        {
            int lastPlayedSceneIndex = PlayerPrefs.GetInt(playerPrefsKey);
            // Load the last played scene
            SceneManager.LoadScene(lastPlayedSceneIndex);
        }
    }
}
