//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/PropHunt/Inputs/PropHuntControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @SimpleControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @SimpleControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PropHuntControls"",
    ""maps"": [
        {
            ""name"": ""gameplay"",
            ""id"": ""265c38f5-dd18-4d34-b198-aec58e1627ff"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""50fd2809-3aa3-4a90-988e-1facf6773553"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""look"",
                    ""type"": ""Value"",
                    ""id"": ""c60e0974-d140-4597-a40e-9862193067e9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""ef05e207-d8e1-420e-adce-7050d905a771"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""fire1"",
                    ""type"": ""Button"",
                    ""id"": ""1077f913-a9f9-41b1-acb3-b9ee0adbc744"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""fire2"",
                    ""type"": ""Button"",
                    ""id"": ""0a8d3859-d265-43a0-b609-c8c594fe18dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""action1"",
                    ""type"": ""Button"",
                    ""id"": ""ae5c2018-a9fc-4912-a7e7-873b53bd2278"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""action2"",
                    ""type"": ""Button"",
                    ""id"": ""ec9511ff-6813-4dc2-a59a-74d546622c25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""action3"",
                    ""type"": ""Button"",
                    ""id"": ""e67d02be-ef02-4068-9702-6d08bf741c5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""cancel"",
                    ""type"": ""Button"",
                    ""id"": ""ee192a7f-9fcc-456b-a75c-ac6130a4e4dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwapTeam"",
                    ""type"": ""Button"",
                    ""id"": ""848bf847-1c7a-47c7-9f2c-bab54255e234"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TriggerMenu"",
                    ""type"": ""Button"",
                    ""id"": ""5c4cb5a9-d049-41f0-8d9f-9d903c8674fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UnlockCursor"",
                    ""type"": ""Button"",
                    ""id"": ""81e2163f-fce2-41ac-a8b9-a263579cde16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""abb776f3-f329-4f7b-bbf8-b577d13be018"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fire1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f600b210-50a5-4e0b-88f8-1719961eaa44"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""action1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""879da564-c889-4066-97ca-c2ee25861fff"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ecb30df-f12f-40ac-ab22-41acb81e1a3b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fire2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1b8c4dd-7b3a-4db6-a93a-0889b59b1afc"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Dpad"",
                    ""id"": ""cefc16fc-557a-44b0-939f-2ad792876b07"",
                    ""path"": ""Dpad(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""07244659-79df-461d-b329-defbe2fbc5f6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f0ec75cb-f02c-40d2-a33f-1fd6eab2ae0b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""21fe6bfe-4721-4483-9f4a-a0031ade105c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2dd39746-c75c-4a11-838a-e59eacaf4e0b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c106d6e6-2780-47ff-b318-396171bd54cc"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""578caa03-6827-4797-adfc-a59770c437fe"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=2,y=2)"",
                    ""groups"": """",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a48fa1b-b4b0-49e8-be4a-58dd4c1448db"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ca654b6-b7da-4c78-95d6-189ba1655e20"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6b81fee-7969-4be1-9be0-8bb073b9a143"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""action2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97d0162c-6186-40fb-897c-b9912acaf3f4"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""action3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7110c13-30e5-40e1-bbea-b121b24d6c9a"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapTeam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""733600e5-59d3-45fa-ba92-4dc9bee64200"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df563659-8dc1-40d5-8667-a06dde58eadc"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UnlockCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // gameplay
        m_gameplay = asset.FindActionMap("gameplay", throwIfNotFound: true);
        m_gameplay_move = m_gameplay.FindAction("move", throwIfNotFound: true);
        m_gameplay_look = m_gameplay.FindAction("look", throwIfNotFound: true);
        m_gameplay_jump = m_gameplay.FindAction("jump", throwIfNotFound: true);
        m_gameplay_fire1 = m_gameplay.FindAction("fire1", throwIfNotFound: true);
        m_gameplay_fire2 = m_gameplay.FindAction("fire2", throwIfNotFound: true);
        m_gameplay_action1 = m_gameplay.FindAction("action1", throwIfNotFound: true);
        m_gameplay_action2 = m_gameplay.FindAction("action2", throwIfNotFound: true);
        m_gameplay_action3 = m_gameplay.FindAction("action3", throwIfNotFound: true);
        m_gameplay_cancel = m_gameplay.FindAction("cancel", throwIfNotFound: true);
        m_gameplay_SwapTeam = m_gameplay.FindAction("SwapTeam", throwIfNotFound: true);
        m_gameplay_TriggerMenu = m_gameplay.FindAction("TriggerMenu", throwIfNotFound: true);
        m_gameplay_UnlockCursor = m_gameplay.FindAction("UnlockCursor", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // gameplay
    private readonly InputActionMap m_gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_gameplay_move;
    private readonly InputAction m_gameplay_look;
    private readonly InputAction m_gameplay_jump;
    private readonly InputAction m_gameplay_fire1;
    private readonly InputAction m_gameplay_fire2;
    private readonly InputAction m_gameplay_action1;
    private readonly InputAction m_gameplay_action2;
    private readonly InputAction m_gameplay_action3;
    private readonly InputAction m_gameplay_cancel;
    private readonly InputAction m_gameplay_SwapTeam;
    private readonly InputAction m_gameplay_TriggerMenu;
    private readonly InputAction m_gameplay_UnlockCursor;
    public struct GameplayActions
    {
        private @SimpleControls m_Wrapper;
        public GameplayActions(@SimpleControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_gameplay_move;
        public InputAction @look => m_Wrapper.m_gameplay_look;
        public InputAction @jump => m_Wrapper.m_gameplay_jump;
        public InputAction @fire1 => m_Wrapper.m_gameplay_fire1;
        public InputAction @fire2 => m_Wrapper.m_gameplay_fire2;
        public InputAction @action1 => m_Wrapper.m_gameplay_action1;
        public InputAction @action2 => m_Wrapper.m_gameplay_action2;
        public InputAction @action3 => m_Wrapper.m_gameplay_action3;
        public InputAction @cancel => m_Wrapper.m_gameplay_cancel;
        public InputAction @SwapTeam => m_Wrapper.m_gameplay_SwapTeam;
        public InputAction @TriggerMenu => m_Wrapper.m_gameplay_TriggerMenu;
        public InputAction @UnlockCursor => m_Wrapper.m_gameplay_UnlockCursor;
        public InputActionMap Get() { return m_Wrapper.m_gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @move.started += instance.OnMove;
            @move.performed += instance.OnMove;
            @move.canceled += instance.OnMove;
            @look.started += instance.OnLook;
            @look.performed += instance.OnLook;
            @look.canceled += instance.OnLook;
            @jump.started += instance.OnJump;
            @jump.performed += instance.OnJump;
            @jump.canceled += instance.OnJump;
            @fire1.started += instance.OnFire1;
            @fire1.performed += instance.OnFire1;
            @fire1.canceled += instance.OnFire1;
            @fire2.started += instance.OnFire2;
            @fire2.performed += instance.OnFire2;
            @fire2.canceled += instance.OnFire2;
            @action1.started += instance.OnAction1;
            @action1.performed += instance.OnAction1;
            @action1.canceled += instance.OnAction1;
            @action2.started += instance.OnAction2;
            @action2.performed += instance.OnAction2;
            @action2.canceled += instance.OnAction2;
            @action3.started += instance.OnAction3;
            @action3.performed += instance.OnAction3;
            @action3.canceled += instance.OnAction3;
            @cancel.started += instance.OnCancel;
            @cancel.performed += instance.OnCancel;
            @cancel.canceled += instance.OnCancel;
            @SwapTeam.started += instance.OnSwapTeam;
            @SwapTeam.performed += instance.OnSwapTeam;
            @SwapTeam.canceled += instance.OnSwapTeam;
            @TriggerMenu.started += instance.OnTriggerMenu;
            @TriggerMenu.performed += instance.OnTriggerMenu;
            @TriggerMenu.canceled += instance.OnTriggerMenu;
            @UnlockCursor.started += instance.OnUnlockCursor;
            @UnlockCursor.performed += instance.OnUnlockCursor;
            @UnlockCursor.canceled += instance.OnUnlockCursor;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @move.started -= instance.OnMove;
            @move.performed -= instance.OnMove;
            @move.canceled -= instance.OnMove;
            @look.started -= instance.OnLook;
            @look.performed -= instance.OnLook;
            @look.canceled -= instance.OnLook;
            @jump.started -= instance.OnJump;
            @jump.performed -= instance.OnJump;
            @jump.canceled -= instance.OnJump;
            @fire1.started -= instance.OnFire1;
            @fire1.performed -= instance.OnFire1;
            @fire1.canceled -= instance.OnFire1;
            @fire2.started -= instance.OnFire2;
            @fire2.performed -= instance.OnFire2;
            @fire2.canceled -= instance.OnFire2;
            @action1.started -= instance.OnAction1;
            @action1.performed -= instance.OnAction1;
            @action1.canceled -= instance.OnAction1;
            @action2.started -= instance.OnAction2;
            @action2.performed -= instance.OnAction2;
            @action2.canceled -= instance.OnAction2;
            @action3.started -= instance.OnAction3;
            @action3.performed -= instance.OnAction3;
            @action3.canceled -= instance.OnAction3;
            @cancel.started -= instance.OnCancel;
            @cancel.performed -= instance.OnCancel;
            @cancel.canceled -= instance.OnCancel;
            @SwapTeam.started -= instance.OnSwapTeam;
            @SwapTeam.performed -= instance.OnSwapTeam;
            @SwapTeam.canceled -= instance.OnSwapTeam;
            @TriggerMenu.started -= instance.OnTriggerMenu;
            @TriggerMenu.performed -= instance.OnTriggerMenu;
            @TriggerMenu.canceled -= instance.OnTriggerMenu;
            @UnlockCursor.started -= instance.OnUnlockCursor;
            @UnlockCursor.performed -= instance.OnUnlockCursor;
            @UnlockCursor.canceled -= instance.OnUnlockCursor;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFire1(InputAction.CallbackContext context);
        void OnFire2(InputAction.CallbackContext context);
        void OnAction1(InputAction.CallbackContext context);
        void OnAction2(InputAction.CallbackContext context);
        void OnAction3(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnSwapTeam(InputAction.CallbackContext context);
        void OnTriggerMenu(InputAction.CallbackContext context);
        void OnUnlockCursor(InputAction.CallbackContext context);
    }
}
