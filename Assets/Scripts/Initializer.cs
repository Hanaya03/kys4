using Cysharp.Threading.Tasks;
using TriInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Initializes some important game settings when the persistent scene loads in
/// </summary>
[HideMonoScript]
public class Initializer : MonoBehaviour
{

    private string activeScene;
    
    private async void Start()
    {
        // Loads the Game's Settings from the ScriptableObject in Assets/Resources
        MasterScript.Settings = Resources.Load<GameSettings>("GameSettings");
        if (MasterScript.Settings.editorPlay == GameSettings.EditorPlayMethod.CurrentScene)
        {
            if (MasterScript.Settings.loadGameScenes)
            {
                await SetScenes();
            }
        }
    }

    public async UniTask SetScenes()
    {
        foreach (var scene in MasterScript.Settings.AllScenes)
        {
            if (SceneManager.GetSceneByPath(scene).isLoaded)
            {
                Debug.Log(scene + " is loaded");
                activeScene = scene;
                continue;
            }
            Debug.Log(scene + " not loaded");
            await SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            await UniTask.Yield();
        }

        if (activeScene != null)
        {
            await UniTask.WaitUntil(() => SceneManager.SetActiveScene(SceneManager.GetSceneByPath(activeScene)));
        }
    }
    
    public async UniTask UnloadScenes()
    {
        foreach (var scene in MasterScript.Settings.AllScenes)
        {
            if (SceneManager.GetSceneByPath(scene).isLoaded)
            {
                await SceneManager.UnloadSceneAsync(scene);
            }
            await UniTask.Yield();
        }
    }
}
