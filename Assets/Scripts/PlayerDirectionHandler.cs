using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDirectionHandler : MonoBehaviour
{
    [SerializeField]
    private Slider dirSlider;

    private GameManager gameManager;

    [SerializeField]
    private int arrowSpeed;

    public float dirAngle;

    private bool isGoingRight;

    // Start is called before the first frame update
    void Start()
    {
        dirAngle = 0;
        isGoingRight = true;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.playerState == GameManager.PState.CheckArrow)
        {
            MoveArrow();
        }
        else
        {
            dirAngle = 0;
        }
    }

    private void MoveArrow()
    {
        if (isGoingRight)
        {
            dirAngle += Time.deltaTime * arrowSpeed;
        }
        else if (!isGoingRight)
        {
            dirAngle -= Time.deltaTime * arrowSpeed;
        }

        if (dirAngle >= 180)
        {
            isGoingRight = false;
        }
        else if (dirAngle <= 0)
        {
            isGoingRight = true;
        }
        AddSlider();
    }
    
    private void AddSlider()
    {
        dirSlider.value = dirAngle;
    }
}
