using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Control;
using UnityEngine.SceneManagement;

public class ButtonFunctionality : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.gameObject.GetComponent<PlayerController>().enabled = false;
    }

    public void onRestartButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onMainMenuButton(){
        SceneManager.LoadScene(0);
    }
}
