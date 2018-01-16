using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScript : MonoBehaviour {

    
    GameObject Card;
    int FieldCardInt;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	    	
	}

    public void FieldUpDate(int CardInt) {
        FieldCardInt = CardInt;
        FixedSet();
    }
    public void FixedSet()//カードをセット
    {
        foreach (Transform n in this.transform)
        {
            Destroy(n.gameObject);
        }

        Card = Resources.Load(FieldCardInt.ToString()) as GameObject;
        Instantiate(Card, new Vector3(0, 60, 0), Quaternion.identity).transform.parent = this.transform;
    }
    public int GetField() {
        return FieldCardInt;
    }
    


}
