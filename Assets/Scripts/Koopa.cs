using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa : Enemy
{
    public enum KoopaShellState
    {
        shelled,
        unShelled
    }

    KoopaShellState shellState = KoopaShellState.shelled;

    public override IEnumerator Wander()
    {
        return base.Wander();

    }
    public override void TakeDamage()
    {
        base.Die();

        int health = CurrentHealth;
    }

    public override void DropLoot()
    {
        base.DropLoot();
    }

    public override void GroundCheck()
    {
        base.GroundCheck();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}
