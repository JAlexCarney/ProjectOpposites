using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroWindowTrigger : MonoBehaviour
{
    public string title;
    public Sprite sprite;
    public string message;
    public bool triggerOnEnable;

    public UnityEvent onContinueCallback;
    public UnityEvent onDeclineCallback;
    public UnityEvent onAlternateCallback;

    public void OnEnable()
    {
        if(!triggerOnEnable) { return; }

        Action continueCallback = null;
        Action declineCallback = null;
        Action alternateCallback = null;

        if(onContinueCallback.GetPersistentEventCount() > 0)
        {
            continueCallback = onContinueCallback.Invoke;
        }

        if (onDeclineCallback.GetPersistentEventCount() > 0)
        {
            declineCallback = onDeclineCallback.Invoke;
        }

        if (onAlternateCallback.GetPersistentEventCount() > 0)
        {
            alternateCallback = onAlternateCallback.Invoke;
        }

        UIController.instance.modalWindow.ShowAsHero(title, sprite, message, continueCallback, declineCallback);
    }
}
