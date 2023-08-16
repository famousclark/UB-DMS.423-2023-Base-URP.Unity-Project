using UnityEngine;
using UnityEngine.EventSystems;
using GameplayIngredients;
using GameplayIngredients.Events;

[AddComponentMenu("Gameplay Ingredients/Events/" + "On Select|Deselect Event")]
[AdvancedHierarchyIcon("Packages/net.peeweek.gameplay-ingredients/Icons/Events/ic-event-enable-disable.png")]
public class OnSelectDeselectEvent : EventBase, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Callable[] OnSelectEvent;
    public Callable[] OnDeselectEvent;
    public void OnSelect(BaseEventData eventData)
    {
        Callable.Call(OnSelectEvent, gameObject);
        //Debug.Log("selected");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Callable.Call(OnDeselectEvent, gameObject);
        //Debug.Log("deselected");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Callable.Call(OnSelectEvent, gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Callable.Call(OnDeselectEvent, gameObject);
    }
}

