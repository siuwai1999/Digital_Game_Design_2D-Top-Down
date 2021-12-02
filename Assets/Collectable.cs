using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("值")]
    public int Number = 1;
    [Header("銷毀")]
    public bool Dest = true;
    [Header("粒子")]
    public GameObject Part;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Part != null) { Instantiate(Part, gameObject.transform.position, Quaternion.identity); }
        PlayerCtrl playerCtrl = collision.GetComponent<PlayerCtrl>();
        playerCtrl.AddHP(Number);
        print("撿取物件");
        if (Dest) { Destroy(gameObject); }
    }
}
