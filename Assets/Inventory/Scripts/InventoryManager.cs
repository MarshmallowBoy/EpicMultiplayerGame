using Unity.VisualScripting;
using UnityEngine;
using System;
public class InventoryManager : MouseInteract
{
    public ContainerInventory Container;
    public GameObject ContainerInventoryUI;
    public GameObject[] BobbleIndex;
    public GameObject[] HotbarSlots;
    public GameObject[] ContainerSlots;

    public static InventoryManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    void Update()
    {
        /*
        if (Input.GetButtonDown("Fire2"))
        {
            OpenChest();
            CollectItem();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && ContainerInventoryUI.activeInHierarchy)
        {
            ContainerInventoryUI.SetActive(false);
            UnloadInventory();
        }*/
    }

    public void CollectItem()
    {
        Debug.LogWarning("Collect Item Was Called");
    }

    public void OpenChest()
    {
        if (CompareMouseTag("Chest") && !ContainerInventoryUI.activeInHierarchy)
        {
            Container = returnMouseGameObject().GetComponent<ContainerInventory>();
            LoadInventory();
            ContainerInventoryUI.SetActive(true);
        }
    }

    public void OpenBody()
    {
        if (CompareMouseTag("DeadBody") && !ContainerInventoryUI.activeInHierarchy)
        {
            Container = returnMouseGameObject().GetComponent<ContainerInventory>();
            LoadInventory();
            ContainerInventoryUI.SetActive(true);
        }
    }

    public void LoadInventory()
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i] == null)
            {
                continue;
            }
            InventorySystemIdentification ISI = Container.Items[i].GetComponent<InventorySystemIdentification>();
            Instantiate(BobbleIndex[ISI.ID], ContainerSlots[i].transform);
        }
    }

    public void UnloadInventory()
    {
        for (int i = 0; i < ContainerSlots.Length; i++)
        {
            if (ContainerSlots[i].transform.childCount <= 0)
            {
                Container.Items[i] = null;
                continue;
            }
            //Container.Items[i] = ContainerSlots[i].transform.GetChild(0).gameObject;
            Container.Items[i] = BobbleIndex[ContainerSlots[i].GetComponentInChildren<InventorySystemIdentification>().ID];
        }
        foreach (var t in ContainerSlots)
        {
            if(t.transform.childCount > 0)
                DestroyImmediate(t.transform.GetChild(0).gameObject);
        }
    }

    public void GiveItem(int id)
    {
        for (int i = 0; i < ContainerSlots.Length; i++)
        {
            if (ContainerSlots[i].transform.childCount > 0)
            {
                continue;
            }
            Instantiate(BobbleIndex[id], ContainerSlots[i].transform);
            return;
        }
    }

    public void RemoveItem(int id)
    {
        for (int i = 0; i < ContainerSlots.Length; i++)
        {
            if (ContainerSlots[i].transform.childCount <= 0)
            {
                continue;
            }
            if (ContainerSlots[i].GetComponentInChildren<InventorySystemIdentification>().ID == id)
            {
                Destroy(ContainerSlots[i].GetComponentInChildren<Transform>().gameObject);
            }
            return;
        }
    }
}
