using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    PlayerMove playermove;

    public Image staminUI;
    public GameObject Stamina;
    public float runOutStamina = 0.2f;
    public float FillStamina = 0.07f;

    private bool isUseStamina;

    private void Awake()
    {
        playermove = GetComponent<PlayerMove>();
        isUseStamina = false;
    }

    private void Update()
    {
        Stamina.SetActive(isUseStamina);
            
        isUseStamina = playermove.stamina < 100 ? true : false;
        if (playermove.stamina > 30f && playermove.stamina <= 60f)
        {
            staminUI.color = Color.yellow;
        }
        else if (playermove.stamina <= 30f)
        {
            staminUI.color = Color.red;
        }
        else
        {
            staminUI.color = Color.green;
        }
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
