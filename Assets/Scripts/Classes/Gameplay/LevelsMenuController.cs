using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenuController : MonoBehaviour
{
    public GameObject LevelListScrollViewContent;
    public GameObject LevelButton;
    public Save saveData = new Save();

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    private void Awake()
    {
        LoadLevelList();
    }

    public void LoadLevelList()
    {
        var levelNames = Directory.GetFiles(Application.dataPath + "/Levels/", "*.levelSave");

        foreach (var levelName in levelNames)
        {
            CreateNewLevelButton(levelName);
        }
    }

    public void CreateNewLevelButton(string levelName)
    {
        var newButton = Instantiate(LevelButton);
        var pathWords = levelName.Split('/');

        newButton.transform.Find("LevelName_Txt").GetComponent<TextMeshProUGUI>().text = pathWords[pathWords.Length-1].Split('.')[0];
        newButton.GetComponent<Button>().onClick.AddListener(() => LoadLevel(pathWords[pathWords.Length - 1].Split('.')[0]));
        newButton.transform.SetParent(LevelListScrollViewContent.transform);
    }

    public void LoadLevel(string LevelName)
    {
        //var newScene = SceneManager.CreateScene(LevelName);

        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Open(Application.dataPath + "/Levels/" + LevelName + ".levelSave", FileMode.Open);
        //Debug.Log(bf.Deserialize(file));
        //saveData = (Save)bf.Deserialize(file);
        //file.Close();

        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Open(Application.dataPath + "/Levels/" + LevelName + ".levelSave", FileMode.Open);
        saveData = JsonUtility.FromJson<Save>(File.ReadAllText(Application.dataPath + "/Levels/" + LevelName + ".levelSave", Encoding.UTF8));
        //saveData = (Save)bf.Deserialize(file);
        Debug.Log(saveData);
        //SceneManager.MoveGameObjectToScene(saveData.groundGroup, newScene);
        //SceneManager.MoveGameObjectToScene(saveData.playableGroup, newScene);
        //SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }
}
