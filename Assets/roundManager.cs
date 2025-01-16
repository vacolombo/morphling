using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundManager : MonoBehaviour
{
  public static roundManager Instance;

  public event Action<playerColor> RoundColorChange;
  public playerColor roundColor;

  public int roundCount = 1;
  public int colorCount = 4;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject); // Persist across scenes
    }
    else
    {
      Destroy(gameObject); // Enforce singleton
    }
  }

  public void ChangeRound(int round = -1)
  {
    if (round == -1)
    {
      round = roundCount++;
      round %= colorCount;
    }

    roundColor = (playerColor)round;
    RoundColorChange?.Invoke(roundColor);
  }

}
