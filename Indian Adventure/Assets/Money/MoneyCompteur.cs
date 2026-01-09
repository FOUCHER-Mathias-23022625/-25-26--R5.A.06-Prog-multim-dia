using UnityEngine;
using TMPro;

public class MoneyCompteur : MonoBehaviour
{
    public static MoneyCompteur instance;

    public int money = 0;
    public TextMeshProUGUI moneyText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        moneyText.text = "Billets : " + money;
    }
}
