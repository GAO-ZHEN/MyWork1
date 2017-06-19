using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keytest : MonoBehaviour {
    public Gun_Fire gunfire;
    public GameObject hittext;
    public GameObject hit;
    public GameObject reastart;
    public GameObject quit;
    public Button Reastart;
    public Button Quit;
	// Use this for initialization
	void Start () {
        hit.SetActive(false);
        hittext.SetActive(false);
        reastart.SetActive(false);
        quit.SetActive(false);
        Button btl1 = Reastart.GetComponent<Button>();
        btl1.onClick.AddListener(OnReaStart);
        Button btl2 = Quit.GetComponent<Button>();
        btl2.onClick.AddListener(Quiton);
    }
	
	// Update is called once per frame
	void Update () {
        if (gunfire.GameOver == true)
        {
            hit.SetActive(true);
            hittext.SetActive(true);
            reastart.SetActive(true);
            quit.SetActive(true);
            Time.timeScale = 0f;
        }
	}
    void OnReaStart() {
        Application.LoadLevel(1);
    }
    void Quiton()
    {
        Application.Quit();
    }
}
