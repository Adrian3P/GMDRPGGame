using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RPG.SceneManagement;
public class MainMenuButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject objectInMenu;

    void Awake(){
        foreach (var item in Object.FindObjectsOfType<DontDestroy>() ){
            Destroy(item.gameObject);
        }
        foreach (var item in Object.FindObjectsOfType<Portal>() ){
            Destroy(item.gameObject);
        }
    }
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
