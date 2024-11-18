using UnityEngine;
using TriInspector;

namespace Interactables.Data
{
   [CreateAssetMenu(menuName = "Interactable/Data")]
   [HideMonoScript]
   public class InteractiveData : ScriptableObject
   {
       [SerializeField] public string guid;
       [SerializeField] public string[] inspectMessage;
   } 
}

