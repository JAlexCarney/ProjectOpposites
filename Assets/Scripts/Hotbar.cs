using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private bool hidden = true;
    private RectTransform rt;
    private readonly int baseX = 63;
    private readonly int offX = 130;
    public int selected = 0;
    private int numSlots = 6;
    private RectTransform highlightrt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        highlightrt = transform.GetChild(0).GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y > 0.1)
        {
            Select((selected + 1) % numSlots);
        }
        else if (Input.mouseScrollDelta.y < -0.1) 
        {
            if (selected == 0)
            {
                Select(numSlots - 1);
            }
            else 
            {
                Select(selected - 1);
            }
        }
    }

    public void Select(int i)
    {
        highlightrt.anchoredPosition = new Vector2(baseX + i*offX, 0f);
        selected = i;
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
