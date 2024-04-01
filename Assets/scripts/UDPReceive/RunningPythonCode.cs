// using UnityEngine;
// using System.Diagnostics;
// using Python.Runtime;

// // RunScript("main");

// // static void RunScript(string scriptName)
// // {
// //     Runtime.PythonDLL = @"C:\xampp\mailtodisk\python27.dll";
// //     PythonEngine.Initialize();

// //     using (Py.GIL())
// //     {
// //         var pythonScript = Py.Import(scriptName);
// //         var results = pythonScript.InvokeMethod("track_hands")
// //     }
// // }

// //Define RunScript method outside the UDPReceive class
// public class RunningPythonCode : MonoBehaviour
// {
//     void Start()
//     {
//         RunScript("main");
//         // Debug.log("Running  Python code in unity...");
//     }

//     static void RunScript(string scriptName)
//     {
//         Runtime.PythonDLL = @"C:\xampp\mailtodisk\python27.dll";
//         PythonEngine.Initialize();

//         using (Py.GIL())
//         {
//             var pythonScript = Py.Import(scriptName);
//             var results = pythonScript.InvokeMethod("track_hands");
//         }
//     }
// }