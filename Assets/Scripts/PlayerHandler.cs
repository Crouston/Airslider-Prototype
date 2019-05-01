using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    private PlayerDirectionHandler playerDir;
    private PowerHandler playerPower;
    private GameManager gameManager;
    [SerializeField]
    private Slider healthBar;

    private float angleChosen;
    private float powerChosen;
    [SerializeField]
    private int hp;
    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerDir = FindObjectOfType<PlayerDirectionHandler>();
        playerPower = FindObjectOfType<PowerHandler>();
        angleChosen = 0;
        powerChosen = 0;
        healthBar.maxValue = healthBar.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = hp;
        if(gameManager.playerState == GameManager.State.CheckArrow && Input.GetKeyDown(KeyCode.Space))
        {
            angleChosen = playerDir.dirAngle;
            FindObjectOfType<GameManager>().GetNextState();
            Debug.Log(angleChosen);
        }
        else if (gameManager.playerState == GameManager.State.CheckPower && Input.GetKeyDown(KeyCode.Space))
        {
            powerChosen = playerPower.powerThreshold;
            FindObjectOfType<GameManager>().GetNextState();
        }
        else if (gameManager.playerState == GameManager.State.Play)
        {
            Vector2 dir = new Vector2(-Mathf.Cos(Mathf.Deg2Rad * angleChosen), Mathf.Sin(Mathf.Deg2Rad * angleChosen));
            GetComponent<Rigidbody2D>().AddForce( dir  * powerChosen );
            FindObjectOfType<GameManager>().GetNextState();
        }
        else if(gameManager.playerState == GameManager.State.Wait)
        {
            if(GetComponent<Rigidbody2D>().velocity.x == 0 && GetComponent<Rigidbody2D>().velocity.y == 0)
            {
                FindObjectOfType<GameManager>().GetNextState();
            }
        }
    }

    public void TakeDamage(int Damage)
    {
        hp -= Damage;
    }

    //private float SearchX(float angle)
    //{
    //    return angle - 90 / 90;
    //}

    //private float SearchY(float angle)
    //{
    //    if(angle > 90)
    //    {
    //        angle -= 90;
    //    }
    //    return angle / 90;
    //}
}
