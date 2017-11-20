using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
/*===============================================================*/
/**
* ActiveでないGameObjectも取得するサンプル
* 2014年12月31日 Buravo
*/
public class GameManager : MonoBehaviour
{

    BoxCollider boxCollider;
    /*===============================================================*/
    /**
    * @brief 最初に一度だけ実行されるメソッド
    */
    public void BoxDerete()
    {
        // Typeで指定した型の全てのオブジェクトを配列で取得し,その要素数分繰り返す.
        foreach (GameObject obj in UnityEngine.Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            // アセットからパスを取得.シーン上に存在するオブジェクトの場合,シーンファイル（.unity）のパスを取得.
            string path = AssetDatabase.GetAssetOrScenePath(obj);
            // シーン上に存在するオブジェクトかどうか文字列で判定.
            bool isScene = path.Contains(".unity");
            // シーン上に存在するオブジェクトならば処理.
            if (isScene)
            {
                // GameObjectの名前を表示.
                Debug.Log(obj.name);
                obj.SetActive(false);
                
            }
        }
    }

    void start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }


    void Update()
    {

        // 左クリックで実行
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Typeで指定した型の全てのオブジェクトを配列で取得し,その要素数分繰り返す.
            foreach (GameObject obj in UnityEngine.Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                // アセットからパスを取得.シーン上に存在するオブジェクトの場合,シーンファイル（.unity）のパスを取得.
                string path = AssetDatabase.GetAssetOrScenePath(obj);
                // シーン上に存在するオブジェクトかどうか文字列で判定.
                bool isScene = path.Contains(".unity");
                // シーン上に存在するオブジェクトならば処理.
                if (isScene)
                {
                    if (GameObject.FindWithTag("Adjust"))
                    {
                        // GameObjectの名前を表示.
                        Debug.Log(obj.name);
                    }
                }

            }


            // GameObject型の配列cubesに、"box"タグのついたオブジェクトをすべて格納
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Adjust");

           /*foreach (Transform n in cubes.transform)
            {
                GameObject.Destroy(n.gameObject);
            }

            // GameObject型の変数cubeに、cubesの中身を順番に取り出す。
            // foreachは配列の要素の数だけループします。
            /* foreach (GameObject obj in cubes)
             {
                 // 消す！
                 Destroy(obj);
             }*/
        }
    }


    /*===============================================================*/
}
/*===============================================================*/
