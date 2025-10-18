using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void PlayerDieDelegate();
public delegate void PlayerScoreUpdateDelegate(int newScore);
public delegate void PlayerCoinScoreUpdateDelegate(int newCoinScore);
public class Player : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private int _coinScore;
    [SerializeField] private PlayerMoving _playerMoving;


    public PlayerDieDelegate PlayerDieDelegate;
    public PlayerScoreUpdateDelegate PlayerScoreUpdateDelegate;
    public PlayerCoinScoreUpdateDelegate PlayerCoinScoreUpdateDelegate;

    private Rigidbody _rb;

    public int Score => _score;
    public int CoinScore => _coinScore;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ContactPoint contactPoint = collision.contacts[0];
            Vector3 normal = contactPoint.normal;

            if (normal.y > 0.5f) // 적의 표면의 위쪽을 밟기 때문에 양수(+)
            {
                Destroy(collision.gameObject);

                _rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);

                AddScore(50);
            }
            else
            {
                Die();              
            }            
        }        

        else if (collision.gameObject.CompareTag("Pipe"))
        {
            StartCoroutine(EnterPipe());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            AddCoinScore(10);
        }
    }

    IEnumerator EnterPipe()
    {
        _playerMoving.enabled = false; // 플레이어의 움직임을 꺼둠
        float duration = 1f; // 파이프 속으로 완전히 들어가는 데 걸릴 총 시간 (1초)
        float elapsed = 0f; // 현재까지 지난 시간. 프레임마다 Time.deltaTime만큼 증가시킴

        Vector3 startPos = transform.position; // 시작위치
        Vector3 endPos = startPos + Vector3.down * 2f;
        // 벡터에 2f를 곱하면 방향은 그대로인데 길이(거리) 가 2배가 됨
        // Vector3.down * 2f = (0, -2, 0)
        // 즉, Y축으로 2만큼 아래로 이동하는 방향과 거리 를 뜻함

        while (elapsed < duration) // 0이 1보다 작다면 실행
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            // startPos에서 endPos까지 0부터 1까지 천천히 올려가면서 이동하게끔
            yield return null;
        }
        transform.position = endPos;

        SceneManager.LoadScene("Stage2");
    }

    public void AddScore(int score)
    {
        _score += score;
        PlayerScoreUpdateDelegate?.Invoke(_score);
    }
    public void AddCoinScore(int Coin)
    {
        _coinScore += Coin;
        PlayerCoinScoreUpdateDelegate?.Invoke(_coinScore);
    }
    public void Die()
    {
        PlayerDieDelegate?.Invoke();
        Time.timeScale = 0f;
        Destroy(gameObject);
    }
}
