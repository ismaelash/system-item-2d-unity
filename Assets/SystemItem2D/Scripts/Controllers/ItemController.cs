using IsmaelNascimentoAssets.Commons;
using IsmaelNascimentoAssets.Enums;
using IsmaelNascimentoAssets.ScriptableObjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IsmaelNascimentoAssets.Controllers
{
    public class ItemController : MonoBehaviour
    {
        #region VARIABLES

        public static ItemController Instance { get; set; }
        [SerializeField] private bool sumItemValueOnGet = false;
        [SerializeField] private List<ItemSO> items;

        public Action<ItemType, int> OnSetItemAction;

        #endregion

        #region MONOBEHAVIOUR_METHODS

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        #region PUBLIC_METHODS

        public void SetItem(ItemType2D itemType2D)
        {
            string itemTypeString = itemType2D.itemConfiguration.itemType.ToString();
            int newPoint;

            if (sumItemValueOnGet)
            {
                newPoint = GetItemValue(itemType2D.itemConfiguration.itemType, false) + CheckItemValue(itemType2D);
            }
            else
            {
                newPoint = CheckItemValue(itemType2D);
            }

            PlayerPrefs.SetInt(itemTypeString, newPoint);
            OnSetItemAction?.Invoke(itemType2D.itemConfiguration.itemType, newPoint);
        }

        public int GetItemValue(ItemType itemType, bool resetItemValue = true)
        {
            string itemTypeKey = itemType.ToString();

            //Debug.Log($"GetCoinValue Key: {coinTypeKey}");
            //Debug.Log($"HasKeyAbove? {PlayerPrefs.HasKey(coinTypeKey)}");

            if (resetItemValue)
            {
                PlayerPrefs.DeleteKey(itemTypeKey);
            }
           
            return PlayerPrefs.GetInt(itemTypeKey);
        }

        public void SetSumItemValueOnGet(bool value)
        {
            sumItemValueOnGet = value;
        }

        #endregion

        #region PRIVATE_METHODS

        private int CheckItemValue(ItemType2D itemType2D)
        {
            if (itemType2D.valueItemCustom)
            {
                return itemType2D.valueItem;
            }
            else
            {
                foreach (ItemSO itemSO in items)
                {
                    if (itemSO.itemType.Equals(itemType2D.itemConfiguration.itemType))
                    {
                        return itemSO.value;
                    }
                }
            }

            Debug.LogError("Some error on CheckItemValue");
            return 0;
        }

        #endregion
    }
}