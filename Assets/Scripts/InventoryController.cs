using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Dialogue;
    public CameraController CameraController;
    public Character Char;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Inventory.SetActive(!Inventory.activeInHierarchy);
            
            CameraController.enabled = !Inventory.activeInHierarchy;
            Char.enabled = !Inventory.activeInHierarchy;
        }
        if (Inventory.activeInHierarchy || Dialogue.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
