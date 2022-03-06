using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator { get; private set; }

    public Collider hitBox;

    public enum Direction
    {
        Left = -1,
        Right = 1
    }

    public Direction CurrentTurnDirection { get; private set; }

    public IPlayerState _turnState { get; set; }
    public IPlayerState _hurtState { get; set; }
    public IPlayerState _stopState { get; set; }
    public IPlayerState _startState { get; set; }

    public PlayerStateContext _playerStateContext { get; private set; }

    private void Start()
    {
        animator = GetComponent<Animator>();

        _playerStateContext = new PlayerStateContext(this);

        _turnState = gameObject.AddComponent<PlayerTurnState>();
        _hurtState = gameObject.AddComponent<PlayerHurtState>();
        _stopState = gameObject.AddComponent<PlayerStopState>();
        _startState = gameObject.AddComponent<PlayerStartState>();

        _playerStateContext.Transition(_stopState);
    }

    public void StartPlayer()
    {
        _playerStateContext.Transition(_startState);
    }

    public void StopPlayer()
    {
        _playerStateContext.Transition(_stopState);
    }

    public void TurnPlayer(Direction direction)
    {
        CurrentTurnDirection = direction;

        _playerStateContext.Transition(_turnState);
    }

    public void HurtPlayer()
    {
        _playerStateContext.Transition(_hurtState);
    }

    public void EnableHitBox()
    {
        hitBox.enabled = true;
    }

    public void DisableHitBox()
    {
        hitBox.enabled = false;
    }
}
