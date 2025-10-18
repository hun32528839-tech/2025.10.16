using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _leftLimitDistance;
    [SerializeField] private Transform _rightLimitDistance;

    private bool _isMovingRight = true;
  
    private void Update()
    {
        if (_isMovingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, _rightLimitDistance.position, _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _rightLimitDistance.position) < 0.1f)
            {
                _isMovingRight = false;
            }               
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position , _leftLimitDistance.position , _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position , _leftLimitDistance.position) < 0.1f)
            {
                _isMovingRight = true;
            }
            
        }        
    }
}
