using System;
using System.Collections;
using System.Collections.Generic;
using Games.Cards;
using UnityEngine;

[System.Serializable]
public class PlayableCard
{
    public Card card;
    public bool isInDeck;
}
public class PlayerDeck : MonoBehaviour
{
    public static PlayerDeck instance;
    public List<PlayableCard> Cards;
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
            if (!Cards[i].isInDeck)
            {
                var card = Instantiate(Cards[i].card.gameObject, currentHeight, Quaternion.Euler(-90f, 180f, 0));
                Cards[i].isInDeck = true;
                card.transform.parent = gameObject.transform;
                currentHeight = new Vector3(currentHeight.x, currentHeight.y + 0.02f,
                    currentHeight.z);

            }
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
        var t = Cards[^1].card.gameObject;
        var origin = gameObject.transform.GetChild(Cards.Count - 1).gameObject;
        Cards.Remove(Cards[^1]);
        StartCoroutine(DrawFlow(origin));
    }

    private IEnumerator DrawFlow(GameObject t)
    {
        while (Vector3.Distance(t.transform.position, hand.transform.position) > 0.01f)
        {
            t.transform.position =
                Vector3.MoveTowards(t.transform.position, hand.transform.position, Time.deltaTime * 5f);
            yield return null;
        }
        t.transform.parent = hand.gameObject.transform;
        t.transform.rotation = Quaternion.Euler(0, 0, 0);
        yield return new WaitForSeconds(0.2f);
        CameraManager.instance.CamChange(0);
    }
}
