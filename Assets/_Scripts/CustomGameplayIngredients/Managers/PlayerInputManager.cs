using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayIngredients;
using UnityEngine.InputSystem;
using System;
using NaughtyAttributes;
using UnityEngine.Rendering;

[AddComponentMenu("Gameplay Ingredients/Events/" + "On Player Input Action Event (New Input System)")]
[ManagerDefaultPrefab("PlayerInputManager")]
public class PlayerInputManager : Manager
{
    [Dropdown("GetActionMaps")]
    [SerializeField]
    private string availabeMappings;

    [Header("Recievable Messages")]
    [SerializeField]
    private string FirstPersonMessage = "MAPPING_FIRST_PERSON";
    [SerializeField]
    private string ThirdPersonMessage = "MAPPING_THIRD_PERSON";
    [SerializeField]
    private string DialogueMessage = "MAPPING_DIALOGUE";

    private List<string> GetActionMaps()
    {
        List<string> actionMapsNames = new List<string>();
        PlayerInput playerInput = GetComponent<PlayerInput>();
        var test = playerInput.actions.actionMaps;
        foreach (var item in test)
        {
            actionMapsNames.Add(item.name);
        }
        return actionMapsNames;
    }
    private void OnEnable()
    {
        Messager.RegisterMessage(FirstPersonMessage, OnSwitchToFirstPersonMapping);
        Messager.RegisterMessage(ThirdPersonMessage, OnSwitchToThirdPersonMapping);
        Messager.RegisterMessage(DialogueMessage, OnSwitchToDialogueMapping);
    }

    private void OnDisable()
    {
        Messager.RemoveMessage(FirstPersonMessage, OnSwitchToFirstPersonMapping);
        Messager.RemoveMessage(ThirdPersonMessage, OnSwitchToThirdPersonMapping);
        Messager.RemoveMessage(DialogueMessage, OnSwitchToDialogueMapping);
    }


    private void OnSwitchToFirstPersonMapping(GameObject instigator = null)
    {
        PlayerInput mapping = GetComponent<PlayerInput>();

        mapping.SwitchCurrentActionMap("First-Person-Mapping");
    }

    private void OnSwitchToThirdPersonMapping(GameObject instigator = null)
    {
        PlayerInput mapping = GetComponent<PlayerInput>();

        mapping.SwitchCurrentActionMap("Third-Person-Mapping");
    }

    private void OnSwitchToDialogueMapping(GameObject instigator = null)
    {
        PlayerInput mapping = GetComponent<PlayerInput>();

        mapping.SwitchCurrentActionMap("Dialogue-Person-Mapping");
    }

    public string GetCurrentMapping()
    {
        PlayerInput mapping = GetComponent<PlayerInput>();
        return mapping.currentActionMap.name;
    }


}
