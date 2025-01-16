using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalScript : MonoBehaviour
{
  public GameObject player;
  public Vector2 startPosition = Vector2.zero;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject == player)
    {
      Debug.Log("Round Finished!");

      //yield return new WaitForSeconds(1);

      player.transform.position = startPosition;
      roundManager.Instance.ChangeRound();
    }
  }

  //IEnumerator handleGoalCollision()
  //{
  //  Debug.Log("Round Finished!");

  //  yield return new WaitForSeconds(1);

  //  player.transform.position = startPosition;
  //  roundManager.Instance.ChangeRound();
  //}

}
