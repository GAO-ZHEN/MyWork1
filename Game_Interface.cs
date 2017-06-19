using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Interface : MonoBehaviour {
    public Button goStart;
    public Button GameQuit;
    void Start()
    {
        Button inx1 = goStart.GetComponent<Button>();
        inx1.onClick.AddListener(GameStart);
        Button inx2 = GameQuit.GetComponent<Button>();
        inx2.onClick.AddListener(QuitGame);
    }
    void GameStart()
    {
        Application.LoadLevel(1);
    }
    void QuitGame()
    {
        Application.Quit();
    }

}
