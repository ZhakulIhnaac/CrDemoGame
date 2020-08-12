using Assets.Scripts.Constants;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEditorController : MonoBehaviour
{
    public static LevelEditorController Instance;
    public GameObject PlayableObjectsGroup;
    public GameObject GroundGroup;
    public GameObject LevelCamera;
    public List<GameObject> PipesList = new List<GameObject>();
    public string LevelName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        WaterDestinationControl.Victory += GameOver;
    }

    public void LoadLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
    }

    public void SaveGame()
    {
        if (LevelName == "")
        {
            Debug.LogError(GameDictionary.EnterLevelName);
            return;
        }

        if (Directory.Exists(Application.dataPath + "/Levels/" + LevelName + ".levelSave"))
        {
            Debug.LogError(GameDictionary.PathAlreadyExists);
            return;
        }

        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);
        Debug.Log("Saving With Binary Formatter: " + LevelName);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/Levels/" + LevelName +".levelSave");
        bf.Serialize(file, json);
        file.Close();
    }

    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
        Save save = (Save)bf.Deserialize(file);
        file.Close();
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save
        {
            groundGroup = GroundGroup,
            playableGroup = PlayableObjectsGroup
        };

        return save;
    }
}
