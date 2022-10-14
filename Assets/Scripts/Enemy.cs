using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int currentHealth = 1;
    private int MoveSpeed = 4;
    private int MinDist = 3;
    private float nextAttack;
    public float attackRate; // Number in seconds which controls how often the Enemy can attack
    private Player player;
    private Animator monsterController;
    [SerializeField] private SoundManager soundManager;

    void Start()
    {
        attackRate = 3f;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        monsterController = gameObject.GetComponent<Animator>();
        soundManager = GameObject.FindWithTag("Sound").GetComponent<SoundManager>();
        soundManager.enemyAppear();
    }

    void Update()
    {
        Vector3 playerPoint = Camera.main.transform.position - new Vector3(0,1.5f,0);
        gameObject.transform.LookAt(playerPoint);

        if(!monsterController.GetCurrentAnimatorStateInfo(0).IsName("Start") && !monsterController.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            if(Vector3.Distance(transform.position, playerPoint) > MinDist)
            {
                monsterController.SetTrigger("Run");
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }
            else
            {
                if(Time.time > nextAttack)
                {
                    monsterController.SetTrigger("Attack");
                    if(monsterController.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    {
                        player.Damage();
                        nextAttack = Time.time + attackRate;
                    }
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Shootable")
        {
            Damage(1);
        }
    }

	void Damage(int damageAmount)
	{
        float delay = 1f;
		currentHealth -= damageAmount;

		if (currentHealth == 0)
        {
            monsterController.SetTrigger("Die");
		    Destroy(gameObject, monsterController.GetCurrentAnimatorStateInfo(0).length + delay); 
        }
    }
}
