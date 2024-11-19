using Cysharp.Threading.Tasks;
using UnityEngine;
using Interactables.Components;
using TriInspector;
using UnityEngine.SceneManagement;

namespace Interactables
{
    [RequireComponent(typeof(Interactable))]
    [HideMonoScript]
    public class Static : Interactives
    {
        [Tooltip("Whether this Static can be interacted with.")]
        public bool activated;
        
        public enum StaticFunctions
        {
            ChangeScene,
            
        }

        [Tooltip("The function that will execute when interacting with this script.")]
        public StaticFunctions staticFunction;

        public void RunStaticFunction()
        {
            if (!activated) return;
            switch (staticFunction)
            {
                case StaticFunctions.ChangeScene:
                    ChangeScene();
                    break;
            }
        }
        
        private void ChangeScene()
        {
            var room = interactive.guid.Split("Static/Door/")[1];
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().path);
            SceneManager.LoadScene("Assets/Scenes/GameScenes/" + room + ".unity", LoadSceneMode.Additive);
            UniTask.Yield();
        }
        
        
    }
}


