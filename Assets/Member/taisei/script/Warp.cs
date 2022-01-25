using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
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
    

    // 経過時間
    private float time;
    
    // Update is called once per frame
    void Update()
    {
        var clones = GameObject.FindGameObjectsWithTag("ball");
        // 前フレームからの時間を加算していく
        time = time + Time.deltaTime;
        // 約1秒置きにランダムに生成されるようにする。
        if (time > 3.0f)
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
            foreach(var clone in clones)
            {
                if (count>1) {
                    Destroy(clone);
                }
            }

            //if (count < 5)
            //{
            //    // obj.transform.parent = transform;
            //   // Destroy(clone);
            //    //Destroy(target1);
            //}
            // 経過時間リセット
            time = 0f;
            // Destroy(gameObject);       
        }
    }
}