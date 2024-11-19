using TriInspector;
using UnityEngine;
using HUD;

namespace Interactables.Components
{
    [HideMonoScript]
    public class Inspectable : MonoBehaviour
    {
        // When the mouse is over the inspectable entity
        public void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1))
            {
                // Inspect Code Here
            }
        }

    }
}

