using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Player : Animal, IGetHurtable, IPickable
{
    #region Define
    float _skillTime;
    public static float skillCD = 5;
    public static int maxMagic = 180, maxHealth = 5, maxDefence = 5;
    int _magic, _defence, _coins;
    EquipId _equipment, _subEquipment, _extraEquipment;
    bool _skilling, _hurt, _exchange, _attacking, _filling, _use, _test;
    [SerializeField]
    Item _toItem;
    [SerializeField]
    GameObject skill, mainHand, subHand, skillHand;
    Slider _healthUI, _magicUI, _defenceUI, _skillUI;
    [SerializeField]
    Text _coinsUI;
    public RuntimeAnimatorController fire, brandish;


    public int Magic
    {
        get => _magic;
        set
        {
            _magic = value < 0 ? 0 : value;
            _magic = value > maxMagic ? maxMagic : value;
            MagicUI.value = value;
        }
    }
    public new int Health
    {
        get => _health < 0 ? 0 : _health;
        set
        {
            _health = value < 0 ? 0 : value;
            _health = value > maxHealth ? maxHealth : value;
            HealthUI.value = value;
        }
    }
    public int Defence
    {
        get => _defence;
        set
        {
            _defence = value < 0 ? 0 : value;
            _defence = value > maxDefence ? maxDefence : value;
            DefenceUI.value = value;
        }
    }
    public int Coins
    {
        get => _coins;
        set
        {
            _coins = value;
            CoinsUI.text = value.ToString();
        }
    }
    public bool Skilling { get => _skilling; set => _skilling = value; }
    public bool Hurt { get => _hurt; set => _hurt = value; }
    public bool Exchange { get => _exchange; set => _exchange = value; }
    public bool Attacking { get => _attacking; set => _attacking = value; }
    public EquipId Equipment { get => _equipment; set => _equipment = value; }
    public EquipId SubEquipment { get => _subEquipment; set => _subEquipment = value; }
    public Vector3 MousePos
    {
        get
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return new Vector3(position.x, position.y, 0);
        }
    }
    public Vector3 ToMouse
    {
        get
        {
            return (MousePos - transform.position).normalized;
        }
    }
    public bool Filling { get => _filling; set => _filling = value; }
    public Item ToItem { get => _toItem; set => _toItem = value; }
    public bool Use { get => _use; set => _use = value; }
    public bool Test { get => _test; set => _test = value; }
    public Slider HealthUI
    {
        get => _healthUI == null ? _healthUI = GameObject.Find("Health").GetComponent<Slider>() : _healthUI;
    }
    public Slider MagicUI
    {
        get => _magicUI == null ? _magicUI = GameObject.Find("Magic").GetComponent<Slider>() : _magicUI;
    }
    public Slider DefenceUI
    {
        get => _defenceUI == null ? _defenceUI = GameObject.Find("Defence").GetComponent<Slider>() : _defenceUI;
    }
    public Slider SkillUI
    {
        get => _skillUI == null ? _skillUI = GameObject.Find("SkillUI").GetComponent<Slider>() : _skillUI;
    }
    public Text CoinsUI
    {
        get => _coinsUI == null ? _coinsUI = GameObject.Find("CoinsNum").GetComponent<Text>() : _coinsUI;
    }
    public EquipId ExtraEquipment { get => _extraEquipment; set => _extraEquipment = value; }
    public float SkillTime
    {
        get => _skillTime;
        set
        {
            _skillTime = value < 0 ? 0 : value;
            _skillTime = value > skillCD ? skillCD : value;
            SkillUI.value = value;
        }
    }
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
        SkillTime = skillCD;
        AddDefence();
        //this.SubEquipment = EquipId.BigSword;
    }
    void Update()
    {
        GetInput();
        if (!skill.activeSelf)
        {
            SkillTime += Time.deltaTime;
        }
        else SkillTime -= Time.deltaTime;
        //if (SkillTime == skillCD)
        //{
        //    Debug.Log(SkillUI.enabled);
        //    if (SkillUI.enabled)
        //    {
        //        SkillUI.enabled = false;
        //        Debug.Log(SkillUI.enabled);
        //    }
        //}
        //else if (!SkillUI.enabled)
        //{
        //    SkillUI.enabled = true;
        //}
    }
    private void FixedUpdate()
    {
        Move(Speed * Input.GetAxis("Horizontal"), Speed * Input.GetAxis("Vertical"));
        ToAnimator();
        //ToHandSword();
    }
    void Skill()
    {
        //QuitHandSword();
        Data.FreshImage(skillHand.transform.GetChild(0).gameObject, Data.GetImage(Equipment));
        skill.SetActive(true);
        Invoke("SkillFinish", skillCD);
    }
    public override void Dead()
    {
        Data.SettingUI.GetComponent<UIControl>().NewGameClick();
    }
    public void Pick(EquipId id)
    {
        if (skill.activeSelf) return;
        if (SubEquipment == EquipId.Null)
        {
            SubEquipment = id;
            Exchange = true;
        }
        else
        {
            PickEquip.Create(Equipment, transform.position);
            Equipment = id;
            Data.FreshImage(mainHand.transform.GetChild(0).gameObject, Data.GetImage(id));
        }
    }
    void ChangeEquipment()
    {
        if (SubEquipment != EquipId.Null && !skill.activeSelf)
        {
            //QuitHandSword();
            EquipId temp = this.SubEquipment;
            this.SubEquipment = this.Equipment;
            this.Equipment = temp;
            Data.FreshImage(mainHand.transform.GetChild(0).gameObject, Data.GetImage(this.Equipment));
            Data.FreshImage(subHand, Data.GetImage(this.SubEquipment));
        }
        Exchange = false;
        FillFinish();
    }
    public override void Move(float toX, float toY)
    {
        if (!Input.GetButton("Fire1"))
        {
            if (toX > 0) Face(1);
            if (toX < 0) Face(-1);
        }
        Data.Move(Rb, toX, toY);
    }
    public void SkillFinish()
    {
        Skilling = false;
        skillHand.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = null;
        skill.SetActive(false);
    }
    void GetInput()
    {
        if (Input.GetButtonDown("Skill") && (!Skilling)) Skilling = true;
        if (Input.GetButtonDown("Exchange")) Exchange = true;
        if (Input.GetButtonDown("Use")) Use = true;
        if (Input.GetButtonDown("Test")) Test = true;
        if (Input.GetButton("Fire1"))
        {
            int direction = MousePos.x < transform.position.x ? -1 : 1;
            Face(direction);
            FlipHand(direction);
            RotateHand(ToMouse);
            Attacking = true;
        }
        else
        {
            RotateHand(new Vector3(1, 0));
            FlipHand(1);
        }
    }
    public override void GetHurt(int demage)
    {
        HurtAnimation();
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
        if (Skilling && !skill.activeSelf && SkillTime == skillCD)
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
            Portal.Create(transform.position);
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
        Invoke("AddDefence", 5f);
    }
    void Attack()
    {
        int depletion = Data.Get(Equipment).Depletion;
        if (Filling || Magic < depletion) return;
        Magic -= depletion;
        Filling = true;
        HandAnimation(mainHand);
        Data.Get(Equipment).Attack(Equipment, tag, mainHand, ToMouse);
        if (skill.activeSelf)
        {
            HandAnimation(skillHand);
            Data.Get(Equipment).Attack(Equipment, tag, skillHand, ToMouse);
        }
        Invoke("FillFinish", Data.Get(Equipment).Interval);
        Attacking = false;
    }
    public bool IsMagicFull()
    {
        return Magic == maxMagic;
    }
    void RotateHand(Vector3 towards)
    {
        skillHand.transform.right = mainHand.transform.right = towards;
    }
    void Face(int direction)
    {
        transform.localScale = new Vector3(direction, 1, 0);
    }
    void FlipHand(int direction)
    {
        skillHand.transform.localScale = mainHand.transform.localScale = new Vector3(direction, direction, 0);
    }
    void HandAnimation(GameObject hand)
    {
        Animator anim = hand.transform.GetChild(0).gameObject.GetComponent<Animator>();
        if (Data.Get(Equipment).Type == EquipType.Gum) anim.runtimeAnimatorController = fire;
        else anim.runtimeAnimatorController = brandish;
        anim.PlayInFixedTime(0);
    }
    ////void ToHandSword()
    ////{
    ////    if(Physics2D.OverlapCircle(transform.position,1f,LayerMask.NameToLayer("Enemy")))
    ////    {
    ////        if (skill.activeSelf || ExtraEquipment != EquipId.Null) return;
    ////        //Debug.Log("*");
    ////        Debug.Log(Physics2D.OverlapCircle(transform.position, 1f, LayerMask.NameToLayer("Enemy")));
    ////        ExtraEquipment = Equipment;
    ////        Equipment = EquipId.HandSword;
    ////        //Debug.Log(Equipment);
    ////    }
    ////    else if(ExtraEquipment!=EquipId.Null)
    ////    {
    ////        //Debug.Log("!");
    ////        Equipment = ExtraEquipment;
    ////        ExtraEquipment = EquipId.Null;
    ////        //Debug.Log(Equipment);
    ////    }
    ////}
    ////void QuitHandSword()
    ////{
    ////    if (ExtraEquipment != EquipId.Null)
    ////    {
    ////        Equipment = ExtraEquipment;
    ////        ExtraEquipment = EquipId.Null;
    ////    }
    ////}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.grey;

        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
