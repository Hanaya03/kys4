using Cysharp.Threading.Tasks;
using UnityEngine;
using Interactables.Components;
using TriInspector;
using UnityEngine.SceneManagement;

namespace Interactables
{
    /// <summary>
    /// Subclass of Interactives, for Static Entities. These entities can be inspected and interacted with. 
    /// </summary>
    [RequireComponent(typeof(Interactable))]
    [HideMonoScript]
    public class Static : Interactives
    {
        [Tooltip("Whether this interactive is enabled and can be clicked on.")]
        public bool activated;

        /// <summary> Functions that can be ran when interacting with a static entity </summary>
        public enum StaticFunctions
        { ChangeScene, }

        [Tooltip("The function that will be ran when this entity is clicked on.")]
        public StaticFunctions staticFunction;

        /// <summary> Run the chosen static function for this static object</summary>
        public void RunStaticFunction()
        {
            if (!activated) return; // If the interactable is deactivated, don't run the function
            switch (staticFunction)
            {
                case StaticFunctions.ChangeScene:
                    ChangeScene(); // Change to the Scene decided by the Static Object's data 
                    break;
            }
        }
        
        /// <summary> Go to the scene given by the guid of this object's interactive data, and unload
        /// the current scene. </summary>
        private void ChangeScene()
        {
            var room = interactive.guid.Split("Static/Door/")[1];
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().path);
            SceneManager.LoadScene("Assets/Scenes/GameScenes/" + room + ".unity", LoadSceneMode.Additive);
            UniTask.Yield();
        }
        
        
    }
}


