using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.Stats;

public enum EquipmentType { None, Hat, Chest, Gloves, Pants, Boots, Weapon, Accessory}

[CreateAssetMenu]
public class EquipableItem : Item
{
    public int HealthBonus;
    public int ManaBonus;
    public int DamageBonus;
    [Space]
    public float DamagePercentBonus1;
    [Space]
    public EquipmentType EquipmentType;

    public void Equip(SCharacter c)
    {
        if(HealthBonus != 0)
            c.Health.AddModifier(new StatsModifier(HealthBonus, StatModType.Flat, this));
        if (ManaBonus != 0)
            c.Mana.AddModifier(new StatsModifier(ManaBonus, StatModType.Flat, this));
        if (DamageBonus != 0)
            c.DamageF.AddModifier(new StatsModifier(DamageBonus, StatModType.Flat, this));
        if (DamagePercentBonus1 != 0)
            c.DamageP1.AddModifier(new StatsModifier(DamagePercentBonus1, StatModType.PercentAdd, this));
    }

    public void Unequip(SCharacter c)
    {
        c.Health.RemoveAllModifiersFromSource(this);
        c.Mana.RemoveAllModifiersFromSource(this);
        c.DamageF.RemoveAllModifiersFromSource(this);

        c.DamageP1.RemoveAllModifiersFromSource(this);
    }
}
