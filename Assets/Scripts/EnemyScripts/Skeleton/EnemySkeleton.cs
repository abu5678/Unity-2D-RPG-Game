using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : Enemy
{

    #region states
    public SkeletonIdleState idleState {  get; private set; }
    public SkeletonMoveState moveState { get; private set; }
    public SkeletonBattleState battleState { get; private set; }
    public SkeletonAttackState attackState { get; private set; }
    public SkeletonStunnedState stunnedState { get; private set; }
    public SkeletonDeadState deadState { get; private set; }
    #endregion
    protected override void Awake()
    {
        base.Awake();
        idleState = new SkeletonIdleState(this, stateMachine, "Idle", this);
        moveState = new SkeletonMoveState(this, stateMachine, "Move", this);
        battleState = new SkeletonBattleState(this, stateMachine, "Move", this);
        attackState = new SkeletonAttackState(this, stateMachine, "Attack", this);
        stunnedState = new SkeletonStunnedState(this, stateMachine, "Stunned", this);
        deadState = new SkeletonDeadState(this, stateMachine, "Die", this);
        
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.initialise(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    //if the enemy can be stunned then they will enter the stunned state when this method is called
    public override bool CanBeStunned()
    {
        if(base.CanBeStunned())
        {
            stateMachine.ChangeState(stunnedState); 
            return true;
        }
        return false;
    }
    public override void die()
    {
        base.die();
        stateMachine.ChangeState(deadState);
    }
}
