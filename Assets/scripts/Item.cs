using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "InventoryScripts/InventoryItem")]
public class Item : ScriptableObject
{
    
    public string itemName;
    public int price;
    public Sprite icon;

    public int SellItem(int rarity)
    {
        int profit = price * rarity;

        return profit;
    }




}
