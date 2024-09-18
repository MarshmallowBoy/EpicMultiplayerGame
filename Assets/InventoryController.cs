using Autodesk.Fbx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject Inventory;
    public CameraController CameraController;
    public Character Char;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Inventory.SetActive(!Inventory.activeInHierarchy);
            if (Inventory.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            CameraController.enabled = !Inventory.activeInHierarchy;
            Char.enabled = !Inventory.activeInHierarchy;
        }
    }
}
