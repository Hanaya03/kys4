using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PersistentLoader
{
    
    private static readonly GameSettings Settings = Resources.Load<GameSettings>("GameSettings");
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadPersistentScene()
    {
        
#if UNITY_EDITOR
        if (Settings.editorPlay.Equals(GameSettings.EditorPlayMethod.StartOfGame))
        {
            SceneManager.LoadScene(GameSettings.StartScenePath);
        }

#endif
        
        if (SceneManager.GetActiveScene().path != GameSettings.PersistentScenePath)
        {
            SceneManager.LoadScene(GameSettings.PersistentScenePath, LoadSceneMode.Additive);
        }
        UniTask.Yield();
    }
}
