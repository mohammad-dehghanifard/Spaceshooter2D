using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    #region Public Variable
    [Range(0,100)]
    public float Speed = 5, RotaionSpeed = 20;
    [Range(1,6)]
    public int Health = 1;
    public GameObject Explosion; // بنظر میرسه انیمیشن انفجار خود سیاره باعث خطا تو بازی میشه
    #endregion



    #region Private Variable
    private const string PlayerTag = "Players";
    private const string PlayerBulletTag = "PlayerBullet";
    private const string AnimationParamKey = "health";
    private Animator anim;
    #endregion

    #region Private Functions

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        //  سقوط سیاره
        transform.position += Vector3.down * Speed * Time.deltaTime;
        transform.Rotate(Vector3.forward * RotaionSpeed * Time.deltaTime);

        // تغییر انیمیشن
        anim.SetInteger(AnimationParamKey,Health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // برخورد سیاره یا سیفنه بازکین
        if (collision.CompareTag(PlayerTag))
        {
            //Destroy(obj: collision.gameObject);
            //Destroy(obj: gameObject);
        }

        if (collision.CompareTag(PlayerBulletTag))
        {
            int BulletPower = collision.gameObject.GetComponent<BulletController>().Power; // دسترسی به قدرت گلوله
            Health = Health - BulletPower;
            CheckHealth();
        }
    }

    private void CheckHealth()
    {
        if(Health == 0)
        {
            Instantiate(Explosion,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }

    #endregion

}
