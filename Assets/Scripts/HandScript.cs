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
    GameObject Deck;

    // Use this for initialization
    void Start () {
        HandParent = GameObject.Find("Hand");
        Trash = GameObject.Find("Trash");
        Deck = GameObject.Find("Deck");
    }
	// Update is called once per frame
	void Update () {
	    	
	}
    public void Draw(List<int> DrawCard) {//ドローするやつ
        foreach (int i in DrawCard) Hand.Add(i); 
    }
    public void Sort() {//手札ソート　今使うとおかしなことに
        Hand.Sort();
    }
    public void CardSet() {//カードオブジェクトをセット
        int j=0;
        foreach (int i in Hand)
        {
            
            //Card = GameObject.Find(Hand[i].ToString());
            Card = Resources.Load(i.ToString()) as GameObject;
            Debug.Log(Hand[j]);
            HandCardObject.Add(Instantiate(Card, new Vector3(j * 30.0f, 0, 0), Quaternion.identity));
            Debug.Log(Hand[j]);
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
        
        foreach (int i in SelectCard) {
            //HandCardObject[i].GetComponent<CardScript>().getTrigger();
            Debug.Log("sasa"+Hand[i]);
            Trash.GetComponent<TrashScript>().TrashAdd(Hand[i]);
        }
        Trash.GetComponent<TrashScript>().testTrash();
    }
    public void HandRemove(int[] RemoveCard) {//出したカードを配列かな削除する
        int j= 0;
        foreach (int i in SelectCard)
        {
            Hand.RemoveAt(SelectCard[j]);
            j += 1;
        }
     }
    public void SelectOrder(int Selectnum) {//選んだ順番
        SelectCard.Add(Selectnum);
    }
    public void A()//Handの子をすべて消す
    { }
    public void test() {//  実装時は必ず消す
        Debug.Log("にゃーん");
        //int[] testCards= { 4, 9, 23, 4, 7, 21, 30 };
        List<int> testCards = Deck.GetComponent<DeckScript>().deck_draw();
        Draw(testCards);
        CardSet();

    }
    
    





}
