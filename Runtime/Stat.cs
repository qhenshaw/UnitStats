using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitStats
{
    [System.Serializable]
    public class Stat
    {
        [SerializeField] private StatDefinition _statDefinition;
        [SerializeField] private float _initialValue = 0f;
        [ShowInInspector] public float CurrentValue => !_isDirty ? _currentValue : Recalculate();
        [ShowInInspector] public List<StatModifier> _modifiers;

        public StatDefinition StatDefinition { get => _statDefinition; set => _statDefinition = value; }

        private float _currentValue;
        private bool _isDirty = true;

        public Stat(StatDefinition statDefinition)
        {
            _modifiers = new List<StatModifier>();
            StatDefinition = statDefinition;
            _initialValue = statDefinition.Default;
        }

        public Stat(StatDefinition statDefinition, float initialValue)
        {
            _modifiers = new List<StatModifier>();
            StatDefinition = statDefinition;
            _initialValue = initialValue;
        }

        public StatModifier AddModifier(float amount, StatModifierType type, Object source)
        {
            return AddModifier(new StatModifier(amount, type, source));
        }

        public StatModifier AddModifier(StatModifier statModifier)
        {
            _modifiers.Add(statModifier);
            _isDirty = true;
            return statModifier;
        }

        public void RemoveModifier(StatModifier statModifier)
        {
            if (!_modifiers.Contains(statModifier)) return;

            _modifiers.Remove(statModifier);
            _isDirty = true;
        }

        private float Recalculate()
        {
            float additive = 0f;
            float increased = 1f;
            float more = 1f;

            foreach (StatModifier modifier in _modifiers)
            {
                switch (modifier.Type)
                {
                    case StatModifierType.Additive:
                        additive += modifier.Amount;
                        break;
                    case StatModifierType.Increased:
                        increased += modifier.Amount;
                        break;
                    case StatModifierType.More:
                        more *= (1f + modifier.Amount);
                        break;
                    default:
                        break;
                }
            }

            float total = (_initialValue + additive) * increased * more;
            _currentValue = total;
            _isDirty = false;
            return _currentValue;
        }

    }
}