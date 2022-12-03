// using System;
// using UnityEngine;
// using BiteClient;

// [System.Serializable]
// public struct AnalyticsData
// {
//     public string name;
//     public int timePlayed;
//     public Vector3 lastPosition;
//     public long lastEpoch;
//     public long startedEpoch;
// }

// internal struct Pos { public float x; public float y; public float z; }

// public class Analytics : MonoBehaviour
// {
//     public string keyName = "team.game.user";

//     [Header("Server")]
//     public string host = "167.99.58.31";
//     public int port = 1984;

//     [Header("Info")]
//     public string id; // SystemInfo.deviceUniqueIdentifier
//     public string key;
//     public AnalyticsData data;

//     [Header("Config")]
//     public int tick = 3;
//     public float clock = 0;

//     [Header("Optional")]
//     public Transform position;

//     private bool lastPositionLoaded = false;

//     private Bite bite;

//     private void Start()
//     {
//         id = SystemInfo.deviceUniqueIdentifier;
//         key = $"{keyName}.{id}";

//         bite = new Bite(host, port);
//         bite.OnConnected += frame => bite.Send($"! ping {id}", frame =>
//         {
//             LoadDataFromServer();
//             LoadOrSetStartedEpoch();

//             Debug.Log($"Analytics connected");
//         });
//     }

//     private void OnDestroy()
//     {
//         if (bite != null)
//             bite.Shutdown();
//     }

//     // private void Update()
//     // {
//     //     // Wait for connection.
//     //     if (!allowUpdate)
//     //         return;

//     //     // Server tick
//     //     if (clock > Time.time)
//     //         return;
//     //     clock = Time.time + tick;

//     //     // Statistics
//     //     SaveTimePlayed(tick);
//     //     SaveLastEpoch();
//     //     SaveLastPosition();
//     // }

//     public void SetName(string name)
//     {
//         data.name = name;
//         bite.Send($"s {key}.name {data.name}");
//     }

//     private void LoadDataFromServer()
//     {
//         bite.Send($"g {key}.name", frame =>
//         {
//             Debug.Log($"Analytics name: {string.Join(" ", frame.Data)}");
//             var message = Bitf.Str(frame.Content);
//             Debug.Log($"Analytics name: {message}");

//             if (message.Trim().Length < 1)
//                 message = "?";

//             data.name = message;
//         });

//         bite.Send($"g {key}.timePlayed", frame =>
//         {
//             Debug.Log($"Analytics timePlayed: {string.Join(" ", frame.Data)}");
//             data.timePlayed = Bitf.Int(frame.Text);
//             Debug.Log($"Analytics timePlayed: {data.timePlayed}");
//         });

//         bite.Send($"j {key}.lastPosition", frame =>
//         {
//             Debug.Log($"Analytics lastPosition: {string.Join(" ", frame.Data)}");
//             var message = frame.Text;
//             Debug.Log($"Analytics lastPosition: {message}");

//             try
//             {
//                 var json = JsonUtility.FromJson<Pos>(message);
//                 data.lastPosition = new Vector3(
//                     Bitf.Float($"{json.x}"),
//                     Bitf.Float($"{json.y}"),
//                     Bitf.Float($"{json.z}"));
//             }
//             catch (ArgumentException e)
//             {
//                 Debug.Log($"Not a valid json: {e.Message}");
//             }

//             lastPositionLoaded = true;
//         });
//     }

//     private void LoadOrSetStartedEpoch()
//     {
//         bite.Send($"g {key}.startedEpoch", frame =>
//         {
//             var str = frame.Text;
//             Debug.Log($"Started Epoch: {str}");
//             data.startedEpoch = Bitf.Long(str);
//             Debug.Log($"Started Epoch: {data.startedEpoch}");

//             if (data.startedEpoch <= 0)
//             {
//                 data.startedEpoch = DateTimeOffset.Now.ToUnixTimeSeconds();
//                 bite.Send($"s {key}.startedEpoch {data.startedEpoch}");
//             }
//         });
//     }

//     private void SaveTimePlayed(int time)
//     {
//         if (data.timePlayed <= 0) // Wait to be loaded for the first time.
//             return;

//         data.timePlayed += time;
//         bite.Send($"s {key}.timePlayed {data.timePlayed}");
//     }

//     private void SaveLastEpoch()
//     {
//         data.lastEpoch = DateTimeOffset.Now.ToUnixTimeSeconds();
//         bite.Send($"s {key}.lastEpoch {data.lastEpoch}");
//     }

//     private void SaveLastPosition()
//     {
//         if (!position || !lastPositionLoaded)
//             return;

//         if (data.lastPosition == position.transform.position)
//             return;

//         data.lastPosition = position.transform.position;

//         // Multiples sets in one send.
//         var x = $"s {key}.lastPosition.x {data.lastPosition.x}\n";
//         var y = $"s {key}.lastPosition.y {data.lastPosition.y}\n";
//         var z = $"s {key}.lastPosition.z {data.lastPosition.z}";
//         bite.Send($"{x}{y}{z}");
//     }
// }
