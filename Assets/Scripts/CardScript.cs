using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardScript : MonoBehaviour, IPointerClickHandler
{

    bool CardTrigger;
    GameObject Hand;
    int Mynun;//何番目に選ばれているか
    float Z;

    // Use this for initialization
    void Start () {
        CardTrigger = false;
        Hand= GameObject.Find("Hand");
        Z=this.transform.position.z;
    }
	


	// Update is called once per frame
	void Update () {
        if (CardTrigger)
        {
            this.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z);
        }
        else {
            this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        }
	}

    public void OnPointerClick(PointerEventData data)
    {
        if (!CardTrigger)
        {
            CardTrigger = true;
            Hand.GetComponent<HandScript>().SelectOrder(Mynun);
            Debug.Log(Mynun);
            Debug.Log("でしでし　怒った？");
        }
        else {
            CardTrigger = false;
            Hand.GetComponent<HandScript>().SelectOrderKill(Mynun);
        }
    }
    public void OnMouseExit()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Z);
    }
    void OnMouseEnter()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -5);
    }
    public bool getTrigger() {
        return CardTrigger;
    }
    public void setnun(int num) {
        Mynun = num;
    }
}
