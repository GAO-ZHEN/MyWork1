using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {
    public bool Hit_1;
    public bool Hit_2;
    public bool Hit_3;
    public bool Hit_4;
    public int point;
    
    // Use this for initialization
    void Start () {
       
	}

    // Update is called once per frame
    void Update()
    {
        if (Hit_1 == true)
        {
            point += 10;
            Hit_1 = false;
        }
        if (Hit_2 == true)
        {
            point += 9;
            Hit_2 = false;
        }
        if (Hit_3 == true)
        {
            point += 8;
            Hit_3 = false;
        }
        if (Hit_4 == true)
        {
            point += 7;
            Hit_4 = false;
        }
        
    }
}
