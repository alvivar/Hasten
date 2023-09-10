// using BestHTTP.WebSocket;
// using BITE;
// using System;
// using System.Collections.Generic;
// using System.Text;
// using UnityEngine;

// public class BITEBestWS : MonoBehaviour
// {
//     public Action<Frame> OnFrameReceived;

//     public int QueueLength { get { return frameQueue.Bytes.Length; } }

//     [Header("Config")]
//     public string ip = "167.99.58.31"; // 127.0.0.1
//     public int port = 1991; // 1983

//     [Header("Info")]
//     public bool connected = false;
//     public int id = -1;
//     public int messageCount = 0;

//     private readonly Dictionary<int, Action<Frame>> callbacks = new();
//     private readonly Frames framesReceived = new();

//     private Frame frameQueue = new();
//     private WebSocket webSocket;

//     public void Start()
//     {
//         var address = $"ws://{ip}:{port}/ws";
//         webSocket = new WebSocket(new Uri(address));

//         webSocket.OnOpen += OnOpen;
//         webSocket.OnMessage += OnMessageReceived;
//         webSocket.OnBinary += OnBinaryReceived;
//         webSocket.OnClosed += OnClosed;
//         webSocket.OnError += OnError;

//         webSocket.Open();
//     }

//     void OnDestroy()
//     {
//         if (webSocket != null)
//         {
//             webSocket.Close();
//             webSocket = null;
//         }
//     }

//     void OnOpen(WebSocket ws)
//     {
//         Debug.Log("BITE WS Opened!");
//     }

//     void OnMessageReceived(WebSocket ws, string message)
//     {
//         Debug.Log($"BITE WS Message Received ({message.Length}): {message}");
//     }

//     void OnBinaryReceived(WebSocket ws, byte[] message)
//     {
//         framesReceived.Feed(message);
//         while (framesReceived.ProcessingCompleteFrames()) ;
//         while (framesReceived.HasCompleteFrame)
//         {
//             connected = true;

//             var frame = framesReceived.Dequeue();

//             // The first message is the id.
//             if (id == -1)
//                 id = frame.ClientId;

//             OnFrameReceived?.Invoke(frame);

//             if (callbacks.ContainsKey(frame.MessageId))
//             {
//                 callbacks[frame.MessageId](frame);
//                 callbacks.Remove(frame.MessageId);
//             }
//         }
//     }

//     void OnClosed(WebSocket ws, UInt16 code, string message)
//     {
//         Debug.Log($"BITE WS Closed: {code} {message}");

//         webSocket = null;
//         connected = false;
//     }

//     void OnError(WebSocket ws, string error)
//     {
//         Debug.Log($"BITE WS Error: {error}");

//         webSocket = null;
//         connected = false;
//     }

//     public void Send(string message, Action<Frame> callback = null)
//     {
//         var data = Encoding.UTF8.GetBytes(message);
//         var frame = new Frame().FeedProtocol(id, ++messageCount, data);
//         webSocket.Send(frame.Bytes);

//         if (callback != null)
//             callbacks[messageCount] = callback;
//     }

//     public void Queue(string message, Action<Frame> callback = null)
//     {
//         var data = Encoding.UTF8.GetBytes(message);
//         frameQueue.FeedProtocol(id, ++messageCount, data);

//         if (callback != null)
//             callbacks[messageCount] = callback;
//     }

//     public void SendQueued()
//     {
//         if (frameQueue.Bytes.Length < 1)
//             return;

//         webSocket.Send(frameQueue.Bytes);
//         frameQueue = new Frame();
//     }

//     [ContextMenu("Close")]
//     public void Close()
//     {
//         webSocket.Close(1000, "Bye!");
//     }

//     [ContextMenu("Send Test Messages")]
//     public void SentTestMessages()
//     {
//         var date = DateTime.Now;

//         for (int i = 0; i < 1000; i++)
//         {
//             Send($"#g bite.best.ws.date.{i}");
//             Send($"s bite.best.ws.date.{i} {date}");
//             Send($"g bite.best.ws.date.{i}");
//             Send($"d bite.best.ws.date.{i}");
//         }
//     }
// }
