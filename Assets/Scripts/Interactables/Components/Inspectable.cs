using TriInspector;
using UnityEngine;
using HUD;
using Interactables;

namespace Interactables.Components
{
    [HideMonoScript]
    public class Inspectable : MonoBehaviour
    {
        private Interactives interactable;
        // When the mouse is over the inspectable entity
        public void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("M2 input!");
                interactable.Hud.invertHudStatus();
                interactable.Hud.changeText("some text");
            }
        }

    }
}

