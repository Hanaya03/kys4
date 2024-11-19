using UnityEngine;
using TriInspector;
using Interactables.Components;
using Interactables.Data;
using HUD;

namespace Interactables
{
    
    [RequireComponent(typeof(Inspectable))]
    [HideMonoScript]
    public class Interactives : MonoBehaviour
    {
        [Tooltip("The Data for this Object: Assets/ScriptableObjects/Data")]
        [SerializeField] public InteractiveData interactive;
        public hudManager Hud { private set; get; }
        private GameObject _hudObject;
        
        private void Start()
        {
            _hudObject = GameObject.FindWithTag("HUD");
            Hud = _hudObject.GetComponent<hudManager>();
        }
    }
}

