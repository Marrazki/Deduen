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

    public bool UseItem()
    {
        Debug.Log("Using " + itemName);
        if (statToChange == StatToChange.health)
        {
            PlayerData playerData = GameObject.Find("Player").GetComponent<PlayerData>();
            if (playerData.vida == playerData.vidaMax)
            {
                return false;
            }
            else
            {
                playerData.Curar(amountToChangeStat);
                return true;
            }
        }
        return false;
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
