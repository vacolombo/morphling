using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public enum playerColor {neutral, red, green, blue}

public class colorObject : MonoBehaviour
{
    public static Dictionary<playerColor, UnityEngine.Color> objectColor = new Dictionary<playerColor, UnityEngine.Color>
  {
    {playerColor.neutral, new UnityEngine.Color(1f,1f,1f)},
    {playerColor.red, new UnityEngine.Color(0.8018868f,0.3442061f,0.3442061f)},
    {playerColor.blue, new UnityEngine.Color(0.3450981f,0.5245275f,.8f)},
    {playerColor.green, new UnityEngine.Color(0.1137255f,0.5294118f,0.09411765f)}
  };

  public playerColor color;
  public SpriteRenderer spriteRenderer;

  public bool changeable = false;

  public SplatController splatController;

  private void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();

    //spriteRenderer.color = objectColor[color];
  }

  private void OnEnable()
  {
    if (changeable)
    {
      splatController.ChangeColor += changeColor;
    }
  }

  private void OnDisable()
  {
    if (changeable)
    {
      splatController.ChangeColor -= changeColor;
    }
  }

  //// Update is called once per frame
  //void Update()
  //{
  //  spriteRenderer.color = objectColor[color];
  //}

  private void changeColor(playerColor playerColor)
  {
    color = playerColor;
    spriteRenderer.color = objectColor[color];
  }
}
