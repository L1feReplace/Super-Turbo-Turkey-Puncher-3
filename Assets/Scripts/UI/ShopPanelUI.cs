using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;

    public void ShowAndHideShopPanel()
    {
        _shopPanel.SetActive(!_shopPanel.activeSelf);
    }
}
