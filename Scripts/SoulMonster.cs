using UnityEngine;
using System.Collections;

public class SoulMonster : MonoBehaviour {

    private Transform player;

    private PlayerATKAndDamage playerAtkAndDamage;

    private CharacterController cc;

    private Animator animator;

    public float attackDistance = 1.2f;

    public float speed = 3;

    public float attackTime = 3;

    private float attackTimer = 0;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag(Tags.player).transform;

        playerAtkAndDamage = player.GetComponent<PlayerATKAndDamage>();

        cc = this.GetComponent<CharacterController>();

        animator = this.GetComponent<Animator>();

        attackTimer = attackTime;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (playerAtkAndDamage.hp <= 0)
        {
            animator.SetBool("Walk", false);

            return;
        }

        Vector3 targetPos = player.position;

        targetPos.y = transform.position.y;

        transform.LookAt(targetPos);

        float distance = Vector3.Distance(targetPos, transform.position);

        if (distance <= attackDistance)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer > attackTime)
            {
                animator.SetTrigger("Attack");

                attackTimer = 0;
            }
            else
            {
                animator.SetBool("Walk", false);
            }
        }
        else
        {
            attackTimer = attackTime;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("MonRun"))
            {
                cc.SimpleMove(transform.forward * speed);
            }
            animator.SetBool("Walk", true);
        }
	
	}
}
