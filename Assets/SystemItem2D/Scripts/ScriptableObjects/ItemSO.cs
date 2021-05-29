using IsmaelNascimentoAssets.Enums;
using UnityEngine;

namespace IsmaelNascimentoAssets.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemSOData", menuName = "ScriptableObjects/ItemSOData")]
    public class ItemSO : ScriptableObject
    {
        public new string name;
        public Sprite icon;
        public ItemType itemType;
        public int value;
    }
}