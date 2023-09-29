using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ScoreHandler SCR;
    public LayerMask PlayerMask;
    public float CollectRadius = 0.5f;

    private void Start()
    {
      SCR = FindObjectOfType<ScoreHandler>();
    }

    void Update()
    {
        if (Physics2D.OverlapCircle(this.transform.position, CollectRadius, PlayerMask))
        {
          SCR.FoundCoin();
          Destroy(gameObject);
        }
    }
}
