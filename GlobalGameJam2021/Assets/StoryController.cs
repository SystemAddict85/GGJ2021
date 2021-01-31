using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.transform.position = transform.position;
        Player.Instance.InitializeGame();
    }

}
