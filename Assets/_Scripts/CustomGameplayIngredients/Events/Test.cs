using System;
using UnityEngine;
using GameplayIngredients;
using GameplayIngredients.Events;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif



//[AddComponentMenu(ComponentMenu.eventsPath + "On Player Input Action Event (New Input System)")]
public class Test : EventBase
{
#if ENABLE_INPUT_SYSTEM
    [SerializeField]
    PlayerInputAction inputAction;

    [Header("Action")]
    public Callable[] onButtonDown;

    private void OnEnable()
    {
        InputActionManager.Request(inputAction.action, InputAction_performed);
    }

    private void OnDisable()
    {
        InputActionManager.Release(inputAction.action, InputAction_performed);
    }

    private void InputAction_performed(InputAction.CallbackContext obj)
    {
        Callable.Call(onButtonDown, gameObject);
    }
#endif
}




