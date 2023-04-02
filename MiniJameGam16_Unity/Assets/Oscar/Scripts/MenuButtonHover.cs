using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image catLeft;
    public Image catRight;

    // Start is called before the first frame update
    void Start()
    {
        catLeft.enabled = false;
        catRight.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        catLeft.enabled = true;
        catRight.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        catLeft.enabled = false;
        catRight.enabled = false;
    }
}
