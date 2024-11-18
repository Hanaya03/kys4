using UnityEngine;
using TriInspector;

namespace Interactables.Data
{
    /// <summary> Data for an interactive object - GUID and Inspect Message. </summary>
   [CreateAssetMenu(menuName = "Interactable/Data")]
   [HideMonoScript]
   public class InteractiveData : ScriptableObject
   {
       [Tooltip("The Unique Identifier for this interactive object.")]
       [SerializeField] public string guid;
       [Tooltip("The message that will show when inspecting this object.")]
       [SerializeField] public string[] inspectMessage;
   } 
}

