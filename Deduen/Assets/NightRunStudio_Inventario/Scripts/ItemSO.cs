using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemSO;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public AttributeToChange attributeToChange = new AttributeToChange();

    public void Use()
    {
        Debug.Log("Using " + itemName);
        if (statToChange == StatToChange.health)
        { 
            GameObject.Find("Player").GetComponent<PlayerData>().Curar(amountToChangeStat);
        }
    }
    public enum StatToChange
    {
        none,
        health,
        mana,
        stamina
    };

    public enum AttributeToChange
    {
        none,
        strength,
        defense,
        agility
    };
}
