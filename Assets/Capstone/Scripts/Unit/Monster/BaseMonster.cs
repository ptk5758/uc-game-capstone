using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class BaseMonster : MonoBehaviour, IMonster
{
    public int Damage { get; set; }
    public float Speed { get; set; }
    public float Delay { get; set; }
    private float attackTimer = 0;
    public float HP { get; set; }
    public GameObject GameObject { get { return gameObject; } }
    protected IUnit target;
    protected IUnit attackTarget;
    public void SetTarget(IUnit target)
    {
        this.target = target;
    }
    public void SetData(MonsterData data)
    {
        Speed = data.speed;
        Delay = data.delay;
        Damage = data.damage;
        HP = data.hp;
    }

    protected virtual void FixedUpdate()
    {
        if (attackTarget != null) {
            Attacking();
            return;
        }
        Moving();
    }
    protected virtual void Attacking() {
        if (attackTimer < Delay) {
            attackTimer += Time.deltaTime;
        } else {
            AttackPlayer();
            attackTimer = 0;
        }

    }
    private void AttackPlayer()
    {
        PlayerManager.Player.Hit(Damage);
    }
    private void Moving()
    {   
        Vector3 direction = (target.GameObject.transform.position - transform.position).normalized;
        transform.position += direction * Speed * Time.deltaTime;
    }

    

    public void Hit(float damage)
    {
        HP -= damage;
        // Debug.Log("남은 HP " + HP);
        if (HP <= 0) Die();
    }
    protected abstract void Die();
}
public interface IMonster : IUnit
{
    public void SetTarget(IUnit target);
}