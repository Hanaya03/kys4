using HUD;
using Interactables.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TriInspector;

[HideMonoScript]
public class InvItemClick : MonoBehaviour, IPointerDownHandler
{
    public InteractiveData data;
    public UnityEvent onClick;
    private hudManager _hud;

    private void Awake()
    {
        _hud = GameObject.FindWithTag("HUD").GetComponent<hudManager>();
    }
    
    public void OnPointerDown(PointerEventData _)
    {
        if(Input.GetMouseButton(1)) return;
        _hud.SetUsingItem(_hud.itemGUIDList.IndexOf(data.guid));
        onClick.Invoke();
    }
}
