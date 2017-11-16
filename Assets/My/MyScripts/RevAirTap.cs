using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RevAirTap : MonoBehaviour, IInputClickHandler
{

    //Cube Prefab を扱う変数
    public GameObject ball;
    public GameObject domino;
    public GameObject spring;

    public Boolean setball = false;


    //AirTapされたときに呼び出される関数
    public void OnInputClicked(InputClickedEventData eventData)
    {
        //throw new NotImplementedException();
        if (setball = true) {
            GameObject cube = GameObject.Instantiate(ball);//Cube Prefab の情報を用いて実体
            cube.transform.position = Camera.main.transform.TransformPoint(0, 0, 1.2f);  //自分からみて前方1.2mの位置を空間内の位置に変換
        }
    }

    // Start関数は初期化のために一度だけ実行される
    void Start()
    {
        //AirTap の通知が gameObject に渡るように設定
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }
    // Update は毎フレーム毎実行される
    void Update()
    {
    }
}