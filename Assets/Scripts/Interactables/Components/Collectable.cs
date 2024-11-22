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

        public bool isActivated = true;
        
        // When the mouse clicks, invoke the event for adding items. 
        void OnMouseUp()
        {
            if (!isActivated) return;
            Debug.Log("Mouse Input! " + gameObject.name);
            Debug.Log(HUD.inputManager.IsInputLocked);
            if(!HUD.inputManager.IsInputLocked){
                if(item.changer) item.changer.NextSceneState(item.interactive.guid,"");
                item.Hud.addToInventory(item.itemObject);

                item.Hud.displayText(item.interactive.inspectMessage[1]);

                Destroy(gameObject);
            }
        }
    }
}

