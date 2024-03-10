using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 inputVec;
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    public Vector2 InputVec
    {
        get { return inputVec; }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }


    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);
    }

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        if (inputVec.x != 0)
        {
            spriteRenderer.flipX = inputVec.x < 0;
        }
    }
}
