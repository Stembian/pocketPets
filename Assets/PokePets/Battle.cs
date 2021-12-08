using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Battle : MonoBehaviour
{
    [SerializeField] private Character _player;
    [SerializeField] private Character _grifer;
    [SerializeField] private GameObject _playerControls;

    private bool isPlayerTurn;

    public void StartBattle()
    {
        _player.Initialialize(DiceRoll(20)+20, DiceRoll(6) + 4, DiceRoll(4)+1, DiceRoll(100));
     
        _grifer.Initialialize(DiceRoll(20)+20, DiceRoll(6) + 4, DiceRoll(4)+1, DiceRoll(100));

        if (_grifer.GetSpeed() > _player.GetSpeed()) isPlayerTurn = false;
        else isPlayerTurn = true;

        StartTurn();
    }

    public void GriferMove()
    {
        switch (DiceRoll(3))
        {
            case 1:
                _grifer.Attack(_player);
                break;
            case 2:
                _grifer.SuperAttack(_player);
                break;
            case 3:
                _grifer.Heal();
                break;
            default:
                _grifer.Death();
                break;
        }

        EndTurn();
    }

    public void StartTurn()
    {

        if (isPlayerTurn == false)
        {
            GriferMove();

        }
       
    }

    public int DiceRoll(int sides)
    {
        return Random.Range(1, sides + 1);
    }

    public void EndTurn()
    {
        if (isPlayerTurn)
        {
            _playerControls.SetActive(false);
            StartCoroutine(EndTurnWait());
        }
        else
        {
            StartCoroutine(EndTurnWait());
            _playerControls.SetActive(true);
        }
    }

    
    public IEnumerator EndTurnWait()
    {
        
        yield return new WaitForSeconds(3);
        isPlayerTurn = !isPlayerTurn;
        StartTurn();
    }
}
