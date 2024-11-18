using TriInspector;
using UnityEngine;

namespace Interactables.Components
{
    [HideMonoScript]
    public class Collectable : Inspectable
    {
<<<<<<< Updated upstream
        public UnityEvent onAddItem;
=======

        [SerializeField] protected Item item;
>>>>>>> Stashed changes
        
        void OnMouseDown()
        {
            Hud.addToInventory(item.itemObject);
            Destroy(gameObject);
        }
    }
}

