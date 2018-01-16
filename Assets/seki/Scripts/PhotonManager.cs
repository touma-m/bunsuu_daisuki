using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhotonManager : Photon.MonoBehaviour {

	string userName;
	public string SceneName = "TestGameMain";

	public void ConnectPhoton(){
		if (GameObject.Find ("NameInputField").GetComponent<InputField> ().text != "") {
			userName = GameObject.Find ("NameInputField").GetComponent<InputField> ().text;
			PhotonNetwork.ConnectUsingSettings ("v1.0");
			PhotonNetwork.playerName = userName;
		}
	}

	void OnJoinedLobby ()
	{
		Debug.Log ("PhotonManager OnJoinedLobby");
		//ボタンを押せるようにする
		GameObject.Find("CreateRoomB").GetComponent<Button>().interactable=true;
		//GameObject.Find("JoinRoomB").GetComponent<Button>().interactable=true;
		//GameObject.Find ("JoinInputField").GetComponent<InputField> ().interactable = true;;
		GameObject.Find ("IdInputField").GetComponent<InputField> ().interactable = true;
		//ボタンを押せないようにする
		GameObject.Find ("NameInputField").GetComponent<InputField> ().interactable = false;
	}


	//ルーム一覧が取れると
	void OnReceivedRoomListUpdate(){
		//ルーム一覧をとる
		RoomInfo[] rooms = PhotonNetwork.GetRoomList();
		if (rooms.Length == 0) {
			Debug.Log ("ルームが一つもありません");
		} else {
			//ルームが1件以上あるときループでRoomInfo情報をログ出力
			for (int i = 0; i < rooms.Length; i++) {
				Debug.Log ("RoomName : " + rooms [i].name);
				Debug.Log ("userName : " + rooms [i].customProperties ["userName"]);
				//Debug.Log ("userId : " + rooms [i].customProperties ["userId"]);
				GameObject.Find ("StatusText").GetComponent<Text> ().text += rooms [i].name + "\n";
			}
		}
	}
		
	//ルーム作成
	public void CreateRoom(){
		string RoomName = GameObject.Find ("IdInputField").GetComponent<InputField> ().text;
		//未入力の場合ルーム名を[default]にする
		if (RoomName == "") {
			RoomName = "default";
		}

		//Debug.Log (userName + " : " + userId);
		//PhotonNetwork.autoCleanUpPlayerObjects = false;
		//カスタムプロパティ
		ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable();
		customProp.Add ("userName", userName); //ユーザ名
		//customProp.Add ("userId", userId); //ユーザID
		PhotonNetwork.SetPlayerCustomProperties(customProp);

		RoomOptions roomOptions = new RoomOptions ();
		roomOptions.CustomRoomProperties = customProp;
		//ロビーで見えるルーム情報としてカスタムプロパティのuserName,userIdを使いますよという宣言
		roomOptions.CustomRoomPropertiesForLobby = new string[]{"userName","userId"};
		roomOptions.maxPlayers = 10; //部屋の最大人数
		roomOptions.isOpen = true; //入室許可する
		roomOptions.isVisible = true; //ロビーから見えるようにする
		//userIdが名前のルームになければ作って入室、あれば普通に入室する
		PhotonNetwork.JoinOrCreateRoom(RoomName,roomOptions,null);
		//PhotonNetwork.CreateRoom(RoomName,roomOptions,null);
	}


	//これ使ってない
	public void JoinRoom(){
		string roomname = GameObject.Find ("JoinInputField").GetComponent<InputField> ().text;
		PhotonNetwork.JoinRoom (roomname);
	}


	//ルーム入室したときに呼ばれるコールバックメソッド
	void OnJoinedRoom(){
		Debug.Log ("PhotonManager OnJoinedRoom");
		GameObject.Find ("StatusText").GetComponent<Text> ().text = "OnJoinedRoom";
		SceneManager.LoadScene (SceneName);

	}

	//ルーム入室に失敗したときに呼ばれるコールバックメソっど
	public void OnPhotonJoinRoomFailed(object[] cause)
	{
		GameObject.Find ("StatusText").GetComponent<Text> ().text = "もう一度入り直してください";
		Debug.Log("OnPhotonJoinRoomFailed got called. This can happen if the room is not existing or full or closed.");
	}
}
