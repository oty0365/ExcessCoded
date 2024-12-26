using System.Collections;
using System.Collections.Generic;
using Games.Cards;
using UnityEngine;
using UnityEngine.XR;

public class CardUse : MonoBehaviour
{
    public static CardUse instance;
    public Card selectedCard;
    public Transform Objective;
    public bool isPlacing;
    private void Awake()
    {
        instance = this;
        isPlacing = false;
    }
    public void UseCard() 
    {
        isPlacing = true;
        RayCaster.instance.useModel.SetActive(false);
        selectedCard.gameObject.SetActive(false);
        

    }
    public void TrashCard()
    {
        PlayerStatus.instance.memory += selectedCard.coast;
        Destroy(selectedCard.gameObject);
        PlayerStatus.instance.StatusUpdate();
    }
    public void Update()
    {
        if (isPlacing)
        {
            if (selectedCard.cardType == CardType.HardWare)
            {
                Debug.Log("2");
                if (RayCaster.instance.tag == "cardputslot"&&RayCaster.instance.hit.collider.gameObject.GetComponent<CardPutSlot>().isUsing==false)
                {
                    Debug.Log("3");
                    selectedCard.gameObject.SetActive(true);
                    isPlacing = false;
                    Objective = RayCaster.instance.hit.transform;
                    RayCaster.instance.hit.collider.gameObject.GetComponent<CardPutSlot>().isUsing = true;
                    selectedCard.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
                    PlayerStatusAct1.instance.memory -= selectedCard.coast;
                    PlayerStatus.instance.StatusUpdate();
                    StartCoroutine(PlaceFlow());

                }
            }
            else if(selectedCard.cardType == CardType.SoftWare)
            {

            }
            
        }

    }
    private IEnumerator PlaceFlow()
    {
        while (Vector3.Distance(selectedCard.gameObject.transform.position, Objective.position) > 0.01f)
        {
            selectedCard.gameObject.transform.position =
                Vector3.MoveTowards(selectedCard.gameObject.transform.position, Objective.position, Time.deltaTime * 5f);
            yield return null;
        }
        selectedCard.gameObject.transform.parent = Objective;
        yield return new WaitForSeconds(0.2f);
        CameraManager.instance.CamChange(0);
        yield return new WaitForSeconds(0.8f);
        CameraManager.instance.CamChange(1);
    }
}
