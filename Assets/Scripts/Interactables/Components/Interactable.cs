using TriInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Interactables.Components
{
    /// <summary>
    /// Component for objects that can be interacted with. Holds functionality for left-clicking and interacting with
    /// valid objects.
    /// </summary>
    [HideMonoScript]
    public class Interactable : Inspectable
    {
        [Tooltip("Event to invoke when clicking on the interactable object")]
        public UnityEvent onInteract;
        
        // When the mouse is clicked, invoke the onInteract event
        public void OnMouseDown()
        {
            onInteract.Invoke();
        }
    }
}

