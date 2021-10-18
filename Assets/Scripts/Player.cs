using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Player : Animal, IGetHurtable, IPickable
{
    #region Define
    private const int maxMagic=180, maxHealth=5, maxDefence=5;
    int _magic, _money, _defence, _coins;
    EquipId _equipment, _subEquipment;
    bool _skilling, _hurt, _exchange, _attacking, _filling, _use, _test;
    Vector2 _toMouse;
    [SerializeField]
    Item _toItem;
    [SerializeField]
    GameObject skill, mainHand, subHand, skillHand;
    [SerializeField]
    Slider healthUI, magicUI, defenceUI;
    [SerializeField]
    Text coinsUI;


    public int Magic
    {
        get => _magic;
        set
        {
            _magic = value < 0 ? 0 : value;
            _magic = value > maxMagic ? maxMagic : value;
            magicUI.value = value;
        }
    }
    public new int Health
    {
        get => _health;
        set
        {
            _health = value < 0 ? 0 : value; 
            _health = value > maxHealth ? maxHealth : value;
            healthUI.value = value;
        }
    }
    public int Defence
    {
        get => _defence;
        set
        {
            _defence = value < 0 ? 0 : value;
            _defence = value > maxDefence ? maxDefence : value;
            defenceUI.value = value;
        }
    }
    public int Coins
    { 
        get => _coins;
        set
        {
            _coins = value;
            coinsUI.text = value.ToString();
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
    #endregion
    void Start()
    {
        Init();
        Id = AnimalId.Player;
        Skilling = Hurt = false;
        this.Equipment = EquipId.OrignalPistol;
        Speed = 500;
        Magic = 180;
        Health = 5;
        Defence = 5;
        Coins = 0;
        AddDefence();
        //this.SubEquipment = EquipId.BigSword;
    }
    void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        Move(Speed * Input.GetAxis("Horizontal"), Speed * Input.GetAxis("Vertical"));
        ToAnimator();
    }
    void Skill()
    {
        Data.FreshImage(skillHand, Data.GetImage(Equipment));
        skill.SetActive(true);
        Invoke("SkillFinish", 10f);
    }
    public override void Dead()
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
        if (SubEquipment != EquipId.Null)
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
    public override void Move(float toX, float toY)
    {
        if (toX > 0) Rb.transform.localScale = new Vector3(1, 1, 1);
        if (toX < 0) Rb.transform.localScale = new Vector3(-1, 1, 1);
        Data.Move(Rb, toX, toY);
    }
    public void SkillFinish()
    {
        Skilling = false;
        skillHand.GetComponent<SpriteRenderer>().sprite = null;
        skill.SetActive(false);
    }
    void GetInput()
    {
        if (Input.GetButtonDown("Skill") && (!Skilling)) Skilling = true;
        if (Input.GetButtonDown("Exchange")) Exchange = true;
        if (Input.GetButtonDown("Use")) Use = true;
        if (Input.GetButtonDown("Test")) Test = true;
        if (Input.GetButton("Fire1")) Attacking = true;
    }
    public override void GetHurt(int demage)
    {
        if (demage > Defence)
        {
            demage -= Defence;
            Health -= demage;
            Defence = 0;
        }
        else Defence -= demage;
        if (Health <= 0) Dead();
    }
    void ToAnimator()
    {
        float x = Rb.velocity.x, y = Rb.velocity.y;
        Anim.SetFloat("Moving", Mathf.Sqrt(x * x + y * y));
        if (Skilling && !skill.activeSelf)
        {
            Skill();
        }
        if (Exchange) ChangeEquipment();
        if (Attacking)
        {
            Attack();
        }
        if (Use)
        {
            if (ToItem != null) ToItem.Interactive(gameObject);
            Use = false;
        }
        if (Test)
        {
            Data.Produce("Goblin1Sample",transform.position);
            Test = false;
        }
    }
    void FillFinish()
    {
        Filling = false;
    }
    void AddDefence()
    {
        Defence++;
        Invoke("AddDefence",5f);
    }
    void Attack()
    {
        int depletion = Data.Get(Equipment).Depletion;
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ToMouse = Data.Normalize(position - transform.position);
        if (Filling || Magic < depletion) return;
        Magic -= depletion;
        Filling = true;
        Data.Get(Equipment).Attack(Equipment,tag,mainHand, ToMouse);
        if (Skilling) Data.Get(Equipment).Attack(Equipment,tag, skillHand, ToMouse);
        Invoke("FillFinish", Data.Get(Equipment).Interval);
        Attacking = false;
    }
    public bool IsMagicFull()
    {
        return Magic == maxMagic;
    }
}
