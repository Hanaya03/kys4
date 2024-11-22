using Cysharp.Threading.Tasks;
using UnityEngine;
using Interactables.Components;
using TriInspector;
using UnityEngine.SceneManagement;
using HUD;

namespace Interactables
{
    /// <summary>
    /// Subclass of Interactives, for Static Entities. These entities can be inspected and interacted with. 
    /// </summary>
    [RequireComponent(typeof(Interactable))]
    [RequireComponent(typeof(AudioSource))]
    [HideMonoScript]
    public class Static : Interactives
    {
        private HUD.hudManager _hud;
        [Tooltip("Whether this interactive is enabled and can be clicked on.")]
        public bool activated;
        
        /// <summary> Functions that can be ran when interacting with a static entity </summary>
        public enum StaticFunctions
        { ChangeScene, WinScene, DeleteStatic, ShowSprite, None }

        [Tooltip("The function that will be ran when this entity is clicked on.")]
        public StaticFunctions[] staticFunctions;

        [SerializeField] private AudioSource audio;

        void Start()
        {
            base.Start();
            _hud = GameObject.FindWithTag("HUD").GetComponent<hudManager>();
            audio = GameObject.FindWithTag("AudioPlayer").GetComponent<AudioSource>();
        }
        
        /// <summary> Run the chosen static function for this static object</summary>
        public void RunStaticFunction()
        {
            foreach (var staticFunction in staticFunctions)
            {
               if (!activated) return; // If the interactable is deactivated, don't run the function
               switch (staticFunction)
               {
                   case StaticFunctions.ChangeScene:
                       ChangeScene(); // Change to the Scene decided by the Static Object's data 
                       break;
                    case StaticFunctions.WinScene:
                        WinScene();
                        break;
                    case StaticFunctions.DeleteStatic:
                        Destroy(gameObject);
                        break;
                    case StaticFunctions.ShowSprite:
                        GetComponent<SpriteRenderer>().enabled = true;
                        break;
               } 
            }
            
        }
        
        /// <summary> Go to the scene given by the guid of this object's interactive data, and unload
        /// the current scene. </summary>
        private async void ChangeScene()
        {
            audio.Play();
            var room = interactive.guid.Split("Static/Door/")[1];
            SceneManager.SetActiveScene(SceneManager.GetSceneByPath("Assets/Scenes/GameScenes/" + room + ".unity"));
            UniTask.Yield();
        }
        
        private async void WinScene()
        {
            audio.Play();
            await UniTask.WaitUntil(() => !audio.isPlaying);
            await SceneManager.LoadSceneAsync("Assets/Scenes/MenuScenes/" + "Win" + ".unity");
            SceneManager.SetActiveScene(SceneManager.GetSceneByPath("Assets/Scenes/MenuScenes/" + "Win" + ".unity"));
            SceneManager.LoadSceneAsync("Assets/Scenes/" + "PersistentScene" + ".unity", LoadSceneMode.Additive);
            UniTask.Yield();
        }
        
    }
}


