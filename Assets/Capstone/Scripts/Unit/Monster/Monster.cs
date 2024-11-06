using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : BaseMonster
{
    [SerializeField]
    private Animator animator;
    public ParticleSystem abangHitParticle;
    private void OnTriggerEnter(Collider collider)
    {
        if (target.GameObject == collider.gameObject) {
            IPlayer p = collider.gameObject.GetComponent<IPlayer>();
            attackTarget = p;
            animator.SetBool("IsAttack", true);
        }
    }
    private void OnTriggerExit(Collider collider) {
        if (attackTarget != null && collider.gameObject == attackTarget.GameObject) {
            attackTarget = null;
            animator.SetBool("IsAttack", false);
        }
    }
    protected override void Die()
    {
        MonsterManager.TriggerMonsterDied(this);
        StartCoroutine(DieCoroutine());
    }
    private IEnumerator DieCoroutine()
    {
        animator.SetBool("IsDie", true);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}