using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BaseMonster : MonoBehaviour, IMonster
{
    public float Speed { get; set; }
    public float Delay { get; set; }
    private float attackTimer = 0;
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
            Debug.Log("공격!");
            attackTimer = 0;
        }

    }
    private void Moving()
    {   
        Vector3 direction = (target.GameObject.transform.position - transform.position).normalized;
        transform.position += direction * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (target.GameObject == collider.gameObject) {
            IPlayer p = collider.gameObject.GetComponent<IPlayer>();
            attackTarget = p;
        }
    }
    private void OnTriggerExit(Collider collider) {
        if (attackTarget != null && collider.gameObject == attackTarget.GameObject) {
            attackTarget = null;
        }
    }

}
public interface IMonster : IUnit
{
    public void SetTarget(IUnit target);
}