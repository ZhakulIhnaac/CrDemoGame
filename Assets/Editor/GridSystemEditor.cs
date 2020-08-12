using Assets.Scripts.Classes.Gameplay;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridSystem))]
public class GridSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GridSystem gridSystem = (GridSystem)target;

        if (GUILayout.Button("Add Grid"))
        {
            gridSystem.CreateGrid();
        }
    }




    public void ExportLevelAsNewScene(GameObject PlayableObjectsGroup, GameObject GroundGroup, GameObject LevelName)
    {
        
    }
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
