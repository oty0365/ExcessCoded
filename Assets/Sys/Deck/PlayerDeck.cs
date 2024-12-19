using System;
using System.Collections;
using System.Collections.Generic;
using Games.Cards;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public static PlayerDeck instance;
    public List<Card> Cards;
    public Vector3 currentHeight;
    public bool canDraw;
    public GameObject hand;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        canDraw = true;
        UpdateDeck();
    }

    private void OnEnable()
    {
        UpdateDeck();
    }

    public void UpdateDeck()
    {
        currentHeight = gameObject.transform.position;
        for (var i = 0; i < Cards.Count; i++)
        {
            var card =Instantiate(Cards[i].gameObject, currentHeight, Quaternion.Euler(-90f, 180f, 0));
            card.transform.parent = gameObject.transform;
            currentHeight = new Vector3(currentHeight.x, currentHeight.y + 0.02f,
                currentHeight.z);

        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (RayCaster.instance.tag == "deck"&&canDraw)
            {
                Draw();
                canDraw = false;
            }
        }
    }

    public void Draw()
    {
        var t = Cards[^1].gameObject;
        Cards.Remove(Cards[^1]);
        StartCoroutine(DrawFlow(t));
    }

    private IEnumerator DrawFlow(GameObject t)
    {
        while (Vector3.Distance(t.transform.position, hand.transform.position) > 0.1f)
        {
            t.transform.position =
                Vector3.MoveTowards(t.transform.position, hand.transform.position, Time.deltaTime * 3f);
            yield return null;
        }
        
    }
}
