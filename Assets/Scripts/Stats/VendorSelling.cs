using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorSelling : MonoBehaviour
{
    InventoryManager iManager;
    PlayerStats pStats;
    public int slimeGooPrice = 1;
    public int slimeGemPrice = 2;
    public int slimeSodaPrice = 3;
    public int slimePurificationCatalystPrice = 5;
    [Space]
    public int blobFertalizerPrice = 4;
    [Space]
    public int grainPrice = 2;
    public int cookiePrice = 7;

    void Start()
    {
        iManager = GameObject.FindWithTag("Inventory").GetComponent<InventoryManager>();
        pStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    public void SellSlimeGoo()
    {
        //remove a slime goo(ID 2) if you have at least one
        pStats.Gold += slimeGooPrice;
    }
    public void SellSlimeGem()
    {
        //remove a slime gem(ID 3) if you have at least one
        pStats.Gold += slimeGemPrice;
    }
    public void SellSlimeSoda()
    {
        //remove a slime soda(ID 4) if you have at least one
        pStats.Gold += slimeSodaPrice;
    }
    public void SellSlimePurificationCatalyst()
    {
        //remove a slime purification catalyst(ID 5) if you have at least one
        pStats.Gold += slimePurificationCatalystPrice;
    }
    public void SellBlobFertalizer()
    {
        //remove a blob fertalizer(ID 6) if you have at least one
        pStats.Gold += blobFertalizerPrice;
    }
    public void SellGrain()
    {
        //remove a grain(ID 9) if you have at least one
        pStats.Gold += grainPrice;
    }
    public void SellCookie()
    {
        //remove a Cookie(ID10) if you have at least one, Be Sad D:
        pStats.Gold += cookiePrice;
    }
}