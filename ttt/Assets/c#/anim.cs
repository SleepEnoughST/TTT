using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anim : MonoBehaviour
{
    #region ���
    private Vector2 LookDirection; //�w�q�ݪ���V
    private Vector2 Position;      //�w�q��m
    private Vector2 Move;          //�w�q���ʶq

    public Animator animator;      //�w�q���� ruby ���ʵe����ܼƽc�l
    public Rigidbody2D rb;         //�w�q���� (���ʥ�)

    public float Speed = 10;

    [Header("�̰���q")]
    public int MaxHealth = 5;
    [Header("��e��q"), Range(0, 5)]
    public int CurrentHealth;

    public GameObject projectilePrefab;

    #endregion
    void Start()
    {
        animator = GetComponent<Animator>();  //�C���Ұʨ��o �ʵe�����
        rb = GetComponent<Rigidbody2D>();     //�C���Ұʨ��o ���餸��

        CurrentHealth = MaxHealth;
        print("Ruby��e��q��:" + CurrentHealth);
    }
    

    void FixedUpdate()
    {
        Position = transform.position;                 //��ثe���󪺦�m����ruby
        float horizontal = Input.GetAxis("Horizontal");//�^�����k���䪺�ƭ�
        float vertical = Input.GetAxis("Vertical");    //�^���W�U���䪺�ƭ�
        //print("Horizontal is:" + horizontal);          //�ˬd�� (��ܫ���ƭ�)
        //print("Vertical is:" + vertical);              //�ˬd�� (��ܫ���ƭ�)

        Move = new Vector2(horizontal, vertical);      //����䪺�ƭȵ��� rubyMove

        //������J����0��
        if(!Mathf.Approximately(Move.x, 0) || !Mathf.Approximately(Move.y, 0))
        {
            LookDirection = Move;        //���a���U���ʫ����(����0)�A�h���� ruby ���
            LookDirection.Normalize();   //�зǤơA�ϫ���ƭȧ�ֱ���ƭȡG1
        }

        //�i����V�X�𪺰ʵe�j
        animator.SetFloat("����X", LookDirection.x);  //�����¦V���ƭ�
        animator.SetFloat("����Y", LookDirection.y);  //�����¦V���ƭ�
        animator.SetFloat("Speed", Move.magnitude);   //��rubyMove�����ʦV�q���� Speed

        //���� ruby ��m
        Position = Position + Speed * Move * Time.deltaTime;
        rb.MovePosition(Position);  //�ϥέ���i�沾��

        if (CurrentHealth == 0)
        {
            Application.LoadLevel("����");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
            
    }

    public void ChangeHealth(int amout)
    {
        //CurrentHealth = CurrentHealth + amout;
        CurrentHealth = Mathf.Clamp(CurrentHealth + amout, 0, MaxHealth);
        print("Ruby ��e��q��:" + CurrentHealth);
    }
        
    private void Launch()
    {
        GameObject projectileOnject = Instantiate(projectilePrefab, rb.position, Quaternion.identity);

        Bullet bullet = projectileOnject.GetComponent<Bullet>();

        bullet.Launch(LookDirection, 300);

        animator.SetTrigger("Launch");
    }
}
