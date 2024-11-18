using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InvItemClick : MonoBehaviour, IPointerDownHandler
{

    public UnityEvent onClick;
    
    public void OnPointerDown(PointerEventData _)
    {
        onClick.Invoke();
    }
}
