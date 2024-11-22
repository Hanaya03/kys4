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
        // [SerializeField] private Interactives interactable;
        
        // When the mouse is over the inspectable entity
        public async void OnMouseOver()
        {
            // If the right-mouse button is down
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("M2 input!");
                HUD.inputManager.LockInput();
                if(gameObject.GetComponent<Item>() != null){
                    gameObject.GetComponent<Item>().Hud.invertHudStatus();
                    gameObject.GetComponent<Item>().Hud.changeText(gameObject.GetComponent<Item>().interactive.inspectMessage[0]);
                    gameObject.GetComponent<Item>().Hud.hideItems();
                    await WaitForMouseClick();
                    gameObject.GetComponent<Item>().Hud.showItems();
                    gameObject.GetComponent<Item>().Hud.invertHudStatus();
                    return;
                }
                if(gameObject.GetComponent<Static>() != null){
                    gameObject.GetComponent<Static>().Hud.invertHudStatus();
                    gameObject.GetComponent<Static>().Hud.changeText(gameObject.GetComponent<Static>().interactive.inspectMessage[0]);
                    gameObject.GetComponent<Static>().Hud.hideItems();
                    await WaitForMouseClick();
                    gameObject.GetComponent<Static>().Hud.showItems();
                    gameObject.GetComponent<Static>().Hud.invertHudStatus();
                    return;
                }   
            }
        }

        private async Task WaitForMouseClick()
        {
            Cursor.lockState = CursorLockMode.Locked;

            while (!Input.GetMouseButtonDown(0))
            {
                await Task.Yield(); // Yields control back to the caller until the next frame
            }
                // Wait until the mouse button is released to prevent accidental skips
            while (Input.GetMouseButton(0))
            {
                await Task.Yield();
            }
            Cursor.lockState = CursorLockMode.None;
            HUD.inputManager.UnlockInput();
        }
    }
}

