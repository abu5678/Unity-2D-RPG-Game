using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    private string animBoolName;

    protected Rigidbody2D rigidbody2D;

    protected float xInput;
    public PlayerState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.player = _player;
        this.animBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        //makes the boolean linked to the animation we want to play  true so the animation will start
        player.animator.SetBool(animBoolName, true);
        rigidbody2D = player.rigidbody2D;
    }
    public virtual void Update()
    {
        //gets the horizontal input from the user
        xInput = Input.GetAxis("Horizontal");
    }
    public virtual void Exit()
    {
        //makes the boolean linked to the animation false so that the animation stops playing
        player.animator.SetBool(animBoolName, false);

    }
}
