using Assets.Scripts.Classes.Gameplay;
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
            var sceneEditorPath = EditorSceneManager.GetActiveScene().path;

            var newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
            EditorSceneManager.MoveGameObjectToScene(Instantiate(levelEditorController.GroundGroup), newScene);
            EditorSceneManager.MoveGameObjectToScene(Instantiate(levelEditorController.PlayableObjectsGroup), newScene);
            EditorSceneManager.MoveGameObjectToScene(Instantiate(levelEditorController.LevelCamera), newScene);
            EditorSceneManager.MoveGameObjectToScene(Instantiate(levelEditorController.LevelLight), newScene);

            string[] newScenePath = sceneEditorPath.Split(char.Parse("/"));

            newScenePath[newScenePath.Length - 1] = levelEditorController.LevelName + ".unity";

            bool saveOK = EditorSceneManager.SaveScene(newScene, string.Join("/", newScenePath));

            //levelEditorController.SaveGame();
        }
    }
}