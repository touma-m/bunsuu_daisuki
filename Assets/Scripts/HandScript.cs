using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandScript : Photon.MonoBehaviour {

    List<int> Hand = new List<int>();
    List<GameObject> HandCardObject = new List<GameObject>();
    List<int> SelectCard = new List<int>();//選んだ順番と選んだカードの場所
    GameObject Card;
    GameObject HandParent;
    GameObject Trash;
    GameObject Field;
	int FieldInt;

	int first_draw = 7;
	int one_draw = 1;

	PhotonView view;
    // Use this for initialization
    void Start () {
		view = GetComponent<PhotonView> ();
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
//        int FieldInt;
        int ColorInt;
        int CardNum;
        if (SelectCard.Count != 0)
        {
            FieldInt = Field.GetComponent<FieldScript>().GetField();
            ColorInt = FieldInt / 10;
            CardNum = FieldInt % 10;
            if (ColorInt == Hand[SelectCard[0]] / 10 || CardNum == Hand[SelectCard[0]] % 10)
            {



                foreach (int i in SelectCard)
                {
                    //HandCardObject[i].GetComponent<CardScript>().getTrigger();
                    //Debug.Log("sasa" + Hand[i]);
                    //Trash.GetComponent<TrashScript>().TrashAdd(Hand[i]);	
					view.RPC("trashRefresh",PhotonTargets.All,Hand[i]);		//--------------------------------
				}
                Trash.GetComponent<TrashScript>().testTrash();
                HandRemove();//配列から消す

                CardSet();//オブジェクトを再配置

				GameObject.Find("PlayerInfoPref").GetComponent<PlayerInfoPref>().onTurnEnd();	//----------------ターンエンド処理
            }
            else
            {
                Debug.Log("ルール違反");
            }
        }

        else
        {
            //パスの処理
			GameObject.Find("PlayerInfoPref").GetComponent<PlayerInfoPref>().onTurnEnd();		//------------------ターンエンド処理
        }

		/*
		 * if (SelectCard.Count != 0)
        	{
			..........
				if (ColorInt == Hash ...........
					...............
				}
				else{
					Debug.Log("ルール違反");
					break;
				}
			}
			GameObject.Find("PlayerInfoPref").GetComponent<PlayerInfoPref>().onTurnEnd();
			//の方がスマートな気がする
		*/
        
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
    

	//デッキの同期--------------------------------------------------------------------------------------
	[PunRPC] 	//masterが実行する
	public void DrawforDeck(int draw_num, string playername){	//drow_num = 引く枚数
		DeckScript deckScript = GameObject.Find ("Deck").GetComponent<DeckScript> (); 
		List<int> deck = deckScript.getDeck ();
		List<int> card_num = deck.GetRange (0,draw_num); //ドローするカード
		deckScript.removeDeck(card_num);		//ドローした分をデッキから削除
		int[] card_num_array = card_num.ToArray();						//RPCで渡せるように配列に変換
		view.RPC("setmyhand",PhotonTargets.All,card_num_array,playername);	//各々の手札に引いたカードを代入
	}

	[PunRPC]	//全員が実行する
	public void setmyhand(int[] draw_card,string playername){
		if (playername != PhotonNetwork.playerName) {
			return;		//名前が一致しない場合弾く
		}
		List<int> Draw_card = new List<int>();		//Draw(List<int> x)用に変換
		Draw_card.AddRange(draw_card);				//
		Draw (Draw_card);
	}


	[PunRPC]	//マスターに向かって「手札をdraw_num枚くれ」と言う
	public void DrawforDeckRequest(int draw_num){
		view.RPC ("DrawforDeck", PhotonTargets.MasterClient, draw_num, PhotonNetwork.playerName);
	}
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^



	[PunRPC]		//全員にtrashの更新を伝える
	public void trashRefresh(int forHand){
		Trash.GetComponent<TrashScript>().TrashAdd(forHand);
	}




	//ゲームスタート時 マスターのみ実行
	public void FirstDraw(){
		//プレイヤー全員に「マスターから7枚手札を貰え」と言う
		view.RPC ("DrawforDeckRequest",PhotonTargets.All,first_draw);

		//最初の場のカードを決定---------------------------------------------------------------
		DeckScript deckScript = GameObject.Find ("Deck").GetComponent<DeckScript> ();
		List<int> deck = deckScript.getDeck ();
		int first_field = deck [0];
		view.RPC ("trashRefresh",PhotonTargets.All,first_field);
		//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
	}

	//drawボタン押下時
	//今の所無限に押せるから一回引いた後は押せなくなるようにする必要がある
	public void onDrawbutton (){
		view.RPC ("DrawforDeck",PhotonTargets.MasterClient,one_draw,PhotonNetwork.playerName);
	}


}
