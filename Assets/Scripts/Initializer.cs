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
            await SetScenes();
        }
    }

    public async UniTask SetScenes()
    {
        foreach (var scene in MasterScript.Settings.AllScenes)
        {
            if (SceneManager.GetSceneByPath(scene).isLoaded)
            {
                activeScene = scene;
                continue;
            }
            await SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            await UniTask.Yield();
        }
        await UniTask.WaitUntil(() => SceneManager.SetActiveScene(SceneManager.GetSceneByPath(activeScene)));
    }
}
