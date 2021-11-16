using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    public Animator RubyAnim;


    // Start is called before the first frame update
    void Start()
    {
        RubyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rubyMove = transform.position;
        float PlayerMoveX = Input.GetAxis("Horizontal");
        float PlayerMoveY = Input.GetAxis("Vertical");
        RubyAnim.SetFloat("MoveX", PlayerMoveX);
        RubyAnim.SetFloat("MoveY", PlayerMoveY);
        rubyMove.x += PlayerMoveX * moveSpeed;
        rubyMove.y += PlayerMoveY * moveSpeed;
        transform.position = rubyMove;

        if (PlayerMoveX == 0 && PlayerMoveY == 0 )
        {
            RubyAnim.SetTrigger("Idle");
        };
    }
}
