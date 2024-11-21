using System.Threading.Tasks;
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
        private Static staticComponent;
        private Item itemComponent;

        // When the mouse is over the inspectable entity
        public void OnMouseOver()
        {
            // If the right-mouse button is down
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("M2 input!");
                if(gameObject.GetComponent<Item>() != null){
                    gameObject.GetComponent<Item>().Hud.invertHudStatus();
                    gameObject.GetComponent<Item>().Hud.changeText(gameObject.GetComponent<Item>().interactive.inspectMessage[0]);
                    WaitForMouseClick();
                    gameObject.GetComponent<Item>().Hud.invertHudStatus();
                }else if(gameObject.GetComponent<Static>() != null){
                    gameObject.GetComponent<Static>().Hud.invertHudStatus();
                    gameObject.GetComponent<Static>().Hud.changeText(gameObject.GetComponent<Static>().interactive.inspectMessage[0]);
                    WaitForMouseClick();
                    gameObject.GetComponent<Static>().Hud.invertHudStatus();
                }
            }
        }

        private async Task WaitForMouseClick()
        {
            // Continue checking until a mouse click is detected
            while (!Input.GetMouseButtonDown(0))
            {
                await Task.Yield(); // Yields control back to the caller until the next frame
            }
                // Wait until the mouse button is released to prevent accidental skips
            while (Input.GetMouseButton(0))
            {
                await Task.Yield();
            }
        }
    }
}

