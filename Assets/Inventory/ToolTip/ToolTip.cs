using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolTip : MouseInteract
{
    public TextMeshProUGUI toolTipText;
    public PointerEventData m_PointerEventData;
    public GraphicRaycaster m_Raycaster;
    public EventSystem m_EventSystem;
    public GameObject optionsMenu;
    public GameObject ActiveBobble;
    public bool NoRaycast;
    public bool NoResults;

    private void Awake()
    {
        m_EventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    private void Update()
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);
        if (results.Count > 0)
        {
            NoResults = true;
            foreach (RaycastResult result in results)
            {
                if(result.gameObject.CompareTag("Bobble") && !optionsMenu.activeInHierarchy){
                    InventorySystemIdentification ISI = result.gameObject.GetComponent<InventorySystemIdentification>();
                    ActiveBobble = result.gameObject;
                    transform.position = Input.mousePosition;
                    toolTipText.text = ISI.Name;
                    NoResults = false;
                    if (Input.GetButtonDown("Fire2"))
                    {
                        if (ISI.ID == 4 || ISI.ID == 2 || ISI.ID == 6 || ISI.ID == 1 || ISI.ID == 7)
                        {
                            optionsMenu.SetActive(true);
                        }
                    }
                }
            }
        }
        else
        {
            NoResults = true;
        }

        if (NoRaycast && NoResults)
        {
            toolTipText.text = "";
        }

        if (!optionsMenu.activeInHierarchy)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void EatAction()
    {
        Destroy(ActiveBobble);
    }
}