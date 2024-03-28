using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D target;

    private bool isLive = true;

    private Rigidbody2D rb;
    private SpriteRenderer spriter;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!isLive)
        {
            return;
        }
        Vector2 dirVec = target.position - rb.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);
        rb.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
          if (!isLive)
        {
            return;
        }
        spriter.flipX = target.position.x < rb.position.x;
    }
}
