using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _WalkSpeed;
    [SerializeField] private float _DistanceToTurn = 0.4f;
    [SerializeField] private float _Offset = 1.6f;
    private Rigidbody2D _Rigidbody2D;

    private void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (IsFacingRight())
        {
            _Rigidbody2D.velocity = new Vector2(_WalkSpeed * Time.deltaTime, _Rigidbody2D.velocity.y);
        }
        else
        {
            _Rigidbody2D.velocity = new Vector2(-_WalkSpeed * Time.deltaTime, _Rigidbody2D.velocity.y);
        }
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(IsFacingRight() ? transform.position.x + _Offset : transform.position.x - _Offset, transform.position.y),
            IsFacingRight() ? Vector2.right : -Vector2.right, _DistanceToTurn);
        Debug.DrawRay(new Vector2(IsFacingRight() ? transform.position.x + _Offset : transform.position.x - _Offset, transform.position.y),
            (IsFacingRight() ? Vector2.right : -Vector2.right) * _DistanceToTurn, Color.green);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Turn"))
            {
                Debug.Log($"Hit {hit.collider.tag}");
                Turn();
            }
        }


    }
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) collision.GetComponent<PlayerController>().Die();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Turn();
    }

    private void Turn()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
