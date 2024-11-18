using TriInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Interactables.Components
{
    [HideMonoScript]
    public class Collectable : MonoBehaviour
    {
        public UnityEvent onAddItem;
        
        void OnMouseDown()
        {
            onAddItem.Invoke();
        }
    }
}

