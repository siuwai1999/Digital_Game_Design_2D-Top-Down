using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    [Header("最大HP")]
    public int MaxHP = 10;

    [Header("當前HP")]
    public int HP = 10;

    [Header("移動速度")]
    public float MoveSpeed = 6;

    public Vector2 LookDirection;
    public Vector2 Position;
    public Vector2 PlayerMove;

    public GameObject proj;
    private AudioSource AudioSource;

    public Animator RubyAnim;
    public Rigidbody2D Rigi;

    public void AddHP(int Amout)
    {
        HP += Amout;
        if (HP > MaxHP) { HP = MaxHP; }
    }

    public void PlauySound(AudioClip audioClip)
    {
        AudioSource.PlayOneShot(audioClip);
    }

    public void Launch()
    {
        GameObject project = Instantiate(proj,Rigi.position,Quaternion.identity);
        Bullet bullet = project.GetComponent<Bullet>();
        bullet.Launch(LookDirection, 300);
        print("1231231");
        //rubyanim
    }

    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        AudioSource = GetComponent<AudioSource>();
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
        Rigi.MovePosition(Position);

    }

    void debug()
    {
        Debug.Log("方向" + LookDirection + "位置" + Position + "速度" + PlayerMove + "\n" + " 當前HP " + HP);
    }

    void Update()
    {


        if (HP <= 0)
        {
            SceneManager.LoadScene("Dead");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
    }

}
