using Interactables.Components;
using TriInspector;
using UnityEngine;

namespace Interactables
{
    [RequireComponent(typeof(Draggable))]
    [HideMonoScript]
    public class InvItem : Interactives
    {
        
        public InvItem(string id){  }
        
        public enum CombinationFunctions
        {
            GiveItem,
            EnableInteraction,
        }
        
        // TODO: Unfnished AddItem script 
        public void AddItem()
        {
            
        }

        public void UseItem()
        {
            Instantiate(gameObject, Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion(0, 0, 0, 0));
        }
        
    }
}
