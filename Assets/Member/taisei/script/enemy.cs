using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //敵プレハブ
    [SerializeField] private GameObject enemyPrefab;

    /// <summary>
    /// 時間系
    /// </summary>
    //  最小値
    [SerializeField] private float minTime = 2f;
    //  最大値
    [SerializeField] private float maxTime = 5f;

    /// <summary>
    /// ランダム生成（位置）
    /// </summary>
    //  最小値
    [SerializeField] private Vector3 MinPosition;
    //  最大値
    [SerializeField] private Vector3 MaxPosition;

    //敵生成時間間隔
    private float interval;
    //経過時間
    private float nowTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        interval = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        //時間計測
        nowTime += Time.deltaTime;

        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (nowTime > interval)
        {
            //enemyをインスタンス化する(生成する)
            GameObject enemy = Instantiate(enemyPrefab);
            //生成した敵の位置をランダムに設定する
            enemy.transform.position = GetRandomPosition();
            //経過時間を初期化して再度時間計測を始める
            nowTime = 0f;
            //次に発生する時間間隔を決定する
            interval = GetRandomTime();
        }
    }

    //ランダムな時間を生成する関数
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    //ランダムな位置を生成する関数
    private Vector3 GetRandomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = Random.Range(MinPosition.x, MaxPosition.x);
        float y = Random.Range(MinPosition.y, MaxPosition.y);
        float z = Random.Range(MinPosition.z, MaxPosition.z);


        //Vector3型のPositionを返す
        return new Vector3(x, y, z);
    }
}
