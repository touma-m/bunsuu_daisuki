using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class PlayerInfoPref : Photon.MonoBehaviour {

	bool myturn;
	GameObject turnmanager;
	PhotonView view;
	Room room;
	PhotonPlayer player;
	GameObject startbutton;
	Text joinedMembersText;
	Text turnsatus;


	Text handinfo;
	public List<int> hand = new List<int> ();

	Text enemyhandcount;

	bool[] testbool = { true, false, true };
	string testss = "";


	void Start () {
		turnmanager = GameObject.Find("TurnManager");

		startbutton = GameObject.Find ("startbutton");							//
		joinedMembersText = GameObject.Find ("count").GetComponent<Text>();		// UI関係
		turnsatus = GameObject.Find ("myturnstatus").GetComponent<Text>();		//
		handinfo = GameObject.Find("handinfo").GetComponent<Text>();	//test	//
		enemyhandcount = GameObject.Find("enemyhandcount").GetComponent<Text>();//

		view = GetComponent<PhotonView> ();

		if (PhotonNetwork.isMasterClient) {
			testss = " master";
			startbutton.SetActive (true);
		} else {
			startbutton.SetActive (false);
		}

		handinfo.text = "";

		//手札テスト
		for (int i = 0; i < UnityEngine.Random.Range(1,10); i++) {
			hand.Add (UnityEngine.Random.Range(0,76));
		}

		foreach(int n in hand){
			handinfo.text += n + ", ";
		}
	}


	void Update () {
		room = PhotonNetwork.room;
		int playercount = room.playerCount;
		joinedMembersText.text = "online : " + playercount;
		turnsatus.text = myturn.ToString();

		//自分のターンの時
		if (myturn == true) {
			GameObject.Find ("TurnEndButton").GetComponent<Button> ().interactable = true;
			//カードを出す処理（出せる処理）
		} else {
			GameObject.Find ("TurnEndButton").GetComponent<Button> ().interactable = false;
		}
	}

	//マスタークライアントのスタートボタン押下時
	void ongamestart(){
		turnmanager.GetComponent<TurnManager> ().gamestart ();
		view.RPC ("getTurnInfoRequest",PhotonTargets.All);
	}


	//ターン情報を取得-----------------------------------------------------------------------------------

	//全クライアントが実行可能
	public void getMyTurnRequest(){
		view.RPC ("gTIRequestListner", PhotonTargets.MasterClient);
	}

	//全クライアント向けにマスターが実行
	[PunRPC]
	public void gTIRequestListner(){
		view.RPC ("getTurnInfoRequest",PhotonTargets.All);
	}

	//全クライアントが実行可能
	[PunRPC]
	public void getTurnInfoRequest(){
		view.RPC ("getTurnInfo",PhotonTargets.MasterClient,PhotonNetwork.playerName);
	}

	//マスターだけが実行できる
	[PunRPC]
	public void getTurnInfo(string playername){
		bool[] turninfo = turnmanager.GetComponent<TurnManager>().getturnManager();
		string[] playerinfo = turnmanager.GetComponent<TurnManager>().getplayerlist();
		int index = 0;
		for (int i = 0; i < turninfo.Length; i++) {
			if (playerinfo [i] == playername) {
				index = i;
			}
		}
		//各クライアントの変数myturnに調べた値を代入
		view.RPC ("setMyturn",PhotonTargets.All,playername,turninfo[index]);
	}


	//getTurninfoのなかで実行
	[PunRPC]
	public void setMyturn(string playername, bool turninfo){
		if (PhotonNetwork.playerName == playername) {
			myturn = turninfo;
			//Debug.Log ("myturn is " + myturn);
		} else {
			//Debug.Log (turninfo + " is not myturn");
		}

	}

	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^




	//ターン遷移--------------------------------------------------------------------------------------
	//マスターだけが実行できる
	[PunRPC]
	public void TurnChange (){
		bool[] turninfo = turnmanager.GetComponent<TurnManager>().getturnManager();
		for (int i = 0; i < turninfo.Length; i++) {
			//今のターンの人を見つけたら
			if (turninfo [i] == true) {
				//その人のターンを終わらせる
				turninfo [i] = false;
				//次が[0]の場合
				if (i + 1 == turninfo.Length) {
					i = -1;
				}
				//次の人のターンを始める
				turninfo [i + 1] = true;

				turnmanager.GetComponent<TurnManager> ().setturnManager (turninfo);
				return;	//余分なループを飛ばす
			}
		}
	}


	//全クライアントが実行可能
	[PunRPC]
	public void TurnChangeRequest(){
		view.RPC ("TurnChange",PhotonTargets.MasterClient);
	}

	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^





	//UI用----------------------------------------------------------------------------------------------------------------------------

	public void onGameStart(){
		ongamestart ();
		startbutton.SetActive (false);
	}


	public void onTurnEnd(){
		view.RPC ("TurnChange",PhotonTargets.MasterClient);
		getMyTurnRequest ();
	}


	public void onGetMyturn(){
		view.RPC ("getTurnInfo",PhotonTargets.MasterClient,PhotonNetwork.playerName);
	}
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


	//RPC確認用---------------------------------------------------------------------------------------
	public void onRPCtest(){
		view.RPC("testRPC",PhotonTargets.MasterClient,PhotonNetwork.playerName,testss,testbool);
	}
		
	[PunRPC]
	public void testRPC(string ss, string sss,bool[] b){
		GameObject.Find ("RPCtest").GetComponent<Text> ().text = ss + sss + " " + b[1] + ","+ b[2];
	}
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
}
