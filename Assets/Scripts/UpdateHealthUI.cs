using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthUI : MonoBehaviour
{
    [SerializeField] Slider healthSlider;

    public void UpdateHealthSlider(float healthPercentage)
    {
        healthSlider.value = healthPercentage;
    }
}
