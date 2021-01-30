using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private GameObject outlineGameObject;
    private bool _isPlayerInRange = false;

    public InteractionInput _input = new InteractionInput();

    public Item item;
    private void Awake()
    {
        _isPlayerInRange = false;
        ToggleOutline(false);
        item = GetComponent<Item>();
    }

    private void Update()
    {
        CheckForPlayerInteraction();
    }

    private void CheckForPlayerInteraction()
    {
        if (_isPlayerInRange && _input.IsPlayerInteracting)
        {
            Player.Instance.inventory.ChangeItem(item);
        }
    }

    private void ToggleOutline(bool isEnabled) {
        outlineGameObject.SetActive(isEnabled);
    }

    private void PlayerEnters()
    {
        _isPlayerInRange = true;
        ToggleOutline(true);
    }

    private void PlayerExits()
    {
        _isPlayerInRange = false;
        ToggleOutline(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerEnters();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerExits();
        }
    }
}

public class InteractionInput
{
    public bool IsPlayerInteracting { get { return Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space); } }
}
