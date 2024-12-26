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
    public static CardMasterAlfred instance;
    private Animator _ani;
    public BeHaves beHaves;
    public Conversation conversation;
    public GameObject exampleDeck;
    public Animator exDeckAni;
    public GameObject playerDeck;
    public GameObject playerStatus;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        beHaves = BeHaves.Idle;
        _ani = GetComponent<Animator>();
        exampleDeck.SetActive(false);
        playerDeck.SetActive(false);
        playerStatus.SetActive(false);
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
        Conversation.pause = false;
    }

    public void DrawTutor()
    {
        CameraManager.instance.CamChange(2);
        playerDeck.SetActive(true);
        StartCoroutine(DrawTutorFlow());
    }

    private IEnumerator DrawTutorFlow()
    {
        yield return new WaitForSeconds(0.7f);
        Conversation.pause = false;
        conversation.Talk();
    }

    public void DrawPhase()
    {
        Conversation.pause = true;
    }
    public void GameTutor3()
    {
        StartCoroutine(GameTutor3Flow());
    }
    private IEnumerator GameTutor3Flow()
    {
        yield return new WaitForSeconds(1.6f);
        Conversation.pause = false;
        conversation.Talk();
    }
    public void GameTutor4()
    {
        playerStatus.SetActive(true);
    }
    public void GameTutor5()
    {
        CameraManager.instance.CamChange(3);
        playerStatus.SetActive(false);
    }
    public void GameTutor6()
    {
        CameraManager.instance.CamChange(0);
        playerStatus.SetActive(true);
    }
    public void GameTutor7()
    {

    }
}
