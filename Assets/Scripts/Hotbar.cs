using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private bool hidden = true;
    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void Show() {
        if (hidden == true) 
        {
            hidden = false;
            rt.anchoredPosition = new Vector2(0f, 75f);
        }
    }

    public void Hide() {
        if (hidden == false)
        {
            hidden = true;
            rt.anchoredPosition = new Vector2(0f, -75f);
        }
    }
}
