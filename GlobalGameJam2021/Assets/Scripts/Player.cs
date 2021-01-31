using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SimpleSingleton<Player>
{
    public PlayerInventory inventory = new PlayerInventory();
    public DialogSpot dialogSpot;

    private int _currentStoryStep = 1;
    private bool storyComplete = false;
    private bool storyReady = false;

    public bool CanMove { get { return !storyComplete && storyReady; } }

    public override void Awake()
    {
        base.Awake();
        dialogSpot = GetComponentInChildren<DialogSpot>();
    }

    public void InitializeGame()
    {
        storyReady = false;
        storyComplete = false;
        inventory.ClearItem();
        _currentStoryStep = 1;
        StartCoroutine(StoryStart());
    }

    public bool CheckIfCanGuessYet(int guessId)
    {
        if(_currentStoryStep == guessId)
        {            
            return true;
        }
        return false;
    }

    public void ProgressStory()
    {
        _currentStoryStep++;
        if(_currentStoryStep > 3)
        {
            storyComplete = true;
            StartCoroutine(StoryEnd());
        }
    }
    private IEnumerator StoryStart()
    {
        dialogSpot.StartMessage("My head hurts...What happened to me?!?!");
        yield return new WaitForSeconds(4f);
        dialogSpot.StartMessage("*** WASD to move. Press spacebar to interact with objects. ***");
        yield return new WaitForSeconds(4f);
        dialogSpot.StartMessage("*** Place clues in pin board to solve your murder. ***");
        yield return new WaitForSeconds(4f);
        dialogSpot.StartMessage("*** Good luck!!! ***");
        yield return new WaitForSeconds(4f);
        storyReady = true;
        UIManager.Instance.ToggleCanvas(true);
    }
    private IEnumerator StoryEnd()
    {
        UIManager.Instance.ToggleCanvas(false);
        yield return new WaitForSeconds(4f);
        dialogSpot.StartMessage("Brother...I hope it was worth it.");
        yield return new WaitForSeconds(4f);
        dialogSpot.StartMessage("Time to possess that detective!");
        yield return new WaitForSeconds(4f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}

public class PlayerInventory
{
    private Item _activeItem = null;

    public void ChangeItem(Item newItem)
    {
        _activeItem = newItem;
        UIManager.Instance.LoadImage(newItem.itemSprite, newItem.color);        
    }

    public void ClearItem()
    {
        _activeItem = null;
        UIManager.Instance.ClearImage();
    }

    public Item GetItem()
    {
        return _activeItem;
    }
}
