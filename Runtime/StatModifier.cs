using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitStats
{
    [System.Serializable]
    public class StatModifier
    {
        public float Amount;
        public StatModifierType Type;
        public Object Source;

        public StatModifier(float amount, StatModifierType type, Object source)
        {
            Amount = amount;
            Type = type;
            Source = source;
        }
    }

    public enum StatModifierType
    {
        Additive,
        Increased,
        More
    }
}