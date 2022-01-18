using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionsTest : MonoBehaviour
{
    public SteamVR_Input_Sources handType;  // 1…入力をポーリングする手の種類。
    public SteamVR_Action_Boolean teleportAction; // 2…テレポートアクションへの参照。
    public SteamVR_Action_Boolean grabAction; // 3…グラブアクションへの参照。
    

    void Update()
    {
        // 作成したメソッドをチェックし返されたメッセージをコンソールに出力する。
        if (GetTeleportDown())
        {
            print("Teleport" + handType);
        }

        if(GetGrab())
        {
            print("Grab" + handType);
        }
    }

    public bool GetTeleportDown()// 1
    {
        return teleportAction.GetStateDown(handType);
    }
    public bool GetGrab() // 2
    {
        return grabAction.GetState(handType);
    }
    // 1…テレポートアクションが有効になったらtrueを返す
    // 2…グラブアクションが有効になったらtrueを返す
}
