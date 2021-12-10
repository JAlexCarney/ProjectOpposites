using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PromptTrigger : MonoBehaviour
{
    public string title;
    public Sprite image;

    [TextArea(3, 10)]
    public string message;

    public UnityEvent onContinueCallback;
    public UnityEvent onDeclineCallback;

    public void OnEnable()
    {
        Action continueCallback = null;
        Action declineCallback = null;

        if (onContinueCallback.GetPersistentEventCount() > 0)
        {
            continueCallback = onContinueCallback.Invoke;
        }

        if (onDeclineCallback.GetPersistentEventCount() > 0)
        {
            declineCallback = onDeclineCallback.Invoke;
        }

        UIController.instance.modalWindow.ShowAsPrompt(title, image, message, continueCallback, declineCallback);
    }
}
