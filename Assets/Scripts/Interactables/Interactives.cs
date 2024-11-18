using UnityEngine;
using TriInspector;
using Interactables.Components;
using Interactables.Data;

namespace Interactables
{
    /// <summary> Parent class, interactives are entities in the scene that can be inspected and "interacted"
    /// with in some way</summary>
    [RequireComponent(typeof(Inspectable))] // Ensure the "Inspectable" script is present in this GameObject
    [HideMonoScript]
    public class Interactives : MonoBehaviour
    {
        [Tooltip("The Scriptable Object that represents the data for this interactive object.")]
        [SerializeField] public InteractiveData interactive;
    }
}
