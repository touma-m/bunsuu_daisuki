using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour {

    List<int> Hand = new List<int>();
    List<GameObject> HandCardObject = new List<GameObject>();
    List<int> SelectCard = new List<int>();//選んだ順番と選んだカードの場所
    GameObject Card;
    GameObject HandParent;
    GameObject Trash;
    GameObject Field;
    // Use this for initialization
    void Start () {
        HandParent = GameObject.Find("Hand");
        Trash = GameObject.Find("Trash");
        Field = GameObject.Find("Field");
    }
	// Update is called once per frame
	void Update () {
	    	
	}
    public void Draw(List<int> DrawCard) {//ドローするやつ

        foreach (int i in DrawCard) Hand.Add(i);

        CardSet();
    }
    public void Sort() {//手札ソート　今使うとおかしなことに
        Hand.Sort();
    }
    public void CardSet() {//カードオブジェクトをセット
        int j=0;
        AllKill();
        foreach (int i in Hand)
        {
            Card = Resources.Load(i.ToString()) as GameObject;
            HandCardObject.Add(Instantiate(Card, new Vector3(j * 30.0f, 0, 0), Quaternion.identity));
            //Debug.Log(Hand[j]);
            HandCardObject[j].transform.parent = HandParent.transform;
            HandCardObject[j].AddComponent<CardScript>();
            HandCardObject[j].GetComponent<CardScript>().setnun(j);
            //HandCardObject[i].AddComponent<>();
            
            j += 1;
        }   
    }
    public void TriggerSet() {//選択用のトリガー いらない？
        //HandTrigger.Clear();
        foreach (int i in Hand) ; //HandTrigger.Add();
    }
    public void OutPut() {
        int FieldInt;
        if (SelectCard.Count != 0)
        {
            FieldInt=Field.GetComponent<FieldScript>().GetField();

            foreach (int i in SelectCard)
            {
                //HandCardObject[i].GetComponent<CardScript>().getTrigger();
                //Debug.Log("sasa" + Hand[i]);
                Trash.GetComponent<TrashScript>().TrashAdd(Hand[i]);
            }
            Trash.GetComponent<TrashScript>().testTrash();
            HandRemove();//配列から消す

            CardSet();//オブジェクトを再配置
        }
        else {
            //パスの処理
        }
    }

    public void HandRemove() {//出したカードを配列から削除する
        int j= 0;
        for (j = SelectCard.Count-1; j >= 0; j -= 1)Hand.RemoveAt(SelectCard[j]);
    }
    public void SelectOrder(int Selectnum) {//選んだ順番
        SelectCard.Add(Selectnum);
    }
    public void AllKill()//Handの子をすべて消す
    {
        foreach (Transform n in this.transform)
        {
            Destroy(n.gameObject);
        }
        HandCardObject.Clear();
        SelectCard.Clear();
    }
    public void SelectOrderKill(int SelectCardCancel) {
        int j = 0, KillInt=0;
        foreach (int i in SelectCard) {
            if (SelectCardCancel == i)
            {
                KillInt = j;
            }
            j += 1;
        }
        SelectCard.RemoveAt(KillInt);

    }

}
