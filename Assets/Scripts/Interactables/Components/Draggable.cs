using System;
using Interactables.Data;
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
                    if(combination.consumeItem){ /* Remove Item */ Destroy(gameObject);}
                    return;
                }
                transform.position = _startPos;
            }
        }

        public void OnTriggerEnter2D(Collider2D col)
        { _interactObject = col.transform; }

        public void OnTriggerExit2D(Collider2D col)
        {
            if (_interactObject == col.transform) { _interactObject = null; }
        }

        void Update()
        {
            if (_dragging) {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10); }
        }
    }
}

