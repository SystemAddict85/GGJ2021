using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomReveal : MonoBehaviour
{
    private SpriteMask _spriteMask;

    private void Awake()
    {
        _spriteMask = GetComponentInChildren<SpriteMask>();

        ToggleMask(false);
    }

    private void ToggleMask(bool enabled)
    {
        _spriteMask.enabled = enabled;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ToggleMask(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ToggleMask(false);
        }
    }
}
