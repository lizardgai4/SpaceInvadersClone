using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    public static int direction = 1;
    public static float speed = 0.1f;
    public bool gunship = false;
    private bool canFire = false;
    //public GameObject UI;
    private float fireRate = 5f;
    private float fireTimer = 0f;
    private bool hit = false;

    public GameObject bullet;
    public Transform shottingOffset;

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hit) {
            hit = true;
            //Debug.Log("Tot!");
            //switch(this.gameObject.name)
            if (this.gameObject.name.StartsWith("Enemy1"))
            {
                animator.Play("Enemy1Death");
                GameObject.Find("UI").GetComponent<UIScript>().scorePoints(10, 0);
            }
            else if (this.gameObject.name.StartsWith("Enemy2"))
            {
                animator.Play("Enemy2Death");
                GameObject.Find("UI").GetComponent<UIScript>().scorePoints(20, 0);
            }
            else if (this.gameObject.name.StartsWith("Enemy3"))
            {
                animator.Play("Enemy3Death");
                GameObject.Find("UI").GetComponent<UIScript>().scorePoints(30, 0);
            }
            else if (this.gameObject.name.StartsWith("Enemy4"))
            {
                animator.Play("Enemy4Death");
                GameObject.Find("UI").GetComponent<UIScript>().scorePoints(40, 0);
            }

            GameObject.Find("Level").GetComponent<StartGame>().decrementEnemies();

            //Debug.Log("Block destroyed");

            Destroy(collision.gameObject);
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
    public void down()
    {
        transform.Translate(transform.up * -1); ;
    }

    public void Move()
    {
        transform.Translate(transform.right * direction * speed);
    }

    public void Update()
    {
        //fire a bullet (if applicable)
        if (gunship)
        {
            if (!canFire)
            {
                fireTimer += Time.deltaTime;
                if (fireTimer > fireRate)
                {
                    canFire = true;
                    fireTimer = 0.0f;
                }
            }
            else
            {
                animator.Play("Enemy1Fire");
                canFire = false;
                GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
                //shot.speed = -5;
                //Debug.Log("Bang!");
                Destroy(shot, 3f);
            }
        }

        //bump agaist the right side
        if (transform.position.x > 38 && direction == 1)
        {
            direction = -1;
            GameObject.Find("Level").GetComponent<StartGame>().LowerAllEnemies();
            //new WaitForSeconds(2f);
        }
        else if (transform.position.x < 5 && direction == -1)
        { //bump against the left side
            direction = 1;
            GameObject.Find("Level").GetComponent<StartGame>().LowerAllEnemies();
            //new WaitForSeconds(2f);
        }
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
}