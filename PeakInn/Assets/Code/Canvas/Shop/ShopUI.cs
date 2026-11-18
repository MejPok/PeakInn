using Assets.Code.Player;
using Assets.Code.Round;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject shopPanel;
    public TextMeshProUGUI classicRoomPriceText;
    public TextMeshProUGUI warmRoomPriceText;
    public TextMeshProUGUI peachPriceText;

    public int classicRoomPrice = 0;
    public int warmRoomPrice = 0;
    public int peachPrice = 3;

    public bool shopIsShown;

    private void Start()
    {
        RoundControl.Instance.ShoppingEvent += ShowShop;
    }
    private void Update()
    {
        shopPanel.SetActive(shopIsShown);

        classicRoomPrice = RoomManager.Instance.roomTypes.FirstOrDefault(x => x.Name == "Basic Room").Cost;
        warmRoomPrice = RoomManager.Instance.roomTypes.FirstOrDefault(x => x.Name == "Warm Room").Cost;


        classicRoomPriceText.text = $"Price: {classicRoomPrice}";
        warmRoomPriceText.text = $"Price: {warmRoomPrice}";
        peachPriceText.text = $"Price: {peachPrice}";

    }

    public void ShowShop()
    {
        shopIsShown = true;
    }

    public void HideShop()
    {
        shopIsShown = false;
    }
    public void BuyItem(int itemToBuy)
    {
        if (itemToBuy == 0 && PlayerMoney.Instance.Money >= classicRoomPrice) // CLASSIC ROOM
        {
            Debug.Log("Bought cold room");

            RoomManager.Instance.CreateNewRoom("Basic Room");
            PlayerMoney.Instance.Money -= classicRoomPrice;

        } else if(itemToBuy == 1 && PlayerMoney.Instance.Money >= warmRoomPrice) // WARM ROOM
        {
            Debug.Log("Bought warm room");
            RoomManager.Instance.CreateNewRoom("Warm Room");
            PlayerMoney.Instance.Money -= warmRoomPrice;

        }
        else if (itemToBuy == 2 && PlayerMoney.Instance.Money >= peachPrice) // PEACH
        {
            Debug.Log("Bought 3 peaches");

            PlayerMoney.Instance.Peaches += 3;
            PlayerMoney.Instance.Money -= peachPrice;

        }
    }

    public void NextDay()
    {
        shopIsShown = false;
        RoundControl.Instance.ShoppingEnd();
    }

}
