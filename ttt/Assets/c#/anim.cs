using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{
    private Vector2 LookDirection; //定義看的方向
    private Vector2 Position;      //定義位置
    private Vector2 Move;          //定義移動量

    public Animator animator;      //定義乘載 ruby 的動畫控制器變數箱子
    public Rigidbody2D rb;         //定義剛體 (移動用)

    public float Speed = 10;
        
    void Start()
    {
        animator = GetComponent<Animator>();  //遊戲啟動取得 動畫控制元件
        rb = GetComponent<Rigidbody2D>();     //遊戲啟動取得 剛體元件
    }
    

    void FixedUpdate()
    {
        Position = transform.position;                 //把目前物件的位置給予ruby
        float horizontal = Input.GetAxis("Horizontal");//擷取左右按鍵的數值
        float vertical = Input.GetAxis("Vertical");    //擷取上下按鍵的數值
        print("Horizontal is:" + horizontal);          //檢查用 (顯示按鍵數值)
        print("Vertical is:" + vertical);              //檢查用 (顯示按鍵數值)

        Move = new Vector2(horizontal, vertical);      //把按鍵的數值給予 rubyMove

        //當按鍵輸入不為0時
        if(!Mathf.Approximately(Move.x, 0) || !Mathf.Approximately(Move.y, 0))
        {
            LookDirection = Move;        //當玩家按下移動按鍵時(不為0)，則給予 ruby 方位
            LookDirection.Normalize();   //標準化，使按鍵數值更快接近數值：1
        }

        //【控制混合樹的動畫】
        animator.SetFloat("走路X", LookDirection.x);  //給予朝向的數值
        animator.SetFloat("走路Y", LookDirection.y);  //給予朝向的數值
        animator.SetFloat("Speed", Move.magnitude);   //把rubyMove的移動向量給予 Speed

        //移動 ruby 位置
        Position = Position + Speed * Move * Time.deltaTime;
        rb.MovePosition(Position);  //使用剛體進行移動
    }
}
