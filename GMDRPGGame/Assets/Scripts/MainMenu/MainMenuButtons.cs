using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject objectInMenu;
    public void QuitGame(){
        Application.Quit(0);
    }

    public void PlayGame(){
        SceneManager.LoadScene("1stLevel");
    }

    public void playHitAnimation(){
        if (objectInMenu != null)
        {
            objectInMenu.GetComponent<Animator>().Play("HitAnimation", 0);
        }
    }
}
