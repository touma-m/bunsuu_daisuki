using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class network_test1 : MonoBehaviour {


	void Start() {
		// Photonに接続する(引数でゲームのバージョンを指定できる)
		PhotonNetwork.ConnectUsingSettings(null);
	}

	// ロビーに入ると呼ばれる
	void OnJoinedLobby() {
		Debug.Log("ロビーに入りました。");


		// ルームに入室する
		// 適当なルームにランダムに入室する
		//PhotonNetwork.JoinRandomRoom();
		// ルーム名を指定して入室する
		PhotonNetwork.JoinRoom("roomName");
	}

	// ルームに入室すると呼ばれる
	void OnJoinedRoom() {
		Debug.Log("ルームへ入室しました。");

		Debug.Log(PhotonNetwork.room.name);             // ルーム名
		Debug.Log(PhotonNetwork.room.playerCount);      // 現在人数
		Debug.Log(PhotonNetwork.room.maxPlayers);       // 最大人数
		Debug.Log(PhotonNetwork.room.open);             // 開放フラグ
		Debug.Log(PhotonNetwork.room.visible);          // 可視フラグ
		Debug.Log(PhotonNetwork.room.customProperties); // カスタムプロパティ
	}

	// ルームの入室に失敗すると呼ばれる
	void OnPhotonRandomJoinFailed() {
		Debug.Log("ルームの入室に失敗しました。");

		// ルームがないと入室に失敗するため、その時は自分で作る
		// 引数でルーム名を指定できる


		/* ルームオプションの設定 */

		// RoomOptionsのインスタンスを生成
		RoomOptions roomOptions = new RoomOptions();

		// ルームに入室できる最大人数。0を代入すると上限なし。
		roomOptions.MaxPlayers = 4;

		// ルームへの入室を許可するか否か
		roomOptions.IsOpen = true;

		// ロビーのルーム一覧にこのルームが表示されるか否か
		roomOptions.IsVisible = true;

		/* ルームの作成 */
		/* ルームオプションを設定する場合、CreateRoomメソッドは引数3つのオーバーロードを使用します。 */



		/* ↓ ここからがカスタムプロパティの設定 ↓ */

		// 名前空間(ExitGames.Client.Photon)内のHashtableクラスのインスタンスを生成して
		ExitGames.Client.Photon.Hashtable roomHash = new ExitGames.Client.Photon.Hashtable();

		// 設定したいカスタムプロパティを、キーと値のセットでAdd
		roomHash.Add("Time", 0);
		roomHash.Add("MapCode", 1);
		roomHash.Add("Mode", "Easy");

		// ルームオプションにハッシュをセット
		roomOptions.CustomRoomProperties = roomHash;

		/* ↑ ここまででカスタムプロパティの設定は終了 ↑ */

		/* ↓ 前回同様ルーム作成時にルームオプションを渡して完了 ↓ */
		PhotonNetwork.CreateRoom("RoomName", roomOptions, null);

		// 第1引数はルーム名、第2引数はルームオプション、第3引数はロビーです。
		//PhotonNetwork.CreateRoom("RoomName", roomOptions, null);
		//PhotonNetwork.CreateRoom("myRoomName");
	}









}
