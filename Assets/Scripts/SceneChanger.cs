using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TriInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using HUD;

public class SceneChanger : MonoBehaviour
{

    private Initializer _initializer;
    
    private async void Start()
    {
        await UniTask.WaitUntil(() => SceneManager.GetSceneByPath("Assets/Scenes/PersistentScene.unity").isLoaded);
        _hud = GameObject.FindWithTag("HUD").GetComponent<hudManager>();
        _initializer = GameObject.FindWithTag("Initializer").GetComponent<Initializer>();
    }

    public void StartGame()
    {
        StartGameMethod();
    }
    
    private async UniTask StartGameMethod()
    {
        await SceneManager.LoadSceneAsync("Assets/Scenes/GameScenes/MeatClosetRestroom.unity", LoadSceneMode.Additive);
        await _initializer.SetScenes();
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByPath("Assets/Scenes/MenuScenes/MainMenu.unity"));
        _hud.introSequence();
    }

    public void PlayAgain()
    {
        PlayAgainMethod();
    }

    private async UniTask PlayAgainMethod()
    {
        await SceneManager.LoadSceneAsync("Assets/Scenes/GameScenes/MeatClosetRestroom.unity", LoadSceneMode.Additive);
        await _initializer.SetScenes();
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByPath("Assets/Scenes/MenuScenes/Win.unity"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
