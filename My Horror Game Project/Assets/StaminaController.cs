using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    PlayerMove playermove;
    public Image staminUI;
    public float runOutStamina = 0.2f;
    public float FillStamina = 0.05f;

    private void Awake()
    {
        playermove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
      
    }

    public void StaminaDown()
    {

            playermove.stamina -= runOutStamina;
            staminUI.fillAmount -= runOutStamina * 0.01f;
    }

    public void StaminaUp()
    {
        playermove.stamina += FillStamina;
        staminUI.fillAmount += FillStamina * 0.01f;
    }
}
