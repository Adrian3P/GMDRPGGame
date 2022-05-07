using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Control;
using UnityEngine.SceneManagement;
using RPG.SceneManagement;

public class ButtonFunctionality : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
    }

    public void onRestartButton(){

        foreach (var item in Object.FindObjectsOfType<DontDestroy>() ){
            if (gameObject.scene.buildIndex == -1)
            {
                Destroy(item.gameObject);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex != 0 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    public void onMainMenuButton(){
        SceneManager.LoadScene(0);
    }
}
