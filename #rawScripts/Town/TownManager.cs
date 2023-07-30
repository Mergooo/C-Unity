using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{

   private void Start() {
      DialogTextManager.instance.SetScenarios(new string[] {"Welcome back "});
   }
   public void OnToQuestButton(){
        SoundManager.instance.PlaySE(0);
   }
}
