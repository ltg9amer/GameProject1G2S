using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathCollectionName : MonoBehaviour
{
    private TextMeshProUGUI nameText;
    private Death death;

    private void Awake()
    {
        nameText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        death = GetComponent<Death>();
    }

    private void OnEnable()
    {
        if (death.experience)
        {
            nameText.text = death.deathName;
        }
        else
        {
            nameText.text = "???";
        }
    }
}
