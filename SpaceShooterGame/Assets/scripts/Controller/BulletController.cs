using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region PublicVaribles
    [Range(5,30)]
    public float BulletSpeed = 5f;
    #endregion

    #region PrivateFunctions
    private void Start()
    {

    }

    private void Update()
    {
        transform.Translate(Vector3.up * BulletSpeed * Time.deltaTime);
    }
    #endregion
}
