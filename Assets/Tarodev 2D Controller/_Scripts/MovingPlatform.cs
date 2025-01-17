using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
  [Header("Setup")]
  public Transform platform;
  public enum rotation { forward, backwards };

  //Eventually might add criteria to activate platform
  public bool activated = true;

  [Header("Travel Properties")]
  public Vector3[] corners;
  public rotation _rotation = rotation.forward;
  public float speed = 2f;
  public int targetCorner = 0;

  private float distanceThisFrame;
  

  // Update is called once per frame
  void Update()
  {
    if (activated)
    {
      distanceThisFrame = speed * Time.deltaTime;
      platform.position = Vector3.MoveTowards(platform.position, corners[targetCorner], distanceThisFrame);

      if ((platform.position - corners[targetCorner]).magnitude <= distanceThisFrame)
      {
        if (_rotation == rotation.forward)
        {
          //There is no mod operator in C# :(
          targetCorner += corners.Length - 1;
          targetCorner %= corners.Length;
        } else
        {
          targetCorner++;
          targetCorner %= corners.Length;
        }
      }
    }
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.yellow;
    Gizmos.DrawLineStrip(corners, true);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      Debug.Log("On platform");
      other.transform.parent = transform; // Parent the player to the platform
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      other.transform.parent = null; // Unparent the player when they leave the platform
    }
  }
}
