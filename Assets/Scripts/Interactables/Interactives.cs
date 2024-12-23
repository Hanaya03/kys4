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
    [HideMonoScript]
    public class Interactives : MonoBehaviour
    {
        [Tooltip("The Data for this Object: Assets/ScriptableObjects/Data")]
        [SerializeField] public InteractiveData interactive;
        [Tooltip("The the current background-image script")] 
        [SerializeField] public BackgroundChanger changer;

        public hudManager Hud { private set; get; }
        private GameObject _hudObject;
        [SerializeField] protected AudioSource audio;
        
        protected void Start()
        {
            _hudObject = GameObject.FindWithTag("HUD");
            Hud = _hudObject.GetComponent<hudManager>();
            if (!audio)
            {
                audio = GameObject.FindWithTag("AudioPlayer").GetComponent<AudioSource>();
            }
        }
        
        public void PlayAudio(AudioClip clip)
        {
            audio.PlayOneShot(clip);
        }
        
    }
}

