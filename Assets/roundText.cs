using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class roundText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public int roundNumber = 1;

    private void OnEnable()
    {
        roundManager.Instance.RoundColorChange += handleRoundChange;
    }

    private void OnDisable()
    {
        roundManager.Instance.RoundColorChange -= handleRoundChange;
    }

    private void handleRoundChange(playerColor color)
    {
        roundNumber = roundManager.Instance.roundCount;

        if (roundNumber < 3)
        {
            textMeshPro.color = colorObject.objectColor[color];
            textMeshPro.text = "Round " + roundNumber.ToString() + ": " + color.ToString();
        } else
        {
            textMeshPro.color = colorObject.objectColor[playerColor.neutral];
            textMeshPro.text = "Level Completed!!";
        }
    }

}
