using UnityEngine;
using TMPro;

public class CoinsUI : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    private Player player;

    void Start()
    {
        player = GameManager.instance.player;
    }

    void Update()
    {
        coinsText.text = "Monety: " + player.coins;
    }
}