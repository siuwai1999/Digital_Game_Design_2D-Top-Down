using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("��")]
    public int Number = 1;
    [Header("�P��")]
    public bool Dest = true;
    [Header("�ɤl")]
    public GameObject Part;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Part != null) { Instantiate(Part, gameObject.transform.position, Quaternion.identity); }
        PlayerCtrl playerCtrl = collision.GetComponent<PlayerCtrl>();
        playerCtrl.AddHP(Number);
        print("�ߨ�����");
        if (Dest) { Destroy(gameObject); }
    }
}
