using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelSceneManager : MonoBehaviour
{

    public void GoLevel1(){
        GameManager.Instance.GoToNextLevel(1f);
    }
    //StartGame

    public void ComeBack(){
        GameManager.Instance.ComeBack();
    }
}