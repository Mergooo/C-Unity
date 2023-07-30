using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



//playerとenemy 対戦の管理
public class BattleManager : MonoBehaviour
{
    public Transform playerDamagePanel; 
    public QuestManager questManager;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
     EnemyManager enemy;

     private void Start(){
        enemyUI.gameObject.SetActive(false);
        // StartCoroutine(SampleCol());
     }

    //サンプルコルーチン
    // IEnumerator  SampleCol(){
    //   Debug.Log("サンプルコルーチン開始");
    //   yield return new WaitForSeconds(2f);
    //   Debug.Log("2秒経過");
    // }


    // 初期設定
    public void  Setup(EnemyManager enemyManager){
        SoundManager.instance.PlayBGM("Battle");
        enemyUI.gameObject.SetActive(true);
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);

        enemy.AddEventListenerOnTap(PlayerAttack);
        
        // enemy.transform.DOMove(new Vector3(0,10,0),5f);
    }


    
    void PlayerAttack(){
        StopAllCoroutines();
        int damage = player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
         DialogTextManager.instance.SetScenarios(new string[] {
          "You attacked.\n the monster suffered "+ damage +" damage"});
        SoundManager.instance.PlaySE(1);
        if(enemy.hp <=0){
      
            StartCoroutine(EndBattle());
        } else{
         StartCoroutine(EnemyTurn());
        }
    } 
  
      IEnumerator EnemyTurn(){
        yield return new WaitForSeconds(4f);
        SoundManager.instance.PlaySE(1);
        playerDamagePanel.DOShakePosition(0.3f,0.5f,20, 0, false, true);
        int damage = enemy.Attack(player);
        playerUI.UpdateUI(player);
        DialogTextManager.instance.SetScenarios(new string[] {"The enemy attacked.\n You suffered "+ damage +" damage"});
    
      }

    IEnumerator EndBattle(){
      yield return new WaitForSeconds(2f);
        DialogTextManager.instance.SetScenarios(new string[] {"The monster ran away "});
        enemyUI.gameObject.SetActive(false);
         Destroy(enemy.gameObject);
         SoundManager.instance.PlayBGM("Quest");
         questManager.EndBattle();

    }  
   
}
