using UnityEngine;
using System.Collections;

public class ATKAndDamage : MonoBehaviour {

    public float hp = 100;

    public float normalAttack = 50;

    public float attackDistance = 1;

    protected Animator animator;

    public AudioClip deathClip;

    public void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    public virtual void TakeDamage(float damage)
    {
        if (hp > 0)
        {
            hp -= damage;
        }

        if (hp > 0)
        {
            if (this.tag == Tags.soulBoss || this.tag == Tags.soulMonster)
            {
                animator.SetTrigger("Damage");
            }

           
        }
        else
        {
            animator.SetBool("Dead", true);

            AudioSource.PlayClipAtPoint(deathClip, transform.position, 0.5f);

            if (this.tag == Tags.soulBoss || this.tag == Tags.soulMonster)
            {

                SpawnManager._instance.enemyList.Remove(this.gameObject);

                Destroy(this.gameObject, 1);

                SpawnAward();

                this.GetComponent<CharacterController>().enabled = false;
            }
        }

        if (this.tag == Tags.soulBoss)
        {
            GameObject.Instantiate(Resources.Load("HitBoss"), transform.position + Vector3.up, transform.rotation);
        }
        else if (this.tag == Tags.soulMonster)
        {
            GameObject.Instantiate(Resources.Load("HitMonster"), transform.position + Vector3.up, transform.rotation);
        }
    }

    void SpawnAward()
    {
        int count = Random.Range(1, 3);

        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, 2);

            if (index == 0)
            {
                GameObject.Instantiate(Resources.Load("Item-DualSword"), transform.position + Vector3.up, Quaternion.identity);
            }
            else if (index == 1)
            {
                GameObject.Instantiate(Resources.Load("Item-Gun"), transform.position + Vector3.up, Quaternion.identity);
            }
        }
    }
}
