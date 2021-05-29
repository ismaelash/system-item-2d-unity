using IsmaelNascimentoAssets.ScriptableObjects;
using UnityEngine;

namespace IsmaelNascimentoAssets.Commons
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public class ItemType2D : MonoBehaviour
    {
        #region VARIABLES
        
        public ItemSO itemConfiguration;
        [Header("Custom")]
        public bool valueItemCustom;
        public int valueItem;

        #endregion

        #region MONOBEHAVIOUR_METHODS

        private void Start()
        {
            SetIconOnSprite();
        }

        #endregion

        #region PUBLIC_METHODS

        [ContextMenu("SetIconOnSprite")]
        public void SetIconOnSprite()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = itemConfiguration.icon;
        }

        #endregion

    }
}