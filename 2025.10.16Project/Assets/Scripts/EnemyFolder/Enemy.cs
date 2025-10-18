using UnityEngine;

public class Enemy : MonoBehaviour
{    
    [SerializeField] private GameObject _enemyBulletPrefab;

    private GameObject _player;
    private float _fireTimer;
    private float _fireDelay = 3f;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        _fireTimer += Time.deltaTime;

        if (_fireTimer >= _fireDelay)
        {
            ShotPlayerInRange();
            _fireTimer = 0f;
        }        
    }




    public void ShotPlayerInRange()
    {
        Collider[] isPlayerInRange = Physics.OverlapSphere(transform.position, 20f);
       
        foreach (Collider hit in isPlayerInRange)
        {
            if (hit.CompareTag("Player"))
            {
                Vector3 direction = (_player.transform.position - transform.position).normalized;

                GameObject newEnemyBullet = Instantiate(_enemyBulletPrefab, transform.position, transform.rotation);
                newEnemyBullet.GetComponent<EnemyBullet>().SetBulletDirection(direction);
            }
       
        }
       
    }
}
