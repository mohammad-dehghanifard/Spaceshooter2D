using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region PublicVaribles
    [Range(5,30)]
    public float BulletSpeed = 5f;
    public BulletDirection bulletDirection;
    #endregion

    #region Private Variable
    private readonly string EnemyTag = "Asteroid";
    private Vector3 BulletMove;
    #endregion

    #region PrivateFunctions
    private void Start()
    {
        if (bulletDirection == BulletDirection.up)
        {
            BulletMove = Vector3.up;
        }
        else if (bulletDirection == BulletDirection.down)
        {
            BulletMove = Vector3.down;
        }
    }

    private void Update() => transform.Translate( BulletMove * BulletSpeed * Time.deltaTime);

    // برخورد تیر با سیار ها و نابودی سیاره
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag)) {
            Destroy(obj: collision.gameObject);
            Destroy(obj: gameObject);
        }
    }

    #endregion
}


public enum BulletDirection {up,down}