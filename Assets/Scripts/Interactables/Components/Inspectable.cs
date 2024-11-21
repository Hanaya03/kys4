using TriInspector;
using UnityEngine;
using Interactables;
using HUD;

namespace Interactables.Components
{
    /// <summary>
    /// Component for objects that can be inspected. Holds functionality for right-clicking and inspecting valid object. 
    /// </summary>
    [HideMonoScript]
    public class Inspectable : MonoBehaviour
    {

        [SerializeField] private Interactives interactable;
        
        // When the mouse is over the inspectable entity
        public void OnMouseOver()
        {
            // If the right-mouse button is down
            if (Input.GetMouseButtonDown(1))
            {
                // TODO: Inspect Code Here
            }
        }

    }
}

