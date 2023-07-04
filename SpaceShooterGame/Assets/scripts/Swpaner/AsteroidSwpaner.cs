using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSwpaner : MonoBehaviour
{

    #region Public Variable
    public GameObject AsteroidPref;
    [Range(0.5f,10f)]
    public float MainSwapaneTime = 0.5f, MaxSwapaneTime = 2f;
    public Vector2 XAxisLimitToSwpane;
    #endregion


    #region Private Functions
    private void Start() => StartCoroutine(swpaneAsteroid());
    

    private void Update()
    {

    }

    // این تابع به صورت رندوم شهاب سنگ در محور ایکس تولید میکنه
    private IEnumerator swpaneAsteroid()
    {
        yield return new WaitForSeconds(Random.Range(MainSwapaneTime, MaxSwapaneTime));
        // ایجاد رندوم روی محور ایکس ها
        Vector3 pos = transform.position;
        pos.x = Random.Range(XAxisLimitToSwpane.x, XAxisLimitToSwpane.y);
        // ساخت شهاب سنگ
        Instantiate(AsteroidPref,pos, Quaternion.identity);
        StartCoroutine(swpaneAsteroid());
    }

   
    #endregion

}