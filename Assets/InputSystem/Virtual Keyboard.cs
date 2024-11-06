//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.8.1
//     from Assets/InputSystem/Virtual Keyboard.inputactions
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
using UnityEngine;

public partial class @VirtualKeyboard: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @VirtualKeyboard()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Virtual Keyboard"",
    ""maps"": [
        {
            ""name"": ""VKeyboard"",
            ""id"": ""b32e933a-3d6d-4af5-9e94-53f20196614b"",
            ""actions"": [
                {
                    ""name"": ""Left Joystick"",
                    ""type"": ""Value"",
                    ""id"": ""2a6fd241-f9cb-4564-98eb-d59cdb426129"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Left Click"",
                    ""type"": ""Button"",
                    ""id"": ""382dbbee-1ee0-4c61-9a45-b505dc536957"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right Joystick"",
                    ""type"": ""Value"",
                    ""id"": ""10e356fa-77f7-4dc3-b174-7cc1d1ff733e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Right Click"",
                    ""type"": ""Button"",
                    ""id"": ""575a162e-b7eb-49ec-a0f9-88a596ccedbe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left Prim"",
                    ""type"": ""Button"",
                    ""id"": ""087c073e-16ab-4c51-a49b-090d1ccc3ea3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left Secondary"",
                    ""type"": ""Button"",
                    ""id"": ""9b55a27e-06ae-4ede-9bc5-ccb1ac4b8700"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right Prim"",
                    ""type"": ""Button"",
                    ""id"": ""381bf256-b794-481d-9556-d46eb5246773"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right Secondary"",
                    ""type"": ""Button"",
                    ""id"": ""2b9fbb1d-5ec6-430a-a6a5-deaef4207440"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""51390bdf-7cc5-4a84-b8a2-efe164d0de00"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Joystick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""be88ed41-4fb8-4384-8683-820de4413528"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Left Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""44c5450d-89f2-4c58-ab0b-0e963622b191"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Left Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7ddbfdbc-35ad-4fa2-bb6b-fb2494bb3d19"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Left Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d7e8bdb0-046f-4d7c-9e3b-17e585852854"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Left Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""70b5708d-a9ea-4bcc-9da4-3cf148265e07"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Left Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""622e16f6-2410-43c9-a8bb-ec71ff50df40"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Joystick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""47a846bd-6c1f-4a4f-b552-36e9116efaf7"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Right Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""be285d8c-4f0e-4f86-af87-4c9bd2783551"",
                    ""path"": ""<Keyboard>/period"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Right Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9ae76ee1-561b-4413-8792-c29fbda6d2c6"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Right Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""40a4b54b-72f7-49c5-97ef-8c053fa9210f"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Right Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""07caa2b3-ccdf-48cd-a9b4-2333283ed45c"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Right Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21060cc5-b0bf-4f4f-9615-0eb54589c5a7"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Left Prim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e6bd7bf-cac1-421f-8432-934d38c05c1f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Left Secondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61af0bde-8818-49ef-94d1-9da777b10cc5"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Right Prim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acdd5f21-009e-4296-a535-1d05b203f17d"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Right Secondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""EyeFlick"",
            ""id"": ""f7102457-cc4a-43dd-8aa5-a5a281adc366"",
            ""actions"": [
                {
                    ""name"": ""Shift"",
                    ""type"": ""Button"",
                    ""id"": ""f0a122c2-f0e4-409e-827b-bc024f26c59f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ctrl"",
                    ""type"": ""Button"",
                    ""id"": ""76bfbd29-6113-4840-8c3e-584937cf6337"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectVowel"",
                    ""type"": ""Value"",
                    ""id"": ""88c205a1-2609-4159-8eb2-483ba5dc258b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""line"",
                    ""type"": ""Button"",
                    ""id"": ""7ddd93ca-2c07-472e-88ff-b8b3a19bbcda"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""yi"",
                    ""type"": ""Button"",
                    ""id"": ""8cfda3a5-3d49-45bc-b97b-f209e2b91667"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Tab"",
                    ""type"": ""Button"",
                    ""id"": ""4d610014-067d-452f-9cf1-2cd3815e8333"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ebd01091-3c62-4155-9710-3f40d3a6192e"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Shift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b647012-15ff-4933-aec8-53ead070d505"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ctrl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ab603d1f-e29c-4105-969d-e951ef848dbd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectVowel"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""aa1343e7-99ce-445b-83c5-6a4efd927829"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectVowel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a09b6c7f-23cc-4268-bec9-ae98b4cf44e0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectVowel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d58a6193-853d-4557-a3f3-d71a93ca4ce4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectVowel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b0d16009-c5e3-4a13-81b4-d2b3235ef77f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectVowel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""698041d6-617c-4dcd-8bfb-5eaf5b3b4c1d"",
                    ""path"": ""<Mouse>/forwardButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""line"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dedf5184-1ab7-4211-9606-13208209ac89"",
                    ""path"": ""<Mouse>/backButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""yi"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7864c373-8c10-4d46-85a1-c728a4cfe868"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";PC"",
                    ""action"": ""Tab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // VKeyboard
        m_VKeyboard = asset.FindActionMap("VKeyboard", throwIfNotFound: true);
        m_VKeyboard_LeftJoystick = m_VKeyboard.FindAction("Left Joystick", throwIfNotFound: true);
        m_VKeyboard_LeftClick = m_VKeyboard.FindAction("Left Click", throwIfNotFound: true);
        m_VKeyboard_RightJoystick = m_VKeyboard.FindAction("Right Joystick", throwIfNotFound: true);
        m_VKeyboard_RightClick = m_VKeyboard.FindAction("Right Click", throwIfNotFound: true);
        m_VKeyboard_LeftPrim = m_VKeyboard.FindAction("Left Prim", throwIfNotFound: true);
        m_VKeyboard_LeftSecondary = m_VKeyboard.FindAction("Left Secondary", throwIfNotFound: true);
        m_VKeyboard_RightPrim = m_VKeyboard.FindAction("Right Prim", throwIfNotFound: true);
        m_VKeyboard_RightSecondary = m_VKeyboard.FindAction("Right Secondary", throwIfNotFound: true);
        // EyeFlick
        m_EyeFlick = asset.FindActionMap("EyeFlick", throwIfNotFound: true);
        m_EyeFlick_Shift = m_EyeFlick.FindAction("Shift", throwIfNotFound: true);
        m_EyeFlick_Ctrl = m_EyeFlick.FindAction("Ctrl", throwIfNotFound: true);
        m_EyeFlick_SelectVowel = m_EyeFlick.FindAction("SelectVowel", throwIfNotFound: true);
        m_EyeFlick_line = m_EyeFlick.FindAction("line", throwIfNotFound: true);
        m_EyeFlick_yi = m_EyeFlick.FindAction("yi", throwIfNotFound: true);
        m_EyeFlick_Tab = m_EyeFlick.FindAction("Tab", throwIfNotFound: true);
    }

    ~@VirtualKeyboard()
    {
        Debug.Assert(!m_VKeyboard.enabled, "This will cause a leak and performance issues, VirtualKeyboard.VKeyboard.Disable() has not been called.");
        Debug.Assert(!m_EyeFlick.enabled, "This will cause a leak and performance issues, VirtualKeyboard.EyeFlick.Disable() has not been called.");
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

    // VKeyboard
    private readonly InputActionMap m_VKeyboard;
    private List<IVKeyboardActions> m_VKeyboardActionsCallbackInterfaces = new List<IVKeyboardActions>();
    private readonly InputAction m_VKeyboard_LeftJoystick;
    private readonly InputAction m_VKeyboard_LeftClick;
    private readonly InputAction m_VKeyboard_RightJoystick;
    private readonly InputAction m_VKeyboard_RightClick;
    private readonly InputAction m_VKeyboard_LeftPrim;
    private readonly InputAction m_VKeyboard_LeftSecondary;
    private readonly InputAction m_VKeyboard_RightPrim;
    private readonly InputAction m_VKeyboard_RightSecondary;
    public struct VKeyboardActions
    {
        private @VirtualKeyboard m_Wrapper;
        public VKeyboardActions(@VirtualKeyboard wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftJoystick => m_Wrapper.m_VKeyboard_LeftJoystick;
        public InputAction @LeftClick => m_Wrapper.m_VKeyboard_LeftClick;
        public InputAction @RightJoystick => m_Wrapper.m_VKeyboard_RightJoystick;
        public InputAction @RightClick => m_Wrapper.m_VKeyboard_RightClick;
        public InputAction @LeftPrim => m_Wrapper.m_VKeyboard_LeftPrim;
        public InputAction @LeftSecondary => m_Wrapper.m_VKeyboard_LeftSecondary;
        public InputAction @RightPrim => m_Wrapper.m_VKeyboard_RightPrim;
        public InputAction @RightSecondary => m_Wrapper.m_VKeyboard_RightSecondary;
        public InputActionMap Get() { return m_Wrapper.m_VKeyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VKeyboardActions set) { return set.Get(); }
        public void AddCallbacks(IVKeyboardActions instance)
        {
            if (instance == null || m_Wrapper.m_VKeyboardActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_VKeyboardActionsCallbackInterfaces.Add(instance);
            @LeftJoystick.started += instance.OnLeftJoystick;
            @LeftJoystick.performed += instance.OnLeftJoystick;
            @LeftJoystick.canceled += instance.OnLeftJoystick;
            @LeftClick.started += instance.OnLeftClick;
            @LeftClick.performed += instance.OnLeftClick;
            @LeftClick.canceled += instance.OnLeftClick;
            @RightJoystick.started += instance.OnRightJoystick;
            @RightJoystick.performed += instance.OnRightJoystick;
            @RightJoystick.canceled += instance.OnRightJoystick;
            @RightClick.started += instance.OnRightClick;
            @RightClick.performed += instance.OnRightClick;
            @RightClick.canceled += instance.OnRightClick;
            @LeftPrim.started += instance.OnLeftPrim;
            @LeftPrim.performed += instance.OnLeftPrim;
            @LeftPrim.canceled += instance.OnLeftPrim;
            @LeftSecondary.started += instance.OnLeftSecondary;
            @LeftSecondary.performed += instance.OnLeftSecondary;
            @LeftSecondary.canceled += instance.OnLeftSecondary;
            @RightPrim.started += instance.OnRightPrim;
            @RightPrim.performed += instance.OnRightPrim;
            @RightPrim.canceled += instance.OnRightPrim;
            @RightSecondary.started += instance.OnRightSecondary;
            @RightSecondary.performed += instance.OnRightSecondary;
            @RightSecondary.canceled += instance.OnRightSecondary;
        }

        private void UnregisterCallbacks(IVKeyboardActions instance)
        {
            @LeftJoystick.started -= instance.OnLeftJoystick;
            @LeftJoystick.performed -= instance.OnLeftJoystick;
            @LeftJoystick.canceled -= instance.OnLeftJoystick;
            @LeftClick.started -= instance.OnLeftClick;
            @LeftClick.performed -= instance.OnLeftClick;
            @LeftClick.canceled -= instance.OnLeftClick;
            @RightJoystick.started -= instance.OnRightJoystick;
            @RightJoystick.performed -= instance.OnRightJoystick;
            @RightJoystick.canceled -= instance.OnRightJoystick;
            @RightClick.started -= instance.OnRightClick;
            @RightClick.performed -= instance.OnRightClick;
            @RightClick.canceled -= instance.OnRightClick;
            @LeftPrim.started -= instance.OnLeftPrim;
            @LeftPrim.performed -= instance.OnLeftPrim;
            @LeftPrim.canceled -= instance.OnLeftPrim;
            @LeftSecondary.started -= instance.OnLeftSecondary;
            @LeftSecondary.performed -= instance.OnLeftSecondary;
            @LeftSecondary.canceled -= instance.OnLeftSecondary;
            @RightPrim.started -= instance.OnRightPrim;
            @RightPrim.performed -= instance.OnRightPrim;
            @RightPrim.canceled -= instance.OnRightPrim;
            @RightSecondary.started -= instance.OnRightSecondary;
            @RightSecondary.performed -= instance.OnRightSecondary;
            @RightSecondary.canceled -= instance.OnRightSecondary;
        }

        public void RemoveCallbacks(IVKeyboardActions instance)
        {
            if (m_Wrapper.m_VKeyboardActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IVKeyboardActions instance)
        {
            foreach (var item in m_Wrapper.m_VKeyboardActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_VKeyboardActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public VKeyboardActions @VKeyboard => new VKeyboardActions(this);

    // EyeFlick
    private readonly InputActionMap m_EyeFlick;
    private List<IEyeFlickActions> m_EyeFlickActionsCallbackInterfaces = new List<IEyeFlickActions>();
    private readonly InputAction m_EyeFlick_Shift;
    private readonly InputAction m_EyeFlick_Ctrl;
    private readonly InputAction m_EyeFlick_SelectVowel;
    private readonly InputAction m_EyeFlick_line;
    private readonly InputAction m_EyeFlick_yi;
    private readonly InputAction m_EyeFlick_Tab;
    public struct EyeFlickActions
    {
        private @VirtualKeyboard m_Wrapper;
        public EyeFlickActions(@VirtualKeyboard wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shift => m_Wrapper.m_EyeFlick_Shift;
        public InputAction @Ctrl => m_Wrapper.m_EyeFlick_Ctrl;
        public InputAction @SelectVowel => m_Wrapper.m_EyeFlick_SelectVowel;
        public InputAction @line => m_Wrapper.m_EyeFlick_line;
        public InputAction @yi => m_Wrapper.m_EyeFlick_yi;
        public InputAction @Tab => m_Wrapper.m_EyeFlick_Tab;
        public InputActionMap Get() { return m_Wrapper.m_EyeFlick; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EyeFlickActions set) { return set.Get(); }
        public void AddCallbacks(IEyeFlickActions instance)
        {
            if (instance == null || m_Wrapper.m_EyeFlickActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_EyeFlickActionsCallbackInterfaces.Add(instance);
            @Shift.started += instance.OnShift;
            @Shift.performed += instance.OnShift;
            @Shift.canceled += instance.OnShift;
            @Ctrl.started += instance.OnCtrl;
            @Ctrl.performed += instance.OnCtrl;
            @Ctrl.canceled += instance.OnCtrl;
            @SelectVowel.started += instance.OnSelectVowel;
            @SelectVowel.performed += instance.OnSelectVowel;
            @SelectVowel.canceled += instance.OnSelectVowel;
            @line.started += instance.OnLine;
            @line.performed += instance.OnLine;
            @line.canceled += instance.OnLine;
            @yi.started += instance.OnYi;
            @yi.performed += instance.OnYi;
            @yi.canceled += instance.OnYi;
            @Tab.started += instance.OnTab;
            @Tab.performed += instance.OnTab;
            @Tab.canceled += instance.OnTab;
        }

        private void UnregisterCallbacks(IEyeFlickActions instance)
        {
            @Shift.started -= instance.OnShift;
            @Shift.performed -= instance.OnShift;
            @Shift.canceled -= instance.OnShift;
            @Ctrl.started -= instance.OnCtrl;
            @Ctrl.performed -= instance.OnCtrl;
            @Ctrl.canceled -= instance.OnCtrl;
            @SelectVowel.started -= instance.OnSelectVowel;
            @SelectVowel.performed -= instance.OnSelectVowel;
            @SelectVowel.canceled -= instance.OnSelectVowel;
            @line.started -= instance.OnLine;
            @line.performed -= instance.OnLine;
            @line.canceled -= instance.OnLine;
            @yi.started -= instance.OnYi;
            @yi.performed -= instance.OnYi;
            @yi.canceled -= instance.OnYi;
            @Tab.started -= instance.OnTab;
            @Tab.performed -= instance.OnTab;
            @Tab.canceled -= instance.OnTab;
        }

        public void RemoveCallbacks(IEyeFlickActions instance)
        {
            if (m_Wrapper.m_EyeFlickActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IEyeFlickActions instance)
        {
            foreach (var item in m_Wrapper.m_EyeFlickActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_EyeFlickActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public EyeFlickActions @EyeFlick => new EyeFlickActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IVKeyboardActions
    {
        void OnLeftJoystick(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
        void OnRightJoystick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnLeftPrim(InputAction.CallbackContext context);
        void OnLeftSecondary(InputAction.CallbackContext context);
        void OnRightPrim(InputAction.CallbackContext context);
        void OnRightSecondary(InputAction.CallbackContext context);
    }
    public interface IEyeFlickActions
    {
        void OnShift(InputAction.CallbackContext context);
        void OnCtrl(InputAction.CallbackContext context);
        void OnSelectVowel(InputAction.CallbackContext context);
        void OnLine(InputAction.CallbackContext context);
        void OnYi(InputAction.CallbackContext context);
        void OnTab(InputAction.CallbackContext context);
    }
}
