using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class TCPClient : MonoBehaviour
{
    TcpClient client;
    NetworkStream stream;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        UnityEngine.Debug.Log(Application.dataPath);
        //Process.Start(Application.dataPath + "/Nick/Audio/CAMVRAudio.exe");
        Process.Start(Application.dataPath + "../../CAMVRAudio.exe");
        //Process.Start("Assets/Nick/Audio/Cat And Mouse VR Audio Server.exe");
        try
        {
            client = new TcpClient("127.0.0.1", 12345);
            stream = client.GetStream();

        }
        catch (Exception e)
        {
            //Debug.LogError("Error: " + e.Message);
        }
    }

    public void PlayAudioTV(string name)
    {
        byte[] message = Encoding.UTF8.GetBytes("PlayAudio:" + name);
        stream.Write(message, 0, message.Length);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.H))
    //    {
    //        byte[] message = Encoding.UTF8.GetBytes("PlayAudio:");
    //        stream.Write(message, 0, message.Length);
    //    }

    //    if (Input.GetKeyDown(KeyCode.J))
    //    {
    //        audioSource.Play();
    //    }
    //}


    void OnApplicationQuit()
    {
        byte[] message = Encoding.UTF8.GetBytes("EndAudio");
        stream.Write(message, 0, message.Length);
        stream?.Close();
        client?.Close();
    }
}
