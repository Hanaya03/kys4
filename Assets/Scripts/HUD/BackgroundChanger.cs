using UnityEngine;
using Interactables.Data;
using Image = UnityEngine.UI.Image;

namespace HUD
{
    public class BackgroundChanger : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private SceneState sceneData;
    
        public void NextSceneState(string dragID, string entityID)
        {
            foreach (var state in sceneData.nextScenes)
            {
                foreach (var combo in state.Combinations)
                {
                    if (!(combo.ItemID.Equals(dragID) && combo.EntityID.Equals(entityID))) continue;
                    image.sprite = state.background;
                    sceneData = state;
                    break;
                }
                
            }
        }
    }
}

