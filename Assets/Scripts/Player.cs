using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Animal,IGetHurtable
{
    int _magic, _money, _defence;
    Equipment _equipment, _subEquipment;
    bool _skilling, _hurt;
    [SerializeField]
    GameObject skill;

    public int Magic { get => _magic; set => _magic = value; }
    public int Money { get => _money; set => _money = value; }
    public int Defence { get => _defence; set => _defence = value; }
    public Equipment Equipment { get => _equipment; set => _equipment = value; }
    public Equipment SubEquipment { get => _subEquipment; set => _subEquipment = value; }
    public bool Skilling { get => _skilling; set => _skilling = value; }
    public bool Hurt { get => _hurt; set => _hurt = value; }

    // Start is called before the first frame update
    void Start()
    {
        Init();
        Skilling = Hurt = false;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    private void FixedUpdate()
    {
        Movement();
        ToAnimator();
    }

    void Skill()
    {
        
    }

    void GetMoney()
    {

    }

    void GetMagic()
    {

    }

    void ChangeEquipment()
    {

    }

    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        Move(horizontalMove * Speed, verticalMove * Speed);
    }

    void getInput()
    {
        if (Input.GetButtonDown("Skill")) Skilling = true;
    }

    public void GetHurt()
    {
        
    }

    void ToAnimator()
    {
        float x = Rb.velocity.x, y = Rb.velocity.y;
        Anim.SetFloat("Moving", Mathf.Sqrt(x * x + y * y));
        if(Skilling) skill.SetActive(true);
    }
}
