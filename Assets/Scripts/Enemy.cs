using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int currentHealth = 1;
    private float nextAttack;
    public float attackRate; // Number in seconds which controls how often the Enemy can attack
    private Player player;


    int MoveSpeed = 4;
    int MinDist = 3;
    
    void Start()
    {
        attackRate = 3f;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        Vector3 playerPoint = Camera.main.transform.position - new Vector3(0,1.5f,0);
        gameObject.transform.LookAt(playerPoint);
        if(Vector3.Distance(transform.position, playerPoint) > MinDist)
        {
           // transform.position = Vector3.Lerp(transform.position, playerPoint, Time.deltaTime);
           transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        else
        {
            if(Time.time > nextAttack)
            {
                Debug.Log("attack");
                player.Damage();
                nextAttack = Time.time + attackRate;
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
		currentHealth -= damageAmount;

		if (currentHealth == 0) 
		    Destroy(gameObject);
    }
}
