using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 回血 : MonoBehaviour
{
    public GameObject PickE;
    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(PickE, gameObject.transform.position, Quaternion.identity);

        anim Ruby = collision.GetComponent<anim>();
        print("碰到的東西是:" + Ruby);

        Ruby.PlaySound(audioClip);
        Ruby.ChangeHealth(1);
        Destroy(gameObject);
    }
}
