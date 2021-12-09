using System.Collections;
using System.Threading;
using UnityEngine;

public class CharacterVisual : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed;
    [SerializeField] private float _turnTime;

    private float _timer;

    private Vector3 _targetPosition;
    private Vector3 _defaultPosition;

    private void Start()
    {
        _targetPosition = transform.position;
        _defaultPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _lerpSpeed);
    }

    public void Attack()
    {
        StartCoroutine(AttackRoutine());
    }
    public void Heal()
    {
        StartCoroutine(HealRoutine());

    }
    public void SuperAttack()
    {
        StartCoroutine(SuperAttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        _timer = 0;
        _targetPosition = _defaultPosition + transform.forward;
        while (_timer < _turnTime / 3)
        {
            _timer += Time.deltaTime;
            yield return null;
        }
        _targetPosition = _defaultPosition;
    }

    private IEnumerator HealRoutine()
    {
        _timer = 0;
        _targetPosition = _defaultPosition + transform.up;
        while (_timer < _turnTime / 3)
        {
            _timer += Time.deltaTime;
            yield return null;
        }
        _targetPosition = _defaultPosition;
    }

    private IEnumerator SuperAttackRoutine()
    {
        _timer = 0;
        _targetPosition = _defaultPosition + transform.up + transform.forward;
        while (_timer < _turnTime / 3)
        {
            _timer += Time.deltaTime;
            yield return null;
        }
        _targetPosition = _defaultPosition;
    }
}