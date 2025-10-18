using UnityEngine;

public class GameOverPopup : MonoBehaviour
{
    [SerializeField] private Player _player;
    private void Awake()
    {
        if (_player)
        {
            _player.PlayerDieDelegate += OnPlayerDie;
        }
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (_player)
        {
            _player.PlayerDieDelegate -= OnPlayerDie;
        }
    }
    public void OnPlayerDie()
    {
        gameObject.SetActive(true);
    }
}
