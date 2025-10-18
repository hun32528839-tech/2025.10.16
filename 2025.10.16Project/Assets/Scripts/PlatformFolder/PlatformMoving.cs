using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _limitDistance;

    private Vector3 _startPos;
    private Vector3 _endPos;


    private void Start()
    {
        _startPos = transform.position; // 시작점으로 포지션으로 고정
        _endPos = _limitDistance.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position , _endPos) < 0.05f)
        {
            if (_endPos == _startPos) // (ex. _targetPos(5,0,0) , _startPos(0,0,0) 이라면, 다르기 때문에 false 
            {
                _endPos = _limitDistance.position;
            }
            else 
            {
                _endPos = _startPos;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, _endPos, _speed * Time.deltaTime);
    }
}
