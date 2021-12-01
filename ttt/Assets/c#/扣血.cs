using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 扣血 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim Ruby = collision.GetComponent<anim>();

        Ruby.ChangeHealth(-1);
    }
}
