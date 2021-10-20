using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Acquisition : MonoBehaviour
{
    AcquisitionId _id;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    LayerMask playerLayer;

    public AcquisitionId Id { get => _id; set => _id = value; }

    protected void Init()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if (Id == AcquisitionId.Magic && Data.Player.GetComponent<Player>().IsMagicFull()) return;
            rb.velocity = 4*(collision.transform.position-gameObject.transform.position).normalized;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rb.velocity = new Vector3(0,0);
        }
    }
    private void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(gameObject.transform.position, 0.1f, playerLayer)) Dead();
    }
    public abstract void Dead();
}
