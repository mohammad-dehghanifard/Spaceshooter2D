using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    #region Public Variables
    #endregion

    #region Private Variables
    [SerializeField]
    private Animator anim;
    #endregion

    #region Praivate Functions
   private void Start()
    {
        StartCoroutine(DestroyAnim());
    }

    private IEnumerator DestroyAnim()
    {
        //anim.GetCurrentAnimatorStateInfo(0).length => طول زمان اجرای انیمیشن رو برمیگردونه
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
    #endregion

}
