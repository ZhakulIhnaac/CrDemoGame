using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenuController : MonoBehaviour
{
    public EditorBuildSettingsScene[] LevelList;
    public GameObject LevelListScrollViewContent;
    public GameObject LevelButton;

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
        LevelList = EditorBuildSettings.scenes;

        foreach (var level in LevelList)
        {
            CreateNewLevelButton(level);
        }
    }

    public void CreateNewLevelButton(EditorBuildSettingsScene scene)
    {
        var newButton = Instantiate(LevelButton);

        var pathWords = scene.path.Split('/');

        newButton.transform.Find("LevelName_Txt").GetComponent<TextMeshProUGUI>().text = pathWords[pathWords.Length-1].Split('.')[0];
        newButton.GetComponent<Button>().onClick.AddListener(() => LoadLevel(pathWords[pathWords.Length - 1].Split('.')[0]));
        newButton.transform.SetParent(LevelListScrollViewContent.transform);
    }

    public void LoadLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }
}
