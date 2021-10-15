using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Animal,IGetHurtable
{
    int _magic, _money, _defence;
    EquipId _equipment, _subEquipment,_toEquipment;
    bool _skilling, _hurt,_exchange;
    [SerializeField]
    GameObject skill,mainHand,subHand;

    public int Magic { get => _magic; set => _magic = value; }
    public int Money { get => _money; set => _money = value; }
    public int Defence { get => _defence; set => _defence = value; }
    public bool Skilling { get => _skilling; set => _skilling = value; }
    public bool Hurt { get => _hurt; set => _hurt = value; }
    public EquipId Equipment { get => _equipment; set => _equipment = value; }
    public EquipId SubEquipment { get => _subEquipment; set => _subEquipment = value; }
    public EquipId ToEquipment { get => _toEquipment; set => _toEquipment = value; }
    public bool Exchange { get => _exchange; set => _exchange = value; }

    // Start is called before the first frame update
    void Start()
    {
        Init();
        Skilling = Hurt = false;
        this.Equipment = EquipId.OrignalPistol;
        this.SubEquipment = EquipId.BigSword;
        this.ToEquipment= EquipId.Null;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
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
        if(SubEquipment!=EquipId.Null)
        {
            EquipId temp = this.SubEquipment;
            this.SubEquipment = this.Equipment;
            this.Equipment = temp;
            Data.FreshImage(mainHand, Data.GetImage(this.Equipment));
            Data.FreshImage(subHand, Data.GetImage(this.SubEquipment));
        }
        Exchange = false;
    }

    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        Move(horizontalMove * Speed, verticalMove * Speed);
    }

    void GetInput()
    {
        if (Input.GetButtonDown("Skill")) Skilling = true;
        if (Input.GetButtonDown("Exchange")) Exchange = true;
    }

    public void GetHurt(int demage)
    {
        
    }

    void ToAnimator()
    {
        float x = Rb.velocity.x, y = Rb.velocity.y;
        Anim.SetFloat("Moving", Mathf.Sqrt(x * x + y * y));
        if (Skilling)
        {
            skill.SetActive(true);
            Skill();
        }
        if (Exchange) ChangeEquipment();

    }
}
