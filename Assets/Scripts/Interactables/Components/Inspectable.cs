using System.Threading.Tasks;
using TriInspector;
using UnityEngine;
using Interactables;
using HUD;
using Interactables;

namespace Interactables.Components
{
    /// <summary>
    /// Component for objects that can be inspected. Holds functionality for right-clicking and inspecting valid object. 
    /// </summary>
    [HideMonoScript]
    public class Inspectable : MonoBehaviour
    {
        [SerializeField] protected Interactives interactable;
        
        // When the mouse is over the inspectable entity
        public async void OnMouseOver()
        {
            // If the right-mouse button is down
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("M2 input!");
                if (interactable.interactive.inspectMessage.Length <= 0) return;
                interactable.Hud.Inspect(interactable);
            }
        }
    }
}

