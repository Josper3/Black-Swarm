using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour 
{
    public AudioClip mainMenuTheme;
    private void Start() 
    {
        if (mainMenuTheme != null)
        GameManager.Instance.audioManager.PlayMusic(mainMenuTheme);
    }
    public void SelecLevel() {
        GameManager.Instance.GoToSelecLevel();
    }

    public void StartCreditos(){
        //int num_niveles = GameManager.Instance.GetNumberOfLevels();
        GameManager.Instance.LoadCredits();
    }

    public void Quit() {
        GameManager.Instance.Quit();
    }
}