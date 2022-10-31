using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitStats
{
    public class CharacterStats : MonoBehaviour
    {
        [SerializeField] private StatDefinitionList _allStats;
        [SerializeField] private InitialStatsList _initialStats;
        [ShowInInspector, ReadOnly] private List<Stat> _currentStats = new List<Stat>();

        public List<Stat> CurrentStats { get => _currentStats; set => _currentStats = value; }

        private void Awake()
        {
            foreach (InitialStat initialStat in _initialStats.InitialStats)
            {
                Stat newStat = new Stat(initialStat.StatDefinition, initialStat.InitialValue);
                CurrentStats.Add(newStat);
            }
        }

        public bool TryGetStat(StatDefinition statDefinition, out Stat stat)
        {
            foreach (Stat existingStat in _currentStats)
            {
                if(existingStat.StatDefinition == statDefinition)
                {
                    stat = existingStat;
                    return true;
                }
            }

            stat = null;
            return false;
        }
    }
}