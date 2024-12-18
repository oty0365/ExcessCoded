using System;
using System.Collections;
using System.Collections.Generic;
using system;
using UnityEngine;

public enum BeHaves
{
    Idle,
    ShakeHand,
    Explaining,
    
}
public class CardMasterAlfred : MonoBehaviour
{
    private Animator _ani;
    public BeHaves beHaves;
    public Conversation conversation;
    public GameObject exampleDeck;
    public Animator exDeckAni;
    private void Start()
    {
        beHaves = BeHaves.Idle;
        _ani = GetComponent<Animator>();
        exampleDeck.SetActive(false);
        StartCoroutine(StartFlow());
    }

    private void Update()
    {
            switch (beHaves)
            {
                case BeHaves.Idle:
                    break;

                case BeHaves.ShakeHand when RayCaster.instance.tag=="cardmasterhand":
                    ReturnHand();
                    break;

            }
        }

    public void ShakeHand()
    {
        beHaves = BeHaves.ShakeHand;
        Conversation.pause = true;
        _ani.SetInteger("behave",1);

    }

    public void ReturnHand()
    {
        _ani.SetInteger("behave", 2);
    }

    public void AfterHandReturned()
    {
        _ani.SetInteger("behave",0);
        beHaves = BeHaves.Idle;
        Conversation.pause = false;
        conversation.Talk();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator StartFlow()
    {
        yield return new WaitForSeconds(2f);
        conversation.Talk();
    }

    public void GameTutor1()
    {
        Conversation.pause = true;
        StartCoroutine(GameTutor1Flow());
    }
    private IEnumerator GameTutor1Flow()
    {
        yield return new WaitForSeconds(1);
        CameraManager.instance.CamChange(1);
        exampleDeck.SetActive(true);
        yield return new WaitForSeconds(1);
        Conversation.pause = false;
        conversation.Talk();
    }

    public void GameTutor2()
    {
        Conversation.pause = true;
        StartCoroutine(GameTutor2Flow());
        
    }
    private IEnumerator GameTutor2Flow()
    {
        yield return new WaitForSeconds(0.5f);
        exDeckAni.SetBool("go",true);
        yield return new WaitForSeconds(2.3f);
        exampleDeck.SetActive(false);
        Conversation.pause = false;
    }
}
