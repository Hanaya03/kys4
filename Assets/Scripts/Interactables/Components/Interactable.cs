using TriInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Interactables.Components
{
    [HideMonoScript]
    public class Interactable : MonoBehaviour
    {
        public UnityEvent onInteract;
        
        public void OnMouseDown()
        {
            onInteract.Invoke();
        }
    }
}

