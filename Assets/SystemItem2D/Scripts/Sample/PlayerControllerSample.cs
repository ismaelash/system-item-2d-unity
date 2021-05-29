using IsmaelNascimentoAssets.Commons;
using IsmaelNascimentoAssets.Controllers;
using UnityEngine;

namespace IsmaelNascimentoAssets.Samples
{
    public class PlayerControllerSample : MonoBehaviour
    {
        #region MONOBEHAVIOUR_METHODS

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //Debug.Log(collision.collider.name);
            ItemType2D itemType2DComponent = collision.gameObject.GetComponent<ItemType2D>();
            Debug.Log(itemType2DComponent.itemConfiguration.itemType);
            if (itemType2DComponent)
            {
                ItemController.Instance.SetItem(itemType2DComponent);
                Destroy(itemType2DComponent.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.Log(collision.gameObject.name);
            ItemType2D itemType2DComponent = collision.gameObject.GetComponent<ItemType2D>();
            if (itemType2DComponent)
            {
                ItemController.Instance.SetItem(itemType2DComponent);
                Destroy(itemType2DComponent.gameObject);
            }
        }

        #endregion
    }
}