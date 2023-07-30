using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{

    //when start-button is pressed
    public void OnToTownButton(){
        SoundManager.instance.PlaySE(0);
    }
}
