using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Dialogue;
    public CameraController CameraController;
    public Character Char;
    public GameObject TrainerUI;
    public GameObject VendorUI;
    void Update()
    {
        if (TrainerUI != null)
        {
            if (TrainerUI.activeInHierarchy || VendorUI.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TrainerUI.SetActive(false);
                VendorUI.SetActive(false);
            }
        }
        

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
