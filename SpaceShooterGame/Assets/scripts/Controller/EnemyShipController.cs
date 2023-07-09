using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    #region Public Vartiable
    [Range(2, 30)]
    public float Vspeed = 5f, Hspeed = 5f;
    [Range(0.5f,5f)]
    public float FirstTimeFire, RepetitionFire;
    public GameObject Bullet, FirePlace;
    [Range(1,12)]
    public int Health;
    #endregion

    #region Praivate Variable
    private int Direction = 0; // 1 => right -1 => left 0 => no left , no right
    #endregion

    #region Private Functions
   private void Start()
    {
        // تغیر جهت سفینه های دشمن
        InvokeRepeating("ChangeShipDirectio",1,0.2f);
        // شلیک سفینه دشمن
        InvokeRepeating("BulletFire",FirstTimeFire,RepetitionFire);
    }

   private void Update()
    {   
        // حرکت و تغییر جهت سفینه دشمن
        Vector3 move = Vector3.down;
        move.x = Direction * Hspeed;
        move.y = move.y * Vspeed; 
        transform.position += move * Time.deltaTime;

        CheckShipPosition();
    }

    //جلوگیری از خارج شدن سفینه دشمن از کناره ها
    private void CheckShipPosition()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x,-8.47f,8.47f);
        transform.position = pos;
    }

    // تغییر موقعیت سفینه دشمن
    private void ChangeShipDirectio() => Direction = Random.Range(-1, 2); // => 0,1,-1
    private void BulletFire() => Instantiate(Bullet,FirePlace.transform.position,Quaternion.identity);
    
    
    #endregion

}
