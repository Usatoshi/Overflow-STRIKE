using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal : MonoBehaviour
{
    [SerializeField]
    [Tooltip("生成するGameObject")]
    private GameObject createPrefab;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;

    int count;

     public int spawnCount;
    // 経過時間
    private float nowTime;

    // Update is called once per frame
    void Update()
    {
        var clones = GameObject.FindGameObjectsWithTag("Nomal");
        // 前フレームからの時間を加算していく
        nowTime = nowTime + Time.deltaTime;
        // 約1秒置きにランダムに生成されるようにする。
        if (nowTime > 1.0f)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            // GameObjectを上記で決まったランダムな場所に生成
            Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);
            count++;
            spawnCount++;
            foreach (var clone in clones)
            {
                if (spawnCount > 5)
                {
                    Destroy(clone);
                   // count = 0;
                }

            }
            //if (spawnCount < 1)
            //    return;
            // 経過時間リセット
            nowTime = 0f;
            // Destroy(gameObject);       
        }
    }
}
