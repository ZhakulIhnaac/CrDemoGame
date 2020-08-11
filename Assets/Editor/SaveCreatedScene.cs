using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(LevelEditorController))]
public class SaveCreatedScene : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelEditorController levelEditorController = (LevelEditorController)target;

        if (GUILayout.Button("Add Level To Build"))
        {
            var NewScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
            NewScene.name = levelEditorController.LevelName.GetComponent<TextMeshProUGUI>().text;

            // Moving game objects to new scene
            EditorSceneManager.MoveGameObjectToScene(Instantiate(levelEditorController.PlayableObjectsGroup), NewScene);
            EditorSceneManager.MoveGameObjectToScene(Instantiate(levelEditorController.GroundGroup), NewScene);

            var pathToSave = EditorSceneManager.GetActiveScene().path.Split(char.Parse("/"));
            pathToSave[pathToSave.Length - 1] = NewScene.name + ".unity";
            bool isSaved = EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(), string.Join("/", pathToSave));

            if (isSaved)
            {
                Debug.Log("Kaydedildi");
            }
            else
            {
                Debug.Log("Kaydedilemedi");
            }

        }
    }




    public void ExportLevelAsNewScene(GameObject PlayableObjectsGroup, GameObject GroundGroup, GameObject LevelName)
    {
        
    }
}
