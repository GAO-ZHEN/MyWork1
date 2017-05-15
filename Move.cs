using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    Animator TestMod;
    Vector3 mod;

    private float Run;
    private float RunSleep;
    private float Sleep = 7.0f;
    private float BeckSleep = 2.0f;
	// Use this for initialization
	void Start () {
        TestMod = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Run = Input.GetAxis("Horizontal");
        RunSleep = Input.GetAxis("Vertical");
        TestMod.SetFloat("Run", Run);
        TestMod.SetFloat("RunSleep", RunSleep);
        mod = new Vector3(0, 0, RunSleep);
        mod = transform.TransformDirection(mod);
        if (RunSleep > 0.1) { mod *= Sleep; }
        else if (RunSleep < -0.1) { mod *= BeckSleep; }
        transform.localPosition += mod * Time.fixedDeltaTime;
        transform.Rotate(0, Run, 0);
    }
}
