using System.Collections;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEnabler : MonoBehaviour
{
    [Scene] [SerializeField] private string thisScene;

    [SerializeField] private GameObject scene;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += HandleSceneChange;
    }

    private void HandleSceneChange(Scene scene1, Scene scene2)
    {
        scene.SetActive(scene2.path == thisScene);
    }
}
