using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [SerializeField] private Slider staminaSlider;
    [SerializeField] private float maxStamina;
    private PlayerController playerController;
    public static float currentStamina;
    private bool isHealing;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        currentStamina = maxStamina;
    }

    private void Update()
    {
        StaminaProcess();
    }

    private void StaminaProcess()
    {
        if (playerController.IsDashing)
        {
            currentStamina -= 5f * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isHealing = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StartCoroutine("StaminaDelay");
        }

        if (isHealing)
        {
            Healing();
        }

        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        staminaSlider.value = currentStamina / maxStamina;
        staminaSlider.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0f, -0.9f, 0f));
    }

    private void Healing()
    {
        switch (currentStamina)
        {
            case >= 75:
                currentStamina += 3f * Time.deltaTime;
                break;
            case >= 50:
                currentStamina += 2f * Time.deltaTime;
                break;
            case >= 25:
                currentStamina += 1f * Time.deltaTime;
                break;
            default:
                currentStamina += 0.5f * Time.deltaTime;
                break;
        }
    }

    private IEnumerator StaminaDelay()
    {
        yield return new WaitForSeconds(currentStamina >= 25f ? 1f : 10f);

        isHealing = true;
    }
}
