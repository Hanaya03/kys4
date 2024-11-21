using UnityEngine;
using TriInspector;
using Interactables.Components;
using Interactables.Data;
using HUD;
using UnityEngine.SceneManagement;

namespace Interactables
{
    /// <summary> Parent class, interactives are entities in the scene that can be inspected and "interacted"
    /// with in some way</summary>
    [RequireComponent(typeof(Inspectable))] // Ensure the "Inspectable" script is present in this GameObject
    [HideMonoScript]
    public class Interactives : MonoBehaviour
    {
        [Tooltip("The Data for this Object: Assets/ScriptableObjects/Data")]
        [SerializeField] public InteractiveData interactive;
        [Tooltip("The the current background-image script")] 
        [SerializeField] public BackgroundChanger changer;

        [Scene] [SerializeField] private string thisScene;
        public hudManager Hud { private set; get; }
        private GameObject _hudObject;
        
        private void Start()
        {
            _hudObject = GameObject.FindWithTag("HUD");
            Hud = _hudObject.GetComponent<hudManager>();
        }
        
    }
}

