using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
   public int CoinScore = 0;
   public TMP_Text Scoretext;

   private void Update()
   {
    Scoretext.text = "" + CoinScore;
   }

   public void FoundCoin()
   {
    CoinScore = CoinScore + 1;
   }
}
