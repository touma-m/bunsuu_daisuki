using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	public void GameStart1() {
		SceneManager.LoadScene("１人モード");
	}

	public void GameStart2() {
		SceneManager.LoadScene("ネット対戦");
	}
}