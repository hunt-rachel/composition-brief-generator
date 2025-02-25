using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltip; 
    
    // Start is called before the first frame update
    void Start()
    {
        //in case tooltip object not set
        if(tooltip != null)
        {
            tooltip.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //same here?
        if (tooltip != null)
        {
            tooltip.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //same here?
        if (tooltip != null)
        {
            tooltip.SetActive(false);
        }
    }
}
