using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _scoreText;
    private void Awake()
    {
        if (_player)
        {
            _player.PlayerScoreUpdateDelegate += OnPlayerScoreUpdate;
        }
    }

    private void OnDestroy()
    {
        if (_player)
        {
            _player.PlayerScoreUpdateDelegate -= OnPlayerScoreUpdate;
        }
    }

    private void Start()
    {
        if (_player)
        {
            _scoreText.text = $"Score : {_player.Score}";
        }
    }
    public void OnPlayerScoreUpdate(int score)
    {
        _scoreText.text = $"Score : {score}";
    }
}
