using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region PublicVaribles
    [Range(5,30)]
    public float BulletSpeed = 5f;
    #endregion

    #region Private Variable
    private readonly string EnemyTag = "Asteroid";
    #endregion

    #region PrivateFunctions
    private void Start()
    {

    }

    private void Update() => transform.Translate(Vector3.up * BulletSpeed * Time.deltaTime);

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
