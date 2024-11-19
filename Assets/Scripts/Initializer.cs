using TriInspector;
using UnityEngine;

/// <summary>
/// Initializes some important game settings when the persistent scene loads in
/// </summary>
[HideMonoScript]
public class Initializer : MonoBehaviour
{
    private void Start()
    {
        // Loads the Game's Settings from the ScriptableObject in Assets/Resources
        MasterScript.Settings = Resources.Load<GameSettings>("GameSettings");
    }
}
