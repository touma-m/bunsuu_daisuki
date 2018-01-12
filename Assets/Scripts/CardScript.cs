using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardScript : MonoBehaviour, IPointerClickHandler
{

    bool CardTrigger;
    GameObject Hand;
    int Mynun;//何番目に選ばれているか


    // Use this for initialization
    void Start () {
        CardTrigger = false;
        Hand= GameObject.Find("Hand");
    }
	


	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData data)
    {
        //CardTrigger = true;
        Hand.GetComponent<HandScript>().SelectOrder(Mynun);
        Debug.Log(Mynun);
        Debug.Log("でしでし　怒った？");
    }
    public bool getTrigger() {
        return CardTrigger;
    }
    public void setnun(int num) {
        Mynun = num;
    }
}
