using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun_Fire : MonoBehaviour
{
    public Transform camera;
    public Transform metahit;
    public Transform 槍焰;
    public Transform 彈殼;
    public Transform 彈孔;
    private RaycastHit Hit;
    public float RatOfSpeen = 0.5f;
    private float ratofspeen;
    private float FireTime;
    public int curAmmo = 0;
    public int maxAmmo = 7;
    public int inventoryAmmo = 2;
    public float TargetHit;
    public float gomiss;
    public AudioClip Shoot;
    public AudioClip Reloaded;
    public float Accuracy = 0.01f;
    public int animod;
    private float aniload;
    public AnimationClip M1911_Idle;
    public AnimationClip M1911_Reloaded;
    public AnimationClip M1911_Shoot;
    public AnimationClip M1911_Aimon;
    public AnimationClip M1911_Aimoff;
    public AnimationClip M1911_Noammo;
    public AnimationClip M1911_AimIdle;
    public AnimationClip M1911_AimShoot;
    string _idle;
    string _reloaded;
    string _shoot;
    string _aimon;
    string _aimoff;
    string _noammo;
    string _aimidle;
    string _aimshoot;
    public bool aim;
    public bool GameOver;
    public Text Ammo;
    public Text toHit;
    public Target target;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        OnText();
        TargetHit = target.point;
        _idle = M1911_Idle.name;
        _reloaded = M1911_Reloaded.name;
        _shoot = M1911_Shoot.name;
        _aimon = M1911_Aimon.name;
        _aimoff = M1911_Aimoff.name;
        _noammo = M1911_Noammo.name;
        _aimidle = M1911_AimIdle.name;
        _aimshoot = M1911_AimShoot.name;
        if (animod == 0)
        {
            GetComponent<Animation>().CrossFade(_idle);
        }
        if (animod == 1)
        {
            GetComponent<Animation>().Play(_aimon);
            animod = 4;
        }
        if (animod == 2)
        {
            GetComponent<Animation>().Play(_aimoff);
            animod = 0;
        }
        if (animod == 3)
        {
            GetComponent<Animation>().Play(_reloaded);
            aniload += Time.deltaTime;

        }
        if (aniload >= GetComponent<Animation>()[_reloaded].length)
        {
            Reload();
            animod = 0;
            aniload = 0;
        }

        if (animod == 4)
        {
            GetComponent<Animation>().CrossFade(_aimidle);
        }

        if (ratofspeen <= RatOfSpeen)
        {
            ratofspeen += Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire2") & aim == false & animod == 0)
        {
            animod = 1;
            aim = true;
        }
        else
            if (Input.GetButtonDown("Fire2") & aim == true)
        {
            animod = 2;
            aim = false;
        }
        if (Input.GetButtonDown("Fire1") & ratofspeen > RatOfSpeen & (animod == 0 || animod == 4) & curAmmo > 0)
        {
            GetComponent<AudioSource>().PlayOneShot(Shoot);
            if (aim == true)
            {
                GetComponent<Animation>().Play(_aimshoot);

            }
            else
            {
                GetComponent<Animation>().Play(_shoot);
            }

            Vector3 Direction = camera.TransformDirection(Vector3.forward + new Vector3(Random.Range(-Accuracy, Accuracy), Random.Range(-Accuracy, Accuracy), 0));
            curAmmo -= 1;
            槍焰.GetComponent<ParticleSystem>().Play();
            彈殼.GetComponent<ParticleSystem>().Play();
            if (Physics.Raycast(camera.position, Direction, out Hit, 1000f))
            {
                if (Hit.collider.CompareTag("標靶"))
                {
                    target.Hit_1 = true;
                }
                if (Hit.collider.CompareTag("標靶_1"))
                {
                    target.Hit_2 = true;
                }
                if (Hit.collider.CompareTag("標靶_2"))
                {
                    target.Hit_3 = true;
                }
                if (Hit.collider.CompareTag("標靶_3"))
                {
                    target.Hit_4 = true;
                }
                Quaternion HitRotation = Quaternion.FromToRotation(Vector3.up, Hit.normal);
                if (Hit.transform.GetComponent<Rigidbody>())
                {
                    Hit.transform.GetComponent<Rigidbody>().AddForceAtPosition(Direction * 800, Hit.point);
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.R) & inventoryAmmo > 0 & curAmmo != maxAmmo)
        {
            GetComponent<AudioSource>().PlayOneShot(Reloaded);
            aim = false;
            animod = 3;
        }
        if (inventoryAmmo == 0 & curAmmo == 0)
        {
            GameOver = true;
        }
    }
    public void Reload()
    {
        if (inventoryAmmo <= 0)
        {
            animod = 0;

        }
        else
        {
            curAmmo += maxAmmo - curAmmo;
            inventoryAmmo--;
        }

    }
    void OnText()
    {
        Ammo.text = "" + curAmmo + "/" + inventoryAmmo;
        toHit.text = "" + TargetHit;
    }
}
