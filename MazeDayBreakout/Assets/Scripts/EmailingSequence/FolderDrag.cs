using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FolderDrag : MonoBehaviour, IDragHandler
{
    public GameObject hoverBkgd, folderPrompt, fileUploadText;
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

    private void OnDrop()
    {
        Destroy(folder.gameObject);
        fileUploadText.SetActive(true);
    }
}
