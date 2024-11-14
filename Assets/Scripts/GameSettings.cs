using UnityEngine;
using TriInspector;


[HideMonoScript]
[CreateAssetMenu(menuName = "KYS4/Settings")]
public class GameSettings : ScriptableObject
{

    public EditorPlayMethod editorPlay;
    public const string PersistentScenePath = "Assets/Scenes/PersistentScene.unity";
    public const string StartScenePath = "Assets/Scenes/MenuScenes/MainMenuScene.unity";
    
    public enum EditorPlayMethod
    {
        StartOfGame,
        CurrentScene
    }
}
