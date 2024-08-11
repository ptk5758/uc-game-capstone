using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseMonster : MonoBehaviour, IUnit, IMonster
{
    public float testSpeed = 0.1f;
    public GameObject GameObject { get { return gameObject; } }

    protected IUnit target;
    public void SetTarget(IUnit target)
    {
        this.target = target;
    }

    protected virtual void FixedUpdate()
    {
        Move();   
    }
    private void Move()
    {   
        Vector3 direction = (target.GameObject.transform.position - transform.position).normalized;
        transform.position += direction * testSpeed * Time.deltaTime;
    }

}
public interface IMonster
{
    public void SetTarget(IUnit target);
}