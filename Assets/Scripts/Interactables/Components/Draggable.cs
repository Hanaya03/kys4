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
        private 

<<<<<<< Updated upstream
        void Start()
        {
            _startPos = transform.position;
        }
        
        public void OnMouseDrag() { _dragging = true; }

        public void OnMouseUp()
        {
            if (!_dragging) return;
            _dragging = false;
            if (_interactObject == null || !_interactObject.TryGetComponent(out Static interactable)) {transform.position = _startPos;}
=======
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
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
                    if(combination.consumeItem){ /* Remove Item */ Destroy(gameObject);}
                    return;
                }
                transform.position = _startPos;
=======
                    // NOTE: Fix RemoveItem function
                    if(combination.consumeItem){ /* Remove Item */ ;}
                    else {} // Move the item back into its permanent position
                    break;
                }
                Destroy(gameObject); // Move the item back into its permanent position
>>>>>>> Stashed changes
            }
        }

        public void OnTriggerEnter2D(Collider2D col)
<<<<<<< Updated upstream
        { _interactObject = col.transform; }
=======
        {
            _interactObject = col.transform; 
        } // Set the InteractObject to triggering object
>>>>>>> Stashed changes

        public void OnTriggerExit2D(Collider2D col)
        {
            if (_interactObject == col.transform) { _interactObject = null; }
        }

        void Update()
        {
<<<<<<< Updated upstream
            if (_dragging) {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10); }
=======
            if (!_dragging) return;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            if (Input.GetMouseButtonUp(0))
            {
                MouseUp();
            }
>>>>>>> Stashed changes
        }
    }
}

