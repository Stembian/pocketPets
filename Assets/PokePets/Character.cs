using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterVisual))]
public class Character : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private int _defense;
    [SerializeField] private int _speed;

    [SerializeField] private Slider _healthBar;
    [SerializeField] private Text _healthText;

    private CharacterVisual _characterVisual;

    public void Initialialize(int health, int damage, int defense, int speed)
    {
        _health = health;
        _damage = damage;
        _defense = defense;
        _speed = speed;
        _healthBar.maxValue = health;
        UpdateHealth();
        _characterVisual = GetComponent<CharacterVisual>();
    }
    public void Attack(Character target)
    {
        target.TakeDamage(DiceRoll(_damage));
        _characterVisual.Attack();

    }

    public void SuperAttack(Character target)
    {
        if (DiceRoll(2) > 1)
        {
            Attack(target);
            Attack(target);
        }
        else Attack(this);
        _characterVisual.SuperAttack();

    }

    public void Heal()
    {
        _health += DiceRoll(6);
        UpdateHealth();
        _characterVisual.Heal();

    }

    public void TakeDamage(int damage)
    {
        if (damage > _defense) _health -= damage;
        if (_health < 1) Death();
        UpdateHealth();
    }

    public int GetSpeed()
    {
        return _speed;
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public int DiceRoll(int sides)
    {
        return Random.Range(1, sides + 1);
    }

    public void UpdateHealth()
    {
        if (_healthBar != null)
        {
            _healthBar.value = _health;
            _healthText.text = $"HP: {_health}";
        }
    }
}

