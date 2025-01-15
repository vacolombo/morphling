using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
  public GameObject player;

  

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject == player)
    {
      Debug.Log("Player died!");
      player.transform.position = new Vector2(0, 0);
    }
  }
}
