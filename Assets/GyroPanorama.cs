using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GyroPanorama : MonoBehaviour
{
    private Quaternion gyroscopeQua;
    private Quaternion quatMult = new Quaternion(0, 0, 1, 0);
    private float speedH = 0.2f;
    protected void Start()
    {
        Input.gyro.enabled = true;
        transform.eulerAngles = new Vector3(90, 0, 0);
    }

    protected void Update()
    {
        GyroModifyCamera();
    }

    protected void GyroModifyCamera()
    {
        gyroscopeQua = Input.gyro.attitude * quatMult;
        Camera.main.transform.localRotation = Quaternion.Slerp(
            Camera.main.transform.localRotation,
            gyroscopeQua,
            speedH
            );
    }

    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;
        GUILayout.Label("Orientation: " + Screen.orientation);
        GUILayout.Label("input.gyro.eulerAngles: " + Input.gyro.attitude.eulerAngles);
        GUILayout.Label("now eulerAngles: " + Camera.main.transform.eulerAngles);
        GUILayout.Label("iphone width/font: " + Screen.width + " : " + GUI.skin.label.fontSize);
    }
}