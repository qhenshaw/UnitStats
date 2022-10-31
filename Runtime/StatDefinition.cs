using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitStats
{
    public class StatDefinition : ScriptableObject
    {
        [DisableInInlineEditors] public string Name = "New Stat";
        [TableColumnWidth(40, false), DisableInInlineEditors] public float Min = 1f;
        [TableColumnWidth(40, false), DisableInInlineEditors] public float Max = 99f;
        [TableColumnWidth(60, false), DisableInInlineEditors] public float Default = 0f;

        public StatDefinitionList Container { get; set; }

        [Button("X"), TableColumnWidth(40, false), HideInInlineEditors]
        public void Delete()
        {
#if UNITY_EDITOR
            Container?.Remove(this);
            UnityEditor.Undo.DestroyObjectImmediate(this);
            UnityEditor.AssetDatabase.SaveAssets();
#endif
        }
    }
}