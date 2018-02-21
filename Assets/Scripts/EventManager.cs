using System;

public class EventManager
{
    public static Action OnTouchBegin;
    public static Action OnTouchEnd;
    public static Action OnTap;

    public static void TouchBegin()
    {
        if (OnTouchBegin != null)
        {
            OnTouchBegin();
        }
    }

    public static void TouchEnd()
    {
        if (OnTouchEnd != null)
        {
            OnTouchEnd();
        }
    }

    public static void Tap()
    {
        if (OnTap != null)
        {
            OnTap();
        }
    }
}
