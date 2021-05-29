using UnityEngine;
using TMPro;
using IsmaelNascimentoAssets.Controllers;
using IsmaelNascimentoAssets.Enums;

namespace IsmaelNascimentoAssets.Samples
{
    public class UIControllerSample : MonoBehaviour
    {
        #region VARIABLES

        [SerializeField] private bool resetSumItemValue = true;
        [SerializeField] private TMP_Text coinPointsText;
        [SerializeField] private TMP_Text lifePointsText;
        [SerializeField] private TMP_Text powerPointsText;

        #endregion

        #region MONOBEHAVIOUR_METHODS

        private void Start()
        {
            ItemController.Instance.OnSetItemAction += OnSetItemAction_Action;
            coinPointsText.text = $"Coins: {ItemController.Instance.GetItemValue(ItemType.Coin, resetSumItemValue)}";
            lifePointsText.text = $"Lifes: {ItemController.Instance.GetItemValue(ItemType.Life, resetSumItemValue)}";
            powerPointsText.text = $"Powers: {ItemController.Instance.GetItemValue(ItemType.Power, resetSumItemValue)}";
        }

        #endregion

        #region PRIVATE_METHODS

        private void OnSetItemAction_Action(ItemType itemType, int value)
        {
            Debug.Log($"OnSetItemAction_Action: {itemType} - {value}");

            if (itemType == ItemType.Coin)
            {
                coinPointsText.text = $"Coins: {value}";
            }
            else if(itemType == ItemType.Life)
            {
                lifePointsText.text = $"Lifes: {value}";
            }
            else if (itemType == ItemType.Power)
            {
                powerPointsText.text = $"Powers: {value}";
            }
        }

        #endregion
    }
}