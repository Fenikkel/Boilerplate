using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UdpSender : MonoBehaviour
{
    private UdpConnection connection;

    void Start()
    {
        string sendIp = "255.255.255.255";//"127.0.0.1"; //Local host??
        int sendPort = 4009;
        int receivePort = 11000;

        connection = new UdpConnection();
        connection.StartConnection(sendIp, sendPort, receivePort);
    }

    void Update()
    {
        foreach (var message in connection.getMessages()) Debug.Log(message);

        connection.Send("stop");
    }

    void OnDestroy()
    {
        connection.Stop();
    }
}
