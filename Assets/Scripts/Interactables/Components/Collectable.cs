using TriInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Interactables.Components
{
    [HideMonoScript]
    public class Collectable : Inspectable
    {
        
        [SerializeField] protected Item item;
        
        void OnMouseDown()
        {
            item.Hud.addToInventory(item.itemObject);
            Destroy(gameObject);
        }
    }
}

