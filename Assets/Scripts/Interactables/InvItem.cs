using Interactables.Components;
using TriInspector;
using UnityEngine;

namespace Interactables
{
    /// <summary> Subclass of Interactives for Inventory Items. These items can be Inspected and Dragged onto
    /// static entities. </summary>
    [RequireComponent(typeof(Draggable))] // Ensure the "Draggable" script is present in this GameObject
    [HideMonoScript]
    public class InvItem : Interactives
    {
        
        // Constructor for Inventory Items, TODO: Finish Inventory Items
        public InvItem(string id){  }
        
        /// <summary>
        /// The different functions that can be executed when dragging an item onto a static entity
        /// </summary>
        public enum CombinationFunctions
        { GiveItem, EnableInteraction, DeleteStatic }


        public void UseItem()
        {
            Debug.Log("Input!");
            Instantiate(gameObject, Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion(0, 0, 0, 0));
        }
        
    }
}
