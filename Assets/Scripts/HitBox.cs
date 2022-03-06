using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.GetComponent<Enemy>().isDead == false)
            {
                ScreenShake.Instance.Shake(1);
                other.GetComponent<Enemy>().TakeDamage(1);
            }
        }
    }
}
