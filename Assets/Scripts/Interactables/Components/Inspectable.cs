using TriInspector;
using UnityEngine;

namespace Interactables.Components
{
    [HideMonoScript]
    public class Inspectable : MonoBehaviour
    {
        public void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1))
            {
                // Inspect Code Here
            }
        }

    }
}

