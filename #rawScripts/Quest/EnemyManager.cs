// using System.Collections;
// using System.Collections.Generic;

using System;
using UnityEngine;
using DG.Tweening;


//敵を管理するもの　(　ステータス/クリック検出 )
public class EnemyManager : MonoBehaviour
{
    //record of method
    Action tapAction; // クリックされたとき実行したい関数　（外部から設定したい　）

    public  new string name;
    public  int hp;
    public  int at;
    public GameObject hitEffect; 
    
    // 攻撃
    public int Attack ( PlayerManager player){
         int damage =  player.Damage(at);
         return damage;
    }

    //ダメージを受ける
    public int Damage(int damage){
      Instantiate(hitEffect, this.transform, false);
      transform.DOShakePosition(0.3f, 0.5f,20,0,false, true);
        hp -= damage;
      if(hp <= 0){
        hp = 0;
      }
       return damage;
    }
// tapaction に関数を登録する関数をつくあ
public void AddEventListenerOnTap(Action action){
            tapAction += action;

}

    public void OnTap(){
        Debug.Log(" クリックされた");
        tapAction();
    }
}
