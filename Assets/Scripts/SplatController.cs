using System;
using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;
using static Unity.VisualScripting.Member;
using static UnityEditor.Experimental.GraphView.GraphView;

//When the player jumps on an object with a SpriteRenderer, the player will gain the color of the sprite
//When the player jumps on the tilemap, they will leave a paint spatter of the player's color

public class SplatController : MonoBehaviour
{
  public static SplatController instance;
  public GameObject player;

  public Color color = Color.blue;
  public int renderOrder;
  public GameObject[] splats;

  public IPlayerController playerController;
  //public event Action<playerColor> ChangeColor;


  private void Awake()
  {
    instance = this;
    playerController = GetComponentInParent<IPlayerController>();
  }
  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.B))
    {
      MakeSplat();
    }
  }


  private void OnEnable()
  {
    playerController.Jumped += MakeSplat;
    playerController.GroundedChanged += DetectGroundColor;

  }

  private void OnDisable()
  {
    playerController.Jumped -= MakeSplat;
    playerController.GroundedChanged -= DetectGroundColor;

  }

  public void MakeSplat()
  {
    Vector3 randRotation = new Vector3(0f, 0f, UnityEngine. Random.Range(0, 360f));

    var newSplat = Instantiate(splats[UnityEngine.Random.Range(0, splats.Length)], player.transform.position, Quaternion.Euler(randRotation));
    var newSpriteRenderer = newSplat.GetComponent<SpriteRenderer>();

    newSpriteRenderer.color = color;

    renderOrder++;
    newSpriteRenderer.sortingOrder = renderOrder;
  }

  private void DetectGroundColor(bool grounded, float ignore)
  {
    var hit = Physics2D.Raycast(player.transform.position, Vector3.down, 2);

    if (hit)
    {
      hit.transform.TryGetComponent(out SpriteRenderer r);
      //hit.transform.TryGetComponent(out colorObject c);

      color = r ? r.color : color;
      //ChangeColor?.Invoke(c ? c.color : player.GetComponent<PlayerController>().playerColor);
    }
  }


}
