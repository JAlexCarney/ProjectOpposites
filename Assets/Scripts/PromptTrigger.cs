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

    public UnityEvent confirmEvent;

    public void Interact()
    {
        Action continueAction = null;

        if (confirmEvent.GetPersistentEventCount() > 0)
        {
            continueAction = confirmEvent.Invoke;
        }

        UIController.instance.modalWindow.ShowAsPrompt(title, image, message, continueAction);
    }
}
