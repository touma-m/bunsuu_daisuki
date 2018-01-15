using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoginManager : MonoBehaviour {


	[SerializeField]
	Text joinedMembersText;
	Room room;

	void Start(){
		room = PhotonNetwork.room;
	}
		

	void Update(){
		UpdateMemberList();
	}

	// <summary>
	// リモートプレイヤーが入室した際にコールされる
	// </summary>
	public void OnPhotonPlayerConnected(PhotonPlayer player)
	{
		Debug.Log(player.name + " is joined.");
	}

	// <summary>
	// リモートプレイヤーが退室した際にコールされる
	// </summary>
	public void OnPhotonPlayerDisconnected(PhotonPlayer player)
	{
		Debug.Log(player.name + " is left.");
	}

	public void UpdateMemberList()
	{
		joinedMembersText.text = "";
		
		foreach (var p in PhotonNetwork.playerList)
		{
			joinedMembersText.text += p.name + "\n";
		}
	}
			
}
