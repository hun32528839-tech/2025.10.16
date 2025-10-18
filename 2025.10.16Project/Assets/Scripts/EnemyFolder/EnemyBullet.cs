using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Vector3 _direction;
    
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        transform.position = transform.position + _direction.normalized * _speed * Time.deltaTime;
    }

    public void SetBulletDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
