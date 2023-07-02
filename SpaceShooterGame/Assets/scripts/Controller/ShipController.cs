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
        // حرکت پلیر
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.position += Speed * Time.deltaTime * new Vector3(x,y,0);
    }
}
