using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _coinText;

    private void Awake()
    {
        if (_player)
        {
            _player.PlayerCoinScoreUpdateDelegate += OnPlayerCoinScoreUpdate;
        }
    }

    private void OnDestroy()
    {
        if (_player)
        {
            _player.PlayerCoinScoreUpdateDelegate -= OnPlayerCoinScoreUpdate;
        }
    }

    private void Start()
    {
        _coinText.text = $"Coin : {_player.CoinScore}";
    }

    public void OnPlayerCoinScoreUpdate(int coinScore)
    {
        _coinText.text = $"Coin : {coinScore}";
    }
}
