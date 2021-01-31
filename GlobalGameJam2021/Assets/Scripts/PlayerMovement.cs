using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    private Animator _anim;
    private SpriteRenderer _rend;

    private Player player;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        _rend = GetComponentInChildren<SpriteRenderer>();
        player = GetComponent<Player>();
    }
    private void Update()
    {
        if(player.CanMove)
            CheckForMovement();
    }

    private void CheckForMovement()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        var move = new Vector3(x, y, 0f);
        move *= moveSpeed * Time.deltaTime;

        transform.position += move;

        _anim.SetBool("isMoving", move != Vector3.zero);

        if(x != 0f)
            _rend.flipX = x < 0;

    }
}
