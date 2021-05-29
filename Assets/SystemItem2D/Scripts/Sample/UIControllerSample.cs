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

        #endregion

        #region MONOBEHAVIOUR_METHODS

        private void Start()
        {
            ItemController.Instance.OnSetItemAction += OnSetItemAction_Action;
            coinPointsText.text = $"Coins: {ItemController.Instance.GetItemValue(ItemType.Coin, resetSumItemValue)}";
            lifePointsText.text = $"Lifes: {ItemController.Instance.GetItemValue(ItemType.Life, resetSumItemValue)}";
        }

        #endregion

        #region PRIVATE_METHODS

        private void OnSetItemAction_Action(ItemType coinType, int value)
        {
            Debug.Log($"OnSetItemAction_Action: {coinType} - {value}");

            if (coinType == ItemType.Coin)
            {
                coinPointsText.text = $"Coins: {value}";
            }
            else if(coinType == ItemType.Life)
            {
                lifePointsText.text = $"Lifes: {value}";
            }
        }

        #endregion
    }
}