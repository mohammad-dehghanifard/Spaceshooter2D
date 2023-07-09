using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    #region PublicVaribles 
    [Range(5,100)]
    public float Speed = 5f;
    public GameObject BulletObject,FirePlace;
    public int Health {get {return ShipHealth; }}
    #endregion

    #region Private Variable
    [Range(1,10)]
    [SerializeField]
    private int ShipHealth;
    private const string EnemyShipTag = "EnemyShip", AsteroidTag = "Asteroid", EnemyBulletTag = "EnemyBullet";
    #endregion

    #region Private Functions
    private void Update()
    {
        // حرکت سفینه
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.position += Speed * Time.deltaTime * new Vector3(x, y, 0);

        // شلیک تیر
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletObject,FirePlace.transform.position,Quaternion.identity);
        }

        // خارج نشدن سفینه از صفجه
        Vector3 vector3 = new Vector3(
         Mathf.Clamp(transform.position.x, -8.83f, 8.83f),
         Mathf.Clamp(transform.position.y, -4.16f, 4.16f),
         transform.position.z);
        transform.position = vector3;

        if (ShipHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag(EnemyShipTag)) // برخورد سفینه بازیکن با سفینه دشمن
        {
            ShipHealth -= collision.gameObject.GetComponent<EnemyShipController>().Health;
        }else if (collision.tag == AsteroidTag) // برخورد سفینه بازیکن با سیارک ها
        {
            ShipHealth -= collision.gameObject.GetComponent<AsteroidController>().Health;
        }else if (collision.tag == EnemyBulletTag) // برخورد سفینه دشمن با تیر دشمن
        {
            ShipHealth -= collision.gameObject.GetComponent<BulletController>().Power;
           
        }
    }
    #endregion
}
