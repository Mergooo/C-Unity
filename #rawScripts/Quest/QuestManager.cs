using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


using UnityEngine;




//クエスト全体を管理
public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject  EnemyPrefab;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;
    
    public GameObject questBG;    
    


    //敵に遭遇するテーブル：-1なら遭遇しない　0なら遭遇
    int [] encountTable = {-1, -1, 0, -1, 0, -1 };

    int currentStage = 0; //現在のステージ進行度
    private void Start(){
         stageUI.UpdateUI(currentStage);
    }



IEnumerator Seaching(){
         DialogTextManager.instance.SetScenarios(new string[] {"Searching..."});
     //背景を大きく
       questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f)
            .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));
        // フェードアウト
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 2f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));
      
      //二秒度をuiに反映
      yield return new WaitForSeconds(2f);
      

        currentStage++;
        // しんこうどをuiに反映
        stageUI.UpdateUI(currentStage);

        if(encountTable.Length <= currentStage){
            Debug.Log("クエストクリア");
            QuestClear();
            //クリア処理
        } else if(encountTable[currentStage]==0){
           EncountEnemy();

        } 
        else{
            stageUI.ShowButtons();
        }
}

//Nextボタンが押されたら
public void OnNextButton(){
    SoundManager.instance.PlaySE(0);
    stageUI.HideButtons();
    StartCoroutine(Seaching());
    }
public void OnToTownButton(){
SoundManager.instance.PlaySE(0);
}


void EncountEnemy(){
    DialogTextManager.instance.SetScenarios(new string[] {"A wild monster appeared"});
    stageUI.HideButtons();
   GameObject enemyObj = Instantiate(EnemyPrefab);
   EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
    battleManager.Setup(enemy);
}

public void EndBattle(){
    stageUI.ShowButtons();

}

void QuestClear(){

    DialogTextManager.instance.SetScenarios(new string[] {"You found a treasure. You should head back to the village "});
    SoundManager.instance.StopBGM();
    SoundManager.instance.PlaySE(2);
    //クエストクリアって表示する
    //町に戻るボタンのみ表示
    stageUI.ShowClearText();
//  sceneTransitionManager.LoadTo("Town");

}

}

