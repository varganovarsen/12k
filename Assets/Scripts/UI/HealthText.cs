using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    TMP_Text healthText;
    private void OnEnable()
    {
        healthText = GetComponent<TMP_Text>();

        PlayerHealth.OnHealthChanged += UpdateHealthUI;
    }
    private void OnDisable()
    {
        
        PlayerHealth.OnHealthChanged -= UpdateHealthUI;
    }

    private void UpdateHealthUI(int setHealthTo)
    {
        healthText.text = setHealthTo.ToString();
    }
}
