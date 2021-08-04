using UnityEngine;

public class AcceptFolder : MonoBehaviour
{
    public GameObject uploadSucessful;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonUp(0) && other.gameObject.CompareTag("Folder"))
        {
            Destroy(other.gameObject);
            uploadSucessful.SetActive(true);
            Destroy(gameObject);
        }
    }
}
