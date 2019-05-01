using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerHandler : MonoBehaviour
{
    [SerializeField]
    private Slider powerSlider;

    private GameManager gameManager;

    [SerializeField]
    private int barSpeed,powerMax;

    public float powerThreshold;

    private bool isGoingUp;

    // Start is called before the first frame update
    void Start()
    {
        powerThreshold = 0;
        isGoingUp = true;
        powerSlider.maxValue = powerMax;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.playerState == GameManager.PState.CheckPower)
        {
            MoveArrow();
        }
        else
        {
            powerThreshold = 0;
        }
    }

    private void MoveArrow()
    {
        if (isGoingUp)
        {
            powerThreshold += Time.deltaTime * barSpeed;
        }
        else if (!isGoingUp)
        {
            powerThreshold -= Time.deltaTime * barSpeed;
        }

        if (powerThreshold >= powerMax)
        {
            isGoingUp = false;
        }
        else if (powerThreshold <= 0)
        {
            isGoingUp = true;
        }
        AddSlider();
    }

    private void AddSlider()
    {
        powerSlider.value = powerThreshold;
    }
}
