using System;
using System.IO.Ports;
using UnityEngine;

public class SerialManager : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM6", 115200);  // 포트 번호 설정
    private string receivedData = "";  // 수신한 데이터 저장 변수

    void Start()
    {
        serialPort.Open();
        serialPort.ReadTimeout = 1000;
    }

    void Update()
    {
        try
        {
            if (serialPort.IsOpen)
            {
                string data = serialPort.ReadLine();  // OpenMV에서 보낸 데이터 수신
                receivedData = data;  // 수신한 데이터를 저장
                Debug.Log("Received: " + data);  // Unity Console에 출력
            }
        }
        catch (System.Exception)
        {
            // 타임아웃 등 예외 처리
            Debug.Log("에러남");
        }
    }

    [ContextMenu("Send AT")]
    public void SendSignal()
    {
        serialPort.Write("AT");
    }

    void OnGUI()
    {
        // 수신한 데이터를 화면 중앙에 표시
        // GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 200, 50), "Received Data: " + receivedData);
        Debug.Log("Received Data : " + receivedData);
    }

    void OnApplicationQuit()
    {
        serialPort.Close();  // 종료 시 포트 닫기
    }
}
