using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneMoveState : NightBorneGroundedState
{
    public NightBorneMoveState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, NightBorne enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        //makes the enemy move forward
        enemy.setVelocity(enemy.moveSpeed * enemy.facingDir, rigidbody2D.velocity.y);

        //checks to see if there is a wall infront or if there is no more platform to walk on since the detections are a bit infront
        //of the enemy, it will make the enemy flip and return to idle
        if (enemy.isWallDetected() || !enemy.IsGroundDetected() || enemy.IsSpikesDetected())
        {
            enemy.FlipCharacter();
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
