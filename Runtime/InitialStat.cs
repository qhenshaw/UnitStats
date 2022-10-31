using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitStats
{
    [System.Serializable]
    public class InitialStat
    {
        [InlineEditor] public StatDefinition StatDefinition;
        [TableColumnWidth(100, false)] public float InitialValue = 0f;
    }
}