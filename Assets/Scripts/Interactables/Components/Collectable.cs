using TriInspector;
using UnityEngine;

namespace Interactables.Components
{
    [HideMonoScript]
    public class Collectable : Inspectable
    {
        [Tooltip("The Item Script in this Game Object")]
        [SerializeField] protected Item item;
        
        void OnMouseDown()
        {
            item.Hud.addToInventory(item.itemObject);
            Destroy(gameObject);
        }
    }
}

