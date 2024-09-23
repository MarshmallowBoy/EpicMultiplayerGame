using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public inventorySlot Input1;
    public inventorySlot Input2;
    public inventorySlot Output;
    float CountLastFrame = 0;
    float CountLastFrame2 = 0;
    public InventoryManager InventoryManager;
    private void Update()
    {
        if (Input1.transform.childCount != CountLastFrame)
        {
            CountLastFrame = Input1.transform.childCount;
            InstantiateCraftingRecipe(RecipeParser());
        }
        if (Input2.transform.childCount != CountLastFrame2)
        {
            CountLastFrame2 = Input2.transform.childCount;
            InstantiateCraftingRecipe(RecipeParser());
        }
    }

    public int RecipeParser()
    {
        if (Input1.transform.childCount == 0 || Input2.transform.childCount == 0) { return 0; }
        Vector2Int IDs = new Vector2Int(Input1.GetComponentInChildren<InventorySystemIdentification>().ID, Input2.GetComponentInChildren<InventorySystemIdentification>().ID);
        foreach (Vector3Int Recipe in Recipes)
        {
            if (Recipe.x == IDs.x && Recipe.y == IDs.y)
            {
                return Recipe.z;
            }
        }
        return 0;
    }

    public void InstantiateCraftingRecipe(int ID)
    {
        if(ID == 0)
        {
            /*
            foreach (Transform child in Output.transform)
            {
                Destroy(child.gameObject);
            }*/
            return;
        }
        if(Output.transform.childCount > 0)
        {
            foreach (Transform child in Output.transform)
            {
                Destroy(child.gameObject);
            }
        }
        if(ID != 0)
        {
            foreach (Transform child in Input1.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in Input2.transform)
            {
                Destroy(child.gameObject);
            }
        }
        Instantiate(InventoryManager.BobbleIndex[ID], Output.transform);
    }

    public List<Vector3Int> Recipes = new List<Vector3Int>();

    public void Start()
    {
        Recipes.Add(new Vector3Int(4, 2, 1));
        Recipes.Add(new Vector3Int(2, 2, 3));
        Recipes.Add(new Vector3Int(2, 3, 4));
        Recipes.Add(new Vector3Int(3, 3, 5));
        Recipes.Add(new Vector3Int(9, 9, 10));
    }
}