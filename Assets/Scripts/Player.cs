using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Player : Animal,IGetHurtable,IPickable
{
    int _magic, _money, _defence;
    EquipId _equipment, _subEquipment;
    bool _skilling, _hurt, _exchange, _attacking, _filling, _use, _test;
    Vector2 _toMouse;
    [SerializeField]
    Item _toItem;
    [SerializeField]
    GameObject skill, mainHand, subHand,skillHand;
    [SerializeField]
    Slider healthUI, magicUI, defenceUI;

    public int Magic
    { 
        get => _magic;
        set
        {
            _magic = value < 0 ? 0 : value;
            magicUI.value = value;
        }
    }
    public new int Health
    {
        get => _health;
        set
        {
            _health = value < 0 ? 0 : value;
            healthUI.value = value;
        }
    }
    public int Defence
    {
        get => _defence;
        set
        {
            _defence = value < 0 ? 0 : value;
            defenceUI.value = value;
        }
    }
    public int Money { get => _money; set => _money = value; }
    public bool Skilling { get => _skilling; set => _skilling = value; }
    public bool Hurt { get => _hurt; set => _hurt = value; }
    public bool Exchange { get => _exchange; set => _exchange = value; }
    public bool Attacking { get => _attacking; set => _attacking = value; }
    public EquipId Equipment { get => _equipment; set => _equipment = value; }
    public EquipId SubEquipment { get => _subEquipment; set => _subEquipment = value; }
    public Vector2 ToMouse { get => _toMouse; set => _toMouse = value; }
    public bool Filling { get => _filling; set => _filling = value; }
    public Item ToItem { get => _toItem; set => _toItem = value; }
    public bool Use { get => _use; set => _use = value; }
    public bool Test { get => _test; set => _test = value; }

    // Start is called before the first frame update
    void Start()
    {
        Init();
        Skilling = Hurt = false;
        this.Equipment = EquipId.OrignalPistol;
        Magic = 180;
        Health = 5;
        Defence = 5;
        //this.SubEquipment = EquipId.BigSword;
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
        if(skillHand==null) skillHand = Instantiate(mainHand);
    }

    void GetMoney()
    {

    }

    void GetMagic()
    {

    }

    public void Pick(EquipId id)
    {
        if (SubEquipment == EquipId.Null)
        {
            SubEquipment = id;
            Exchange = true;
        }
        else
        {
            PickEquip.Create(Equipment, transform.position);
            Equipment = id;
            Data.FreshImage(mainHand, Data.GetImage(id));
        }
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
        FillFinish();
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
        if (Input.GetButtonDown("Use")) Use = true;
        if (Input.GetButtonDown("Test")) Test = true;
        if (Input.GetButton("Fire1")) Attacking = true;
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
        if(Attacking)
        {
            //ToMouse = new Vector2(0.6f, 0.8f);
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ToMouse =Data.Normalize(position-transform.position);
            Attack();
            Attacking = false;
        }
        if(Use)
        {
            if (ToItem != null) ToItem.Interactive(gameObject);
            Use = false;
        }
        if(Test)
        {
            Box.Create(transform.position);
            Test = false;
        }
    }
    void FillFinish()
    {
        Filling=false;
    }
    void Attack()
    {
        int depletion = Data.Get(Equipment).Depletion;
        if (Filling||Magic<depletion) return;
        Magic -= depletion;
        Filling = true;
        Data.Get(Equipment).Attack(gameObject);
        Invoke("FillFinish", Data.Get(Equipment).Interval);
    }
}
