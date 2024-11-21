using TriInspector;
using UnityEngine;

namespace Interactables.Components
{
    /// <summary>
    /// Component for items that can be collected. Holds functionality for left-clicking items and adding them to the
    /// inventory. 
    /// </summary>
    [HideMonoScript]
    public class Collectable : Inspectable
    {

        [Tooltip("The Item Script in this Game Object")]
        [SerializeField] protected Item item;
        
        // When the mouse clicks, invoke the event for adding items. 
        void OnMouseDown()
        {
            if(item.changer) item.changer.NextSceneState(item.interactive.guid,"");
            item.Hud.addToInventory(item.itemObject);
            Destroy(gameObject);
        }
    }
}

