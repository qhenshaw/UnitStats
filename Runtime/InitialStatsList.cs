using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitStats
{
    [CreateAssetMenu(menuName = "Unit Stats/Initial Stats List")]
    public class InitialStatsList : ScriptableObject
    {
        [TableList(AlwaysExpanded = true)]
        public List<InitialStat> InitialStats = new List<InitialStat>();
    }
}