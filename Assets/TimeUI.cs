using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIを扱うおまじない.

public class TimeUI : MonoBehaviour {

    Text text;
    float nowTime;
    public Maze player;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        nowTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        int minute, second;//分と秒.
        string textMin, textSec;
        minute = (int)nowTime / 60;
        second = (int)nowTime % 60;
        if (minute < 10) {
            textMin = "0" + minute.ToString();
        } else {
            textMin = minute.ToString();
        }
        if (second < 10) {
            textSec = "0" + second.ToString();
        } else {
            textSec = second.ToString();
        }
        text.text = "[Time]" + textMin +":"+textSec;//ToStringで数値→文字に変換.(その前にfloatからintへ変換)
        if(player.playerFrag)
            nowTime += Time.deltaTime;
	}
}
