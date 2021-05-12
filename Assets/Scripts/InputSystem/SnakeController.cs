// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputSystem/SnakeController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @SnakeController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @SnakeController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SnakeController"",
    ""maps"": [
        {
            ""name"": ""Snake"",
            ""id"": ""86c1d5e5-0e44-48b9-a380-f8170c1aabae"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""5da8b92f-ec56-4d18-95f8-654f6af56e08"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8bb11d58-298e-46ba-9f7c-d7fcc7237dd3"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""HUD"",
            ""id"": ""4b39a9d3-47a9-4abc-bef8-c7a7d9ee8ba6"",
            ""actions"": [
                {
                    ""name"": ""Settings"",
                    ""type"": ""Value"",
                    ""id"": ""f19935f8-7aac-4ae1-be78-7534679dc498"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""693d7d86-4bed-4ae1-8f3f-6d02ea93fb8e"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""Settings"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Touchscreen"",
            ""bindingGroup"": ""Touchscreen"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Snake
        m_Snake = asset.FindActionMap("Snake", throwIfNotFound: true);
        m_Snake_Move = m_Snake.FindAction("Move", throwIfNotFound: true);
        // HUD
        m_HUD = asset.FindActionMap("HUD", throwIfNotFound: true);
        m_HUD_Settings = m_HUD.FindAction("Settings", throwIfNotFound: true);
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

    // Snake
    private readonly InputActionMap m_Snake;
    private ISnakeActions m_SnakeActionsCallbackInterface;
    private readonly InputAction m_Snake_Move;
    public struct SnakeActions
    {
        private @SnakeController m_Wrapper;
        public SnakeActions(@SnakeController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Snake_Move;
        public InputActionMap Get() { return m_Wrapper.m_Snake; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SnakeActions set) { return set.Get(); }
        public void SetCallbacks(ISnakeActions instance)
        {
            if (m_Wrapper.m_SnakeActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_SnakeActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_SnakeActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_SnakeActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_SnakeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public SnakeActions @Snake => new SnakeActions(this);

    // HUD
    private readonly InputActionMap m_HUD;
    private IHUDActions m_HUDActionsCallbackInterface;
    private readonly InputAction m_HUD_Settings;
    public struct HUDActions
    {
        private @SnakeController m_Wrapper;
        public HUDActions(@SnakeController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Settings => m_Wrapper.m_HUD_Settings;
        public InputActionMap Get() { return m_Wrapper.m_HUD; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HUDActions set) { return set.Get(); }
        public void SetCallbacks(IHUDActions instance)
        {
            if (m_Wrapper.m_HUDActionsCallbackInterface != null)
            {
                @Settings.started -= m_Wrapper.m_HUDActionsCallbackInterface.OnSettings;
                @Settings.performed -= m_Wrapper.m_HUDActionsCallbackInterface.OnSettings;
                @Settings.canceled -= m_Wrapper.m_HUDActionsCallbackInterface.OnSettings;
            }
            m_Wrapper.m_HUDActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Settings.started += instance.OnSettings;
                @Settings.performed += instance.OnSettings;
                @Settings.canceled += instance.OnSettings;
            }
        }
    }
    public HUDActions @HUD => new HUDActions(this);
    private int m_TouchscreenSchemeIndex = -1;
    public InputControlScheme TouchscreenScheme
    {
        get
        {
            if (m_TouchscreenSchemeIndex == -1) m_TouchscreenSchemeIndex = asset.FindControlSchemeIndex("Touchscreen");
            return asset.controlSchemes[m_TouchscreenSchemeIndex];
        }
    }
    public interface ISnakeActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IHUDActions
    {
        void OnSettings(InputAction.CallbackContext context);
    }
}
