using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEditorController : MonoBehaviour
{
    public static LevelEditorController Instance;
    public GameObject PlayableObjectsGroup;
    public GameObject LevelName;
    public GameObject GroundGroup;

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
    
    //public void ExportLevelAsNewScene()
    //{
    //    var NewScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
    //    NewScene.name = LevelName.GetComponent<TextMeshProUGUI>().text;

    //    // Moving game objects to new scene
    //    SceneManager.MoveGameObjectToScene(PlayableObjectsGroup, NewScene);

    //    var pathToSave = EditorSceneManager.GetActiveScene().path.Split(char.Parse("/"));
    //    pathToSave[pathToSave.Length - 1] = NewScene.name + ".unity"; 
    //    bool isSaved = EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(), string.Join("/", pathToSave));

    //    if (isSaved)
    //    {
    //        Debug.Log("Kaydedildi");
    //    }
    //    else
    //    {
    //        Debug.Log("Kaydedilemedi");
    //    }

    //}
}
