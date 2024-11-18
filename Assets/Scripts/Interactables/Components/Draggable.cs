using System;
using Interactables.Data;
using UnityEngine;

namespace Interactables.Components
{
    /// <summary>
    /// Components for items that can be dragged. Includes functionality for left-click-holding on items, moving inventory
    /// items, and executing item-to-static combination functions. 
    /// </summary>
    public class Draggable : Inspectable
    {

        [Tooltip("The Script for the Inventory Item")]
        [SerializeField] private InvItem item;
        private Vector3 _permPos; // The permanent position of the inventory item
        private bool _dragging; // Whether the item is currently being dragged 
        private Transform _interactObject; // The static entity the item is dropped on

        private void Start()
        { _permPos = transform.position; /* Set the permanent position of the item to its position in the scene at
        the beginning of the game */}
        
        // When the mouse is dragging a collider, set _dragging to true
        public void OnMouseDrag() { _dragging = true; }

        // When the mouse is no longer being clicked, set dragging to _false and check for item-to-static combination
        public void OnMouseUp()
        {
            if (!_dragging) return;
            _dragging = false;
            /* If the item was not dragged over an object, or this object is not a Static, snap the item back to its
             position in the inventory */
            if (_interactObject == null || !_interactObject.TryGetComponent(out Static interactable)) {transform.position = _permPos;}
            else
            {
                var itemInteractive = (ItemData)item.interactive; // Get the ItemData of this inventory item. 
                // For each combination this inventory item has
                foreach (var combination in itemInteractive.combinations) 
                {
                    // If the static entity is not a item-to-static combination, skip
                    if (!combination.staticID.Equals(interactable.interactive.guid)) continue;
                    // If so, run the provided function
                    switch (combination.function)
                    {
                        // NOTE: Fix GiveItem function
                        case InvItem.CombinationFunctions.GiveItem:
                            var newItem = new InvItem(combination.giveID);
                            newItem.AddItem();
                            break;
                        case InvItem.CombinationFunctions.EnableInteraction:
                            interactable.activated = true; break; // Enable the interactable functionality of the static
                        default: throw new ArgumentOutOfRangeException();
                    }
                    // NOTE: Fix RemoveItem function
                    if(combination.consumeItem){ /* Remove Item */ Destroy(gameObject);}
                    else {transform.position = _permPos;} // Move the item back into its permanent position
                    return;
                }
                transform.position = _permPos; // Move the item back into its permanent position
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
        { if (_dragging) {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10); } }
    }
}

