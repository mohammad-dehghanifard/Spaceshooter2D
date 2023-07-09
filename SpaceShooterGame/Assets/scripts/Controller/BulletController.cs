using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region PublicVaribles
    [Range(5,30)]
    public float BulletSpeed = 5f;
    public BulletDirection bulletDirection;
    public GameObject ExplosionPrefab;
    [Range(1,10)]
    public int Power = 1;
    #endregion

    #region Private Variable
    private readonly string EnemyTag = "Asteroid";
    private readonly string PlayerTag = "Players";
    private readonly string EnemyShipTag = "EnemyShip";
    private Vector3 BulletMove;
    #endregion

    #region PrivateFunctions
    private void Start()
    {
        BulletMove = bulletDirection == BulletDirection.down ? Vector3.down : Vector3.up ;
    }

    private void Update() => transform.Translate( BulletMove * BulletSpeed * Time.deltaTime);

    // برخورد تیر با سیار ها و نابودی سیاره
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
      
        if (collision.CompareTag(EnemyTag)) {
            
            Destroy(obj: gameObject);
        }

        // نابود شدن سفینه بازکین با تیر دشمن
        if (bulletDirection == BulletDirection.down && collision.CompareTag(PlayerTag))
        {
            Vector2 collisionPoint = collision.ClosestPoint(transform.position); // => اولین نقطه ای که برخورد صورت بگیره رو برمیگردونه
            Instantiate(ExplosionPrefab, collisionPoint, Quaternion.identity); // =>  ایجاد انیمیشن انفجار

            Destroy(obj: collision.gameObject);
            Destroy(obj: gameObject);
        }

        // نابود شدن سفینه دشمن توسط تیر بازیکن
        if (bulletDirection == BulletDirection.up && collision.CompareTag(EnemyShipTag))
        {
            Destroy(obj: collision.gameObject);
            Destroy(obj: gameObject);
        }
    }
    #endregion
}


public enum BulletDirection {up,down}