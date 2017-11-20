using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class TagDelete : MonoBehaviour
{

    /*===============================================================*/
    /**
    * @brief 最初に一度だけ実行されるメソッド
    */
    void Start()
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
                if(GameObject.FindWithTag("Adjust")){
                    // GameObjectの名前を表示.
                    Debug.Log(obj.name);
                }
            }

        }
    }
    /*===============================================================*/
}
/*===============================================================*/
