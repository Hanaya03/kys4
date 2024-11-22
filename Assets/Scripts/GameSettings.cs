using System.Collections.Generic;
using Interactables.Components;
using UnityEngine;
using TriInspector;
using Interactables.Data;
using Unity.VisualScripting;

/// <summary>
/// The game's settings (Currently only the editor's play method)
/// </summary>
[HideMonoScript]
[CreateAssetMenu(menuName = "KYS4/Settings")]
public class GameSettings : ScriptableObject
{
    /// <summary> The scene to begin with when playing in the Editor. </summary>
    public EditorPlayMethod editorPlay;
    public bool loadGameScenes;
    public const string PersistentScenePath = "Assets/Scenes/PersistentScene.unity";
    public const string StartScenePath = "Assets/Scenes/MenuScenes/MainMenu.unity";
    [Scene] public string[] AllScenes;
    

    public List<ItemData> itemScriptObjects;
    public List<InteractiveData> staticScriptObjects;
    
    /// <summary> Methods of starting the game in the Editor </summary>
    public enum EditorPlayMethod
    {
        StartOfGame,
        CurrentScene
    }
}
