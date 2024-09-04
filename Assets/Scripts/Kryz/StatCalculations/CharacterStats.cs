using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Kryz.Stats
{
    [Serializable]
    public class CharacterStats : MonoBehaviour
    {
        public float BaseValue;

        public virtual float Value 
        { 
            get
            {
                if(reCalc || BaseValue != lastBaseValue)
                {
                    lastBaseValue = BaseValue;
                    _value = CalculateFinalValue();
                    reCalc = false;
                }
                return _value;
            }
        }

        protected bool reCalc = true;
        protected float _value;
        protected float lastBaseValue = float.MinValue;

        protected readonly List<StatsModifier> statMods;
        public readonly ReadOnlyCollection<StatsModifier> StatMods;

        public CharacterStats()
        {
            statMods = new List<StatsModifier>();
            StatMods = statMods.AsReadOnly();
        }

        public CharacterStats(float baseValue) : this()
        {  
            BaseValue = baseValue;
        }

        public virtual void AddModifier(StatsModifier mod)
        {
            reCalc = true;
            statMods.Add(mod);
            statMods.Sort(CompareModOrder);
        }

        protected virtual int CompareModOrder(StatsModifier a, StatsModifier b)
        {
            if (a.Order < b.Order)
                return -1;
            else if (a.Order > b.Order)
                return 1;
            return 0;
        }

        public virtual bool RemoveModifier(StatsModifier mod)
        {
            if(statMods.Remove(mod))
            {
                reCalc = true;
                return true;
            }
            return false;
        }

        public virtual bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;

            for(int i = statMods.Count - 1; i >= 0; i++)
            {
                if(statMods[i].Source == source)
                {
                    reCalc = true;
                    didRemove = true;
                    statMods.RemoveAt(i);
                }
            }
            return didRemove;
        }

        protected virtual float CalculateFinalValue()
        {
            float finalValue = BaseValue;
            float sumPercentAdd = 0;

            for(int i = 0; i < statMods.Count; i++)
            {
                StatsModifier mod = statMods[i];

                if(mod.Type == StatModType.Flat)
                {
                    finalValue += mod.Value;
                }
                else if (mod.Type == StatModType.PercentAdd)
                {
                    sumPercentAdd += mod.Value;

                    if(i + 1 >= statMods.Count || statMods[i + 1].Type != StatModType.PercentAdd)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                }
                else if(mod.Type == StatModType.PercentMult)
                {
                    finalValue *= 1 + mod.Value;
                }
            }
            return (float)Math.Round(finalValue, 4);
        }
    }
}
