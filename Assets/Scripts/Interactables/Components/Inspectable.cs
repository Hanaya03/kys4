using TriInspector;
using UnityEngine;
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
        private Interactives interactable;
        // When the mouse is over the inspectable entity
        public void OnMouseOver()
        {
            // If the right-mouse button is down
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("M2 input!");
                interactable.Hud.invertHudStatus();
                interactable.Hud.changeText("some text");
            }
        }

    }
}

