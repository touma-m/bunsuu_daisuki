
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    //可変長配列deck1  ref　が入ると怒られるので保留
    //public List<int> deck1 = new List<int>();

    //デッキ用配列
    public List<int> deck1 = new List<int>();
    public List<int> deck2 = new List<int>();
    public List<int> deck3 = new List<int>();
    //ドロー回数。呼び出す添え字の保管用。
    GameObject Hand;
    int draw_count;

    // Use this for initialization
    void Start()
    {
        Hand = GameObject.Find("Hand");
        deck_setting();
        //Debug.Log(deck1.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //デッキの初期化
    void deck_setting()
    {

        //デッキ内の初期化処理
        for (int i = 0; i < 76; i++)
        {
            //deck1.Add(i);
            deck1[i] = i;
        }
        int num = 0;
        int count = 0;
        for (int i = 0; i < 76; i++)
        {
            deck2[i] = num;
            count++;
            if (num % 10 == 0 || count == 2)
            {
                num++;
                count = 0;
            }
   		 }

        //ランダムな入れ替え
        var rnd = new Random();
        for (int pos = 0; pos < 76; pos++)
        {
            int next_pos = Random.Range(pos, 76);
            int work = deck1[pos];
            deck1[pos] = deck1[next_pos];
            deck1[next_pos] = work;
            //Debug.Log("にゃーん");
            Debug.Log(deck2[deck1[pos]]);
            deck3[pos] = deck2[deck1[pos]];
            //Swap(ref deck1[pos], ref deck1[next_pos]);
            //Debug.Log(deck1[pos]);
        }
    }
    //ドロー処理
	//---------------------------------------------------------------------masterが実行　targets.all myturn == true の場合
	public void deck_draw()
    {
        draw_count++;
        Debug.Log(deck1[draw_count-1]);
        //return deck3;
        Hand.GetComponent<HandScript>().Draw(deck3);
	}//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    /*
    //初期化で用いるSwap処理
    static void Swap(ref int m, ref int n) {
        int work = m;
        m = n;
        n = work;
    }
    */


	//HandScript用
	public List<int> getDeck(){
		return deck3;
	}
	//引かれた分をデッキから削除する
	public void removeDeck(List<int> newDeckinfo){
		foreach (int index in newDeckinfo) {
			deck3.Remove (index);
		}
	}

}