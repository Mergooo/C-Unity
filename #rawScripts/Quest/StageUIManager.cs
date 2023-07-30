using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



// StageUI(ステージ数/進行ボタン/町に戻るボタン）の管理
public class StageUIManager : MonoBehaviour
{
    public Text stegeText;
    public GameObject nextButton;
    public GameObject toTownButton;
    public GameObject StageClearImage;

    private void Start(){
     StageClearImage.SetActive(false);
    }

    public void UpdateUI(int currentStage){
        stegeText.text = string.Format(" ステージ:{0}", currentStage+1);
    }

    public void HideButtons(){
        nextButton.SetActive(false);
        toTownButton.SetActive(false);
    }
    public void ShowButtons(){
        nextButton.SetActive(true);
        toTownButton.SetActive(true);
    }

    public void ShowClearText(){
     StageClearImage.SetActive(true);
         nextButton.SetActive(false);
        toTownButton.SetActive(true);
    }



}
