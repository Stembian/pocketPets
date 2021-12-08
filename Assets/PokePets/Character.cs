using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private int _defense;
    [SerializeField] private int _speed;

    public void Initialialize(int health, int damage, int defense, int speed)
    {
        _health = health;
        _damage = damage;
        _defense = defense;
        _speed = speed;
    }
    public void Attack(Character target)
    {
        target.TakeDamage(DiceRoll(_damage));
    }

    public void SuperAttack(Character target)
    {
        if (DiceRoll(2) > 1)
        {
            Attack(target);
            Attack(target);
        }
        else Attack(this);
    }

    public void Heal()
    {
        _health += DiceRoll(6);
    }

    public void TakeDamage(int damage)
    {
        if (damage > _defense) _health -= damage;
        if (_health < 1) Death();
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
}

