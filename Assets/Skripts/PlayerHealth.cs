using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public RectTransform valueRectTransform;
    public float value = 100;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    private float _MaxValue;

    private void Start()
    {
        _MaxValue = value;
    }

    public void DealDamege(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }

    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<PlayerMove>().enabled = false;
    }    
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _MaxValue, 1);
        valueRectTransform.right = new Vector2(0,0);
    }
}
