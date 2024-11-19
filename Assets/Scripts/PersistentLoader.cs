using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script responsible for loading in the persistent scene, along with the scene the game is set to start with
/// </summary>
public static class PersistentLoader
{
    
    // Loads the Game's Settings from the ScriptableObject Assets/Resources
    private static readonly GameSettings Settings = Resources.Load<GameSettings>("GameSettings");
    
    /// <summary>
    /// Load the persistent scene on top of the starting scene. In the Editor, depending on the Play Method, start
    /// at the current scene or the game's start scene. This method runs before the first scene loads.
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadPersistentScene()
    {
// If playing in the Unity Editor
#if UNITY_EDITOR 
        if (Settings.editorPlay.Equals(GameSettings.EditorPlayMethod.StartOfGame))
        {
            // Loads the game's starting scene
            SceneManager.LoadScene(GameSettings.StartScenePath); 
        }
        // Otherwise, keep the current scene

#endif
        // If the persistent scene is not the current scene
        if (SceneManager.GetActiveScene().path != GameSettings.PersistentScenePath)
        {
            // Load it in on top (Additive) of the current scene
            SceneManager.LoadScene(GameSettings.PersistentScenePath, LoadSceneMode.Additive);
        }
        UniTask.Yield();
    }
}
