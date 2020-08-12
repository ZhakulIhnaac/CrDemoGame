using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(LevelEditorController))]
public class LevelEditorControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelEditorController levelEditorController = (LevelEditorController)target;

        foreach (var pipe in levelEditorController.PipesList)
        {
            if (GUILayout.Button("New " + pipe.name))
            {
                var newPipe = PrefabUtility.InstantiatePrefab(pipe) as GameObject;
                newPipe.transform.SetParent(levelEditorController.PlayableObjectsGroup.transform);
            }
        }

        if (GUILayout.Button("Save Level"))
        {
            var newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
            EditorSceneManager.MoveGameObjectToScene(Instantiate(levelEditorController.GroundGroup), newScene);
            EditorSceneManager.MoveGameObjectToScene(Instantiate(levelEditorController.PlayableObjectsGroup), newScene);
            EditorSceneManager.MoveGameObjectToScene(Instantiate(levelEditorController.LevelCamera), newScene);

            string[] path = EditorSceneManager.GetActiveScene().path.Split(char.Parse("/"));

            path[path.Length - 1] = levelEditorController.LevelName + ".unity";

            bool saveOK = EditorSceneManager.SaveScene(newScene, string.Join("/", path));

            Debug.Log(saveOK);

            //levelEditorController.SaveGame();
        }
    }
}