using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FolderDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject hoverBkgd;
    public RectTransform folder;
    public void OnHighLight()
    {
        hoverBkgd.SetActive(true);
        //for highlighting the object
    }
    public void OffHighLight()
    {
        hoverBkgd.SetActive(false);
    }
    private void Start()
    {
        folder = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        folder.anchoredPosition += eventData.delta;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
