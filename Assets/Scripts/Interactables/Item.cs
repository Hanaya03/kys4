using Interactables.Components;
using TriInspector;
using UnityEngine;

namespace Interactables
{
    /// <summary> Subclass of Interactives, for Scene Items. These items can be inspected and collected. </summary>
    [RequireComponent(typeof(Collectable))] // Ensure the "Collectable" script is present in the GameObject
    [HideMonoScript]
    public class Item : Interactives
    {
        [Tooltip("The item's corresponding UI Object: Assets/Prefabs/InvUI")]
        [SerializeField] public GameObject itemObject;
        
        
    }
}

