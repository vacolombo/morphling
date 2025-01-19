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
  public float alphaValue = .03f;

  public bool changeable = false;

  public SplatController splatController;

  private void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();

    handleRoundChange(roundManager.Instance.roundColor);
  }

  private void OnEnable()
  {
    roundManager.Instance.RoundColorChange += handleRoundChange;
  }

  private void OnDisable()
  {
    roundManager.Instance.RoundColorChange -= handleRoundChange;
  }

  private void changeColor(playerColor playerColor)
  {
    color = playerColor;
    spriteRenderer.color = objectColor[color];
  }

  private void handleRoundChange(playerColor roundColor)
  {
    //if (changeable)
    //{
    //  changeColor(roundColor);
    //}

    //if (color == playerColor.neutral)
    //{
    //  return;
    //}

    if (roundManager.Instance.roundColor == color || color == playerColor.neutral)
    {
      GetComponent<BoxCollider2D>().enabled = true;
      spriteRenderer.color = objectColor[color];
    } else
    {
      GetComponent<BoxCollider2D>().enabled = false;
      Color transparent = objectColor[color];
      transparent.a = alphaValue;
      spriteRenderer.color = transparent;
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (changeable)
    {
      collision.gameObject.TryGetComponent(out PlayerController player);
      Debug.Log(name);
      playerColor playerColor = player ? collision.gameObject.GetComponent<PlayerController>().playerColor : color;
      changeColor(playerColor);
    }

}
}
