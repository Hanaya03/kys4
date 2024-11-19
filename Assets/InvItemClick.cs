using HUD;
using Interactables.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TriInspector;

[HideMonoScript]
public class InvItemClick : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent onClick;
    private hudManager _hud;
    private int index;

    public void Start()
    {
        _hud = GameObject.FindWithTag("HUD").GetComponent<hudManager>();
        index = _hud.itemList.Count - 1;
    }
    
    public void OnPointerDown(PointerEventData _)
    {
        _hud.SetUsingItem(index);
        onClick.Invoke();
    }
}
