using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    protected Animator TestMod;
    Vector3 mod;
    public GameObject Cube = null;
    public GameObject Cube2 = null;
    public GameObject Cube3 = null;
    public GameObject Ammo = null;
    public GameObject Gun = null;

    private float Run;
    private float RunSleep;
    private float Sleep = 7.0f;
    private float BeckSleep = 2.0f;
    private bool ik=false;
    private float delammo = 3.0f;
	// Use this for initialization
	void Awake() {
        TestMod = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (TestMod)
        {
            TestMod.SetFloat("Aim", ik ? 1 : 0, .1f, Time.deltaTime);
            float a = TestMod.GetFloat("Aim");
            float c = TestMod.GetFloat("Fier");
            if (Input.GetButton("Fire1") && c < 0.01 && a > 0.19)
            {
                TestMod.SetFloat("Fire", 1);
                if (Cube3 != null && Ammo != null)
                {
                    GameObject newAmmo = Instantiate(Ammo, Cube3.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    Rigidbody rd = newAmmo.GetComponent<Rigidbody>();
                    if (rd != null)
                    {
                        rd.velocity = Cube3.transform.TransformDirection(Vector3.forward * 50);
                        
                    }
                    Destroy(newAmmo, delammo);
                }
            }
            else
            {
                TestMod.SetFloat("Fire", 0, 0.1f, Time.deltaTime);
            }
            if (Input.GetButton("Fire2"))
            {
                if (ik && a > 0.99) { ik = false; }
                else if (!ik && a < 0.19) { ik = true; }
            }
            
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
    void OnAnimatorIK(int layerIndex)
    {
        float a = TestMod.GetFloat("Aim");
        if (layerIndex == 0)
        {
            if (Gun != null)
            {
               /* Vector3 Camera = Gun.transform.position;
                Camera.y = Camera.y + 0.2f * (Camera - TestMod.rootPosition).magnitude;

                TestMod.SetLookAtPosition(Camera);
                TestMod.SetLookAtWeight(a, 0.5f, 0.5f, 0.0f, 0.5f);*/
            }
               
        }
        if (layerIndex == 1)
        {
            if (Cube != null)
            {
                TestMod.SetIKPosition(AvatarIKGoal.LeftHand, Cube.transform.position);
                TestMod.SetIKRotation(AvatarIKGoal.LeftHand, Cube.transform.rotation);
                TestMod.SetIKPositionWeight(AvatarIKGoal.LeftHand, a);
                TestMod.SetIKRotationWeight(AvatarIKGoal.LeftHand, a);
            }
            if (Cube2 != null)
            {
                TestMod.SetIKPosition(AvatarIKGoal.RightHand, Cube2.transform.position);
                TestMod.SetIKRotation(AvatarIKGoal.RightHand, Cube2.transform.rotation);
                TestMod.SetIKPositionWeight(AvatarIKGoal.RightHand, a);
                TestMod.SetIKRotationWeight(AvatarIKGoal.RightHand, a);
            }
        }
    }
   
}
