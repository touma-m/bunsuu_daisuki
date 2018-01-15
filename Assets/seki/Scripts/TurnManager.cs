using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

	public static List<bool> turnManager = new List<bool> ();	//ターンプレイヤーの管理
	public static List<string> playerlist = new List<string>(); //プレイヤー名のリスト

	PhotonView view;


	// Use this for initialization
	void Awake () {
		view = GetComponent<PhotonView> ();
		//マスタークライアントの情報
		if (PhotonNetwork.isMasterClient) {
			playerlist.Add (PhotonNetwork.playerName);
			turnManager.Add (false);
		}
	}


	//誰かがルームに入室したとき
	void OnPhotonPlayerConnected(PhotonPlayer newPlayer){
		//プレイヤーリストに入室したプレイヤーを追加
		playerlist.Add (newPlayer.name.ToString ());
		turnManager.Add (false);
		//ルーム内の人数が部屋の上限に達したとき
		if (PhotonNetwork.room.maxPlayers == playerlist.Count) {
			roomclose ();
		}
	}

	//誰かがルームから退室したとき
	void OnPhotonPlayerDisconnected( PhotonPlayer otherPlayer ){
		for (int i = 0; i < playerlist.Count; i++) {
			if (playerlist [i] == otherPlayer.name.ToString()) {
				playerlist.RemoveAt(i);
				//もしターンプレイヤーが抜けたら
				if(turnManager[i] == true){
					//次の人にターンを回す
					turnManager [i + 1] = true;
				}
				turnManager.RemoveAt (i);
			}
		}
		GameObject.Find ("PlayerInfoPref").GetComponent<PlayerInfoPref> ().getMyTurnRequest ();
	}

	//部屋を閉じる
	void roomclose(){
		PhotonNetwork.room.open = false;	//部屋を閉じる
		PhotonNetwork.room.visible = false;		//部屋を見えなくする
	}


	//ゲームスタート関数
	public void gamestart(){
		roomclose ();
		//先行を決める
		int rand = UnityEngine.Random.Range (0, turnManager.Count);
		turnManager [rand] = true;
		Debug.Log ("rand " + rand + " : tMcount " + turnManager.Count);
	}

	//PlayerInfoPrefに返す用メソッド--------------------------------------------------------------
	public bool[] getturnManager(){
		return turnManager.ToArray ();
	}

	public string[] getplayerlist(){
		return playerlist.ToArray ();
	}
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

	//ターン情報をセット--------------------------------------------------------------------------
	public void setturnManager(bool[] newturnmanager){
		if(newturnmanager.Length != turnManager.Count){
			Debug.LogError ("list型と配列の要素数が一致しません");
			return;
		}
		for (int i = 0; i < turnManager.Count; i++) {
			turnManager [i] = newturnmanager [i];
		}
	}
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
}
