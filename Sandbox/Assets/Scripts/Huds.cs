using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Huds : MonoBehaviour
{
    public Slider healthBar;
    public Image playerIcon;

    public void SetHealthBar(float health)
    {
        healthBar.maxValue = health;
    }

    public void ChangeHealthBar(float health)
    {
        healthBar.value = health;
    }
}
