using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TriInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    private Initializer _initializer;
    
    private void Start()
    {
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
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
