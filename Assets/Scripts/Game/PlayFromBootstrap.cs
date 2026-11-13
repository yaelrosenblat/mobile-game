// Assets/Editor/PlayFromBootstrap.cs: runs only in the editor, never in the game
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]                    // run when Unity loads or recompiles


static class PlayFromBootstrap
{
    static PlayFromBootstrap()
    {
        // Every Play starts here. When you stop, Unity reopens the scene you were editing.
        EditorSceneManager.playModeStartScene =
            AssetDatabase.LoadAssetAtPath<SceneAsset>("Assets/Scenes/Bootstrap.unity");
    }
}
