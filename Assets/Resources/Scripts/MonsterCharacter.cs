using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterCharacter : NonPlayerCharacter
{
    private Animator animator;

    public override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"Столкновение {gameObject.name} c {collision.name}");
            animator.SetTrigger("TakenDamage");
        }
    }
}
