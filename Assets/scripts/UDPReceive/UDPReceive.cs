using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Python.Runtime;


// Define RunScript method outside the UDPReceive class
public class PythonRunner : MonoBehaviour
{
    void Start()
    {
        RunScript("main");
    }

    static void RunScript(string scriptName)
    {
        Runtime.PythonDLL = @"C:\Users\aruns\AppData\Local\Programs\Python\Python312\Python312.dll";
        PythonEngine.Initialize();

        using (Py.GIL())
        {
            var pythonScript = Py.Import(scriptName);
            var results = pythonScript.InvokeMethod("track_hands");
        }
    }
}


public class UDPReceive : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;
    public int port = 5055;
    public bool startRecieving = true;
    public bool printToConsole = false;
    public string data;

    public void Start()
    {
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    // receive thread
    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (startRecieving)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);
                data = Encoding.UTF8.GetString(dataByte);

                if (printToConsole)
                {
                    //Debug.Log(data);
                }
            }
            catch (Exception err)
            {
                Debug.LogError("Error receiving data: " + err.Message);
            }
        }
    }
}

