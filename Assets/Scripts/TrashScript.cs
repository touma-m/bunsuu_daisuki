using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour {
    GameObject Field;
    List<int> Trash = new List<int>();

    // Use this for initialization
    void Start () {
        Field = GameObject.Find("Field");
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void TrashAdd(int TrashCard) {
        int LastCard=0;
        Trash.Add(TrashCard);
        foreach (int i in Trash) LastCard = i;
        
        Field.GetComponent<FieldScript>().FieldUpDate(LastCard);//フィールド更新

    }
    public void TrashReset() {
        Trash.Clear();
    }
    public void testTrash() {
        int j = 0;
        foreach (int i in Trash)
        {

            Debug.Log("墓地"+Trash[j]);
            j += 1;
        }
        }
}
