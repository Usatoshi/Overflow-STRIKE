using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ballを転がす処理
/// </summary>
public class RollOver : MonoBehaviour
{
    private Rigidbody rb;   //  重力
    [SerializeField] private Vector3 force; // 力を加える
    // Start is called before the first frame update
    void Start()
    {
        // Ballの重力値を取得
        rb = this.gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //  力を加える
        rb.AddForce(force);

        
    }
}
