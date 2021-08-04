using UnityEngine;

public class AcceptFolder : MonoBehaviour
{
    public GameObject uploadSucessful, folder;
    public RectTransform rect, folderRect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        folderRect = folder.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && CheckDistance())
        {
            Destroy(folder);
            uploadSucessful.SetActive(true);
            Destroy(gameObject);
        }
    }
    private bool CheckDistance()
    {
        return Vector2.Distance(rect.position, folderRect.position) < 300;
    }
}
