using TriInspector;
using UnityEngine;
using HUD;

namespace Interactables.Components
{
    [HideMonoScript]
    public class Inspectable : MonoBehaviour
    {
<<<<<<< Updated upstream
=======

        protected hudManager Hud;
        
        // When the mouse is over the inspectable entity
>>>>>>> Stashed changes
        public void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1))
            {
                // Inspect Code Here
            }
        }

    }
}

