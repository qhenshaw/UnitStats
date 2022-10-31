using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitStats
{
    [CreateAssetMenu(menuName = "Unit Stats/Stat Definition List")]
    public class StatDefinitionList : ScriptableObject
    {
        [SerializeField, TableList(AlwaysExpanded = true, HideToolbar = true, IsReadOnly = true)] private List<StatDefinition> _list;

        public List<StatDefinition> List => _list;

        public void Remove(StatDefinition statDefinition)
        {
            _list.Remove(statDefinition);
        }

        private void OnValidate()
        {
#if UNITY_EDITOR

#endif
        }

#if UNITY_EDITOR
        [Button("Add New")]
        public void AddNewDefinition()
        {
            StatDefinition newStat = CreateInstance<StatDefinition>();
            newStat.name = "New Stat";
            newStat.Container = this;
            UnityEditor.AssetDatabase.AddObjectToAsset(newStat, this);
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.EditorUtility.SetDirty(this);
            _list.Add(newStat);
        }
#endif

#if UNITY_EDITOR
        [Button("Fix Asset Names")]
        public void FixAssetNames()
        {
            foreach (StatDefinition statDef in _list)
            {
                statDef.name = statDef.Name;
                
            }

            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.AssetDatabase.Refresh();
        }
#endif
    }
}