using System;
using Interactables.Data;
using Unity.VisualScripting;
using UnityEngine;

namespace Interactables.Components
{
    public class Draggable : Inspectable
    {

        [SerializeField] private InvItem item;
        private Vector3 _startPos;
        private bool _dragging;
        private Transform _interactObject;
            
        private void Start()
        {
            _dragging = true;
            /*_permPos = transform.position;*/ /* Set the permanent position of the item to its position in the scene at
        the beginning of the game */}
        
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
                var itemInteractive = (ItemData)item.interactive;
                foreach (var combination in itemInteractive.combinations)
                {
                    if (!combination.itemID.Equals(interactable.interactive.guid)) continue;
                    switch (combination.function)
                    {
                        case InvItem.CombinationFunctions.GiveItem:
                            var newItem = new InvItem(combination.giveID);
                            newItem.AddItem();
                            break;
                        case InvItem.CombinationFunctions.EnableInteraction:
                            interactable.activated = true;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    // NOTE: Fix RemoveItem function
                    if(combination.consumeItem){ /* Remove Item */ ;}
                    else {} // Move the item back into its permanent position
                    break;
                }
                Destroy(gameObject); // Move the item back into its permanent position
            }
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            _interactObject = col.transform; 
        } // Set the InteractObject to triggering object

        public void OnTriggerExit2D(Collider2D col)
        {
            if (_interactObject == col.transform) { _interactObject = null; }
        }

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

