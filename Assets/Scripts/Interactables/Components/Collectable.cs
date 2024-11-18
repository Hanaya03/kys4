using TriInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Interactables.Components
{
    /// <summary>
    /// Component for items that can be collected. Holds functionality for left-clicking items and adding them to the
    /// inventory. 
    /// </summary>
    [HideMonoScript]
    public class Collectable : MonoBehaviour
    {
        [Tooltip("Event to invoke when an item is to be added to the inventory.")]
        public UnityEvent onAddItem;
        
        // When the mouse clicks, invoke the event for adding items. 
        void OnMouseDown()
        {
            onAddItem.Invoke();
        }
    }
}

