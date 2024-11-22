using System;
using Cysharp.Threading.Tasks;
using Interactables.Data;
using Unity.VisualScripting;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;

namespace Interactables.Components
{
    /// <summary>
    /// Components for items that can be dragged. Includes functionality for left-click-holding on items, moving inventory
    /// items, and executing item-to-static combination functions. 
    /// </summary>
    public class Draggable : Inspectable
    {
        [Tooltip("The Inventory Item Script of this Object")]
        [SerializeField] private InvItem item;
        private Vector3 _permPos; // The permanent position of the inventory item
        private bool _dragging; // Whether the item is currently being dragged 
        private Transform _interactObject; // The static entity the item is dropped on
            
        private async void Start()
        {
            _dragging = true;
            if (item.interactive.guid == "Items/Note")
            {
                var data = (ItemData)item.interactive;
                item.PlayAudio(data.audio[1]);
            }
            await UniTask.Delay(10);
            item.Hud.invertHudStatus(); // Hide the HUD after selecting an item
        
        }
        
        // When the mouse is dragging a collider, set _dragging to true
        /*public void OnMouseDrag() { _dragging = true; }*/

        // When the mouse is no longer being clicked, set dragging to _false and check for item-to-static combination
        private void MouseUp()
        {
            if (!_dragging) return;
            _dragging = false;
            /* If the item was not dragged over an object, or this object is not a Static, snap the item back to its
             position in the inventory */
            if (_interactObject == null || !_interactObject.TryGetComponent(out Static interactable)) {Destroy(gameObject);}
            else
            {
                var itemInteractive = (ItemData)item.interactive; // Get the ItemData of this inventory item. 
                // For each combination this inventory item has
                foreach (var combination in itemInteractive.combinations)
                {
                    string interactableGUID = interactable.interactive.guid;
                    // If the static entity is not a item-to-static combination, skip
                    if (!combination.staticID.Equals(interactableGUID)) continue;
                    // If so, run the provided function
                    switch (combination.function)
                    {
                        case InvItem.CombinationFunctions.GiveItem:
                            string guid = combination.giveID;
                            foreach (var itemData in MasterScript.Settings.itemScriptObjects)
                            {
                                if (itemData.guid.Equals(guid)) { item.Hud.addToInventory(itemData.prefab); }
                            }
                            item.Hud.displayText(item.interactive.inspectMessage[4]);
                            interactable.changer.NextSceneState(itemInteractive.guid, interactableGUID);
                            break;
                        case InvItem.CombinationFunctions.EnableInteraction:
                            interactable.changer.NextSceneState(itemInteractive.guid, interactableGUID);
                            interactable.activated = true;
                            item.Hud.displayText(item.interactive.inspectMessage[3]);
                            if (itemInteractive.audio != null) { interactable.PlayAudio(itemInteractive.audio[0]); }
                            break; // Enable the interactable functionality of the static
                        case InvItem.CombinationFunctions.DeleteStatic:
                            if (itemInteractive.audio != null) { interactable.PlayAudio(itemInteractive.audio[0]); }
                            interactable.changer.NextSceneState(itemInteractive.guid, interactableGUID);
                            item.Hud.displayText(item.interactive.inspectMessage[2]);
                            Destroy(_interactObject.gameObject); break;
                        default: throw new ArgumentOutOfRangeException();
                    }
                    if (combination.consumeItem) { item.Hud.removeFromInventory(); }
                    if (combination.consumeStatic) {Destroy(_interactObject.gameObject);}
                    break;
                }
                Destroy(gameObject); // Move the item back into its permanent position
            }
        }

        // When the Inventory Item's trigger is entered
        public void OnTriggerEnter2D(Collider2D col)
        { _interactObject = col.transform; } // Set the InteractObject to triggering object

        // When the Inventory Item's trigger is exited
        public void OnTriggerExit2D(Collider2D col)
        // If the interact object is set to triggering object, set it to null
        { if (_interactObject == col.transform) { _interactObject = null; } } 

        // On every update, if the inventory item is being dragged, lock the item to the mouse cursor
        void Update()
        {
            if (!_dragging) return;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            if (Input.GetMouseButtonUp(0))
            {
                MouseUp();
            }
        }
    }
}

