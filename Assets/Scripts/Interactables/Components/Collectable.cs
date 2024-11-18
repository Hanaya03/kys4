using TriInspector;
using UnityEngine;

namespace Interactables.Components
{
    [HideMonoScript]
    public class Collectable : Inspectable
    {

        [SerializeField] protected Item item;
        
        void OnMouseDown()
        {
            Hud.addToInventory(item.itemObject);
            Destroy(gameObject);
        }
    }
}

