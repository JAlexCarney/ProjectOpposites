using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModalWindowPanel : MonoBehaviour
{
    [Header("Header")]
    [SerializeField]
    private Transform _headerArea;
    [SerializeField]
    private TextMeshProUGUI _titleField;

    [Header("Content")]
    [SerializeField]
    private Transform _contentArea;
    [SerializeField]
    private Transform _verticalLayoutArea;
    [SerializeField]
    private Image _heroImage;
    [SerializeField]
    private TextMeshProUGUI _heroText;

    [Space]

    [SerializeField]
    private Transform _horizontalLayoutArea;
    [SerializeField]
    private Transform _iconContainer;
    [SerializeField]
    private Image _iconImage;
    [SerializeField]
    private TextMeshProUGUI _iconText;

    [Header("Footer")]
    [SerializeField]
    private Transform _footerArea;
    [SerializeField]
    private Button _confirmButton;
    [SerializeField]
    private TextMeshProUGUI _confirmText;
    [SerializeField]
    private Button _declineButton;
    [SerializeField]
    private TextMeshProUGUI _declineText;
    [SerializeField]
    private Button _alternateButton;
    [SerializeField]
    private TextMeshProUGUI _alternateText;

    private Action onConfirmEvent;
    private Action onDeclineEvent;
    private Action onAlternateEvent;

    public void Confirm()
    {
        onConfirmEvent?.Invoke();
    }

    public void Decline()
    {
        onDeclineEvent?.Invoke();
    }

    public void Alternate()
    {
        onAlternateEvent?.Invoke();
    }

    public void ShowAsHero(string title, Sprite imageToShow, string message, string confirmMessage, string declineMessage, string alternateMessage, Action confirmAction, Action declineAction = null, Action alternateAction = null)
    {
        _horizontalLayoutArea.gameObject.SetActive(false);
        _verticalLayoutArea.gameObject.SetActive(true);

        // Hide header if no title.
        bool hasTitle = string.IsNullOrEmpty(title);
        _headerArea.gameObject.SetActive(!hasTitle);
        _titleField.text = title;

        _heroImage.sprite = imageToShow;
        _heroText.text = message;

        onConfirmEvent = confirmAction;
        _confirmText.text = confirmMessage;

        bool hasDecline = (declineAction != null);
        _declineButton.gameObject.SetActive(hasDecline);
        onDeclineEvent = declineAction;
        _declineText.text = declineMessage;

        bool hasAlternate = (alternateAction != null);
        _alternateButton.gameObject.SetActive(hasAlternate);
        onAlternateEvent = alternateAction;
        _alternateText.text = alternateMessage;

        Show();
    }

    public void ShowAsHero(string title, Sprite imageToShow, string message, Action confirmAction)
    {
        ShowAsHero(title, imageToShow, message, "Continue", "", "", confirmAction);
    }

    public void ShowAsHero(string title, Sprite imageToShow, string message, Action confirmAction, Action declineAction)
    {
        ShowAsHero(title, imageToShow, message, "Continue", "Back", "", confirmAction, declineAction);
    }

    public void ShowAsPrompt(string title, Sprite imageToShow, string message, string confirmMessage, string declineMessage, string alternateMessage, Action confirmAction, Action declineAction = null, Action alternateAction = null)
    {
        _verticalLayoutArea.gameObject.SetActive(false);
        _horizontalLayoutArea.gameObject.SetActive(true);

        // Hide header if no title.
        bool hasTitle = string.IsNullOrEmpty(title);
        _headerArea.gameObject.SetActive(!hasTitle);
        _titleField.text = title;

        _iconImage.sprite = imageToShow;
        _iconText.text = message;

        onConfirmEvent = confirmAction;
        _confirmText.text = confirmMessage;

        bool hasDecline = (declineAction != null);
        _declineButton.gameObject.SetActive(hasDecline);
        onDeclineEvent = declineAction;
        _declineText.text = declineMessage;

        bool hasAlternate = (alternateAction != null);
        _alternateButton.gameObject.SetActive(hasAlternate);
        onAlternateEvent = alternateAction;
        _alternateText.text = alternateMessage;

        Show();
    }

    public void ShowAsPrompt(string title, Sprite imageToShow, string message, Action confirmAction)
    {
        ShowAsPrompt(title, imageToShow, message, "Continue", "", "", confirmAction);
    }

    public void ShowAsPrompt(string title, Sprite imageToShow, string message, Action confirmAction, Action declineAction)
    {
        ShowAsPrompt(title, imageToShow, message, "Continue", "Back", "", confirmAction, declineAction);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

}
