using Unity.VisualScripting;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Dialogue;
    public CameraController CameraController;
    public Character Char;
    public Canvas iCanvas;
    public GameObject TrainerUI;
    public GameObject VendorUI;

    void Awake()
    {
        Inventory = GameObject.Find("InventoryCanvas");
        iCanvas = Inventory.GetComponent<Canvas>();
        if(TrainerUI == null)
        {
            TrainerUI = GameObject.Find("TrainerUI");
        }
        if(VendorUI == null)
        {
            VendorUI = GameObject.Find("VendorUI");
        }
        iCanvas.enabled = false;
        DontDestroyOnLoad(Inventory);
    }

    void Update()
    {
        if(Inventory == null) { Inventory = GameObject.Find("InventoryCanvas"); }
        if(TrainerUI != null)
        {
            if(TrainerUI.activeInHierarchy || VendorUI.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                TrainerUI.SetActive(false);
                VendorUI.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            iCanvas.enabled = !iCanvas.enabled;
            
            CameraController.enabled = !iCanvas.enabled;
            Char.enabled = !iCanvas.enabled;
        }

        if(iCanvas.enabled == true || Dialogue.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
