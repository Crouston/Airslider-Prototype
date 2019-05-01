using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum PState{CheckArrow,CheckPower,Play,Wait};
    public enum GState{PlayerTurn,EnemyTurn};
    public enum EState{Attack,Wait};

    public PState playerState;
    public GState gameState;
    public EState enemyState;
    // Start is called before the first frame update
    void Start()
    {
        playerState = PState.CheckArrow;
        gameState = GState.PlayerTurn;
        enemyState = EState.Attack;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void GetNextPlayerState()
    {
        if (playerState != PState.Wait)
        {
            playerState += 1;
        }
        else
        {
            playerState = PState.CheckArrow;
            gameState = GState.EnemyTurn;
        }
    }

    public void GetNextEnemyState()
    {
        if (enemyState != EState.Wait)
        {
            enemyState += 1;
        }
        else
        {
            enemyState = EState.Attack;
            gameState = GState.PlayerTurn;

            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            transform.position = new Vector3(player.position.x, player.position.y, -10);
        }
    }
}
