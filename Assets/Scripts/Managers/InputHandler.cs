using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InputHandler : MonoBehaviour
{

    CrossPlatformInputManager.VirtualButton fire;

    private void Start()
    {
        CreateVirtualInput();
    }


    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID || UNITY_IOS
        HandleInputMobile();
#endif
        HandleInput();
    }

    private void CreateVirtualInput()
    {
        fire = new CrossPlatformInputManager.VirtualButton(Statics.FIRE_BUTTON);
        CrossPlatformInputManager.RegisterVirtualButton(fire);
    }

    private void HandleInputMobile()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    EventManager.TouchBegin();
                    break;
                case TouchPhase.Ended:
                    EventManager.TouchEnd();
                    break;
                default: break;
            }
        }
    }

    private void HandleInput()
    {
        if (CrossPlatformInputManager.GetButtonDown(Statics.FIRE_BUTTON))
        {
            EventManager.TouchBegin();
        }
        else if (CrossPlatformInputManager.GetButtonUp(Statics.FIRE_BUTTON))
        {
            EventManager.TouchEnd();
        }
    }
}
