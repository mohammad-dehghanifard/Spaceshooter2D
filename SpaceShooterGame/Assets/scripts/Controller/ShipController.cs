using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    #region PublicVaribles 
    [Range(5,100)]
    public float Speed = 5f;
    #endregion

    private void Start()
    {
        
    }

   private void Update()
    {
        // حرکت سفینه
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.position += Speed * Time.deltaTime * new Vector3(x,y,0);

        // خارج نشدن سفینه از صفجه
        Vector3 vector3 = new Vector3(
         Mathf.Clamp(transform.position.x, -8.83f, 8.83f),
         Mathf.Clamp(transform.position.y, -4.16f, 4.16f),
         transform.position.z);
        transform.position = vector3;
    }
}
