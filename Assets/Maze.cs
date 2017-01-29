using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maze : MonoBehaviour {

    public Camera camera; 
    public bool playerFrag = false;
    public float moveSpeed = 2;
    Rigidbody rigid;
    public Text gameOver, gameClear;

	// Use this for initialization
	void Start () {
        playerFrag = true;
        rigid = GetComponent<Rigidbody>();//毎回コンポーネントを参照するのは冗長なのでここでぶち込んでおく.
        gameOver.enabled = false;
        gameClear.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerFrag) {
            cameraFollow();
            string key;
            key = checkKey();
            move(key);
        }
	}

    void cameraFollow() {
        camera.transform.position = new Vector3(transform.position.x,camera.transform.position.y,transform.position.z);
    }

    string checkKey() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            return "up";
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            return "down";
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            return "left";
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            return "right";
        }
        return null;
    }

    void move(string key) {
        if (key == "up") {
            rigid.AddForce(0,0,moveSpeed);
        }
        else if (key == "down") {
            rigid.AddForce(0,0,-moveSpeed);
        }
        if (key == "left") {
            rigid.AddForce(-moveSpeed,0,0);
        }
        else if (key == "right") {
            rigid.AddForce(moveSpeed,0,0);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Wall") {
            Debug.Log("Game Over...");
            gameOver.enabled = true;
            playerFrag = false;
        } else if (collision.transform.name == "Goal") {
            Debug.Log("Game Clear!!!");
            gameClear.enabled = true;
            playerFrag = true;
        }
    }
}
