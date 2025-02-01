using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public int roundNumber = 1;
    public int level = 1;

    private void Update()
    {
        level = SceneManager.GetActiveScene().buildIndex;

        textMeshPro.text = "Level " + level.ToString();
    }

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
        roundNumber++;

        if (roundNumber < 3)
        {
            textMeshPro.color = colorObject.objectColor[color];
        }
        else
        {
            textMeshPro.color = colorObject.objectColor[playerColor.neutral];
        }
    }
}
