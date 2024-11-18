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

        public void AddItem()
        {
            
        }
        
    }
}
