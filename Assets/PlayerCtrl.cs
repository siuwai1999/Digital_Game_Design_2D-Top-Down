using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float MoveSpeed = 5;

    public Vector2 LookDirection;
    public Vector2 Position;
    public Vector2 PlayerMove;

    public Animator RubyAnim;
    public Rigidbody2D Rigi;


    // Start is called before the first frame update
    void Start()
    {
        RubyAnim = GetComponent<Animator>();
        Rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Position = transform.position;
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        PlayerMove = new Vector2(Horizontal, Vertical);

        if (!Mathf.Approximately(PlayerMove.x,0) || !Mathf.Approximately(PlayerMove.y, 0))    
        {
            LookDirection = PlayerMove;
            LookDirection.Normalize();
        }

        RubyAnim.SetFloat("LookX", LookDirection.x);
        RubyAnim.SetFloat("LookY", LookDirection.y);
        RubyAnim.SetFloat("Speed", PlayerMove.magnitude);

        Position += MoveSpeed * PlayerMove * Time.deltaTime;
        print("方向" + LookDirection + "位置" + Position + "速度" + PlayerMove);
        Rigi.MovePosition(Position);
    }
}
