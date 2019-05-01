using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField]
    private int hp, damage, speed;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();    
    }

    private void Update()
    {
        if(gameManager.gameState == GameManager.GState.EnemyTurn)
        {
            if(gameManager.enemyState == GameManager.EState.Attack)
            {
                GetComponent<Rigidbody2D>().AddForce(GameObject.FindGameObjectWithTag("Player").transform.position*speed);
                gameManager.GetNextEnemyState();
            }
            else if(gameManager.enemyState == GameManager.EState.Wait)
            {
                if (GetComponent<Rigidbody2D>().velocity.x == 0 && GetComponent<Rigidbody2D>().velocity.y == 0)
                {
                    FindObjectOfType<GameManager>().GetNextEnemyState();
                }
            }
        }
        Death();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && gameManager.gameState == GameManager.GState.EnemyTurn)
        {
            collision.gameObject.GetComponent<PlayerHandler>().TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
    
    private void Death()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
