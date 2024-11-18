using UnityEngine;
using TriInspector;
using Interactables.Components;
using Interactables.Data;

namespace Interactables
{
    
    [RequireComponent(typeof(Inspectable))]
    [HideMonoScript]
    public class Interactives : MonoBehaviour
    {
        [SerializeField] public InteractiveData interactive;
    }
}

