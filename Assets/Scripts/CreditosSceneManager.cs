using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
 public AudioClip creidtsTheme;
    private void Start() 
    {
        if (creidtsTheme != null)
        GameManager.Instance.audioManager.PlayMusic(creidtsTheme);
    }

    public void VolverAtrás(){
        GameManager.Instance.ComeBack();
    }

    public void IrMenu(){
        GameManager.Instance.ToMenu();
    }
}
