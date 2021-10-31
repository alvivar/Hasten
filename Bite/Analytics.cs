using System;
using BiteServer;
using UnityEngine;

public class Analytics : MonoBehaviour
{
    public string user = "team.game.user";

    [Header("Server")]
    public string host = "142.93.180.20";
    public int port = 1984;

    [Header("Info")]
    public string id; // SystemInfo.deviceUniqueIdentifier
    public string key;
    public AnalyticsData data;

    [Header("Config")]
    public int tick = 3;
    public float clock = 0;

    [Header("Optional")]
    public Transform position;

    private bool connected = false;
    private bool lastPositionLoaded = false;

    private Bite bite;

    void Start()
    {
        id = SystemInfo.deviceUniqueIdentifier;
        key = $"{user}.{id}";

        bite = new Bite(host, port);

        bite.Send($"Ping from {id}", r =>
        {
            connected = true;
            Debug.Log("Analytics connected");
        });

        LoadDataFromServer();
        LoadOrSetStartedEpoch();
    }

    void OnDestroy()
    {
        if (bite != null)
            bite.Close();
    }

    void Update()
    {
        if (!connected)
            return;

        if (clock > Time.time)
            return;
        clock = Time.time + tick;

        SaveTimePlayed(tick);

        SaveLastEpoch();

        SaveLastPosition();
    }

    void LoadDataFromServer()
    {
        bite.Send($"g {key}.name", response =>
        {
            if (response.Trim().Length < 1) SetName($"{id}");
            else data.name = response;
        });

        bite.Send($"g {key}.timePlayed", response =>
        {
            data.timePlayed = Bitf.Int(response, 0);
        });

        bite.Send($"j {key}.lastPosition", response =>
        {
            var json = JsonUtility.FromJson<Pos>(response);

            data.lastPosition = new Vector3(
                Bitf.Float($"{json.x}", 0),
                Bitf.Float($"{json.y}", 0),
                Bitf.Float($"{json.z}", 0));

            lastPositionLoaded = true;
        });
    }

    void LoadOrSetStartedEpoch()
    {
        bite.Send($"g {key}.startedEpoch", response =>
        {
            data.startedEpoch = Bitf.Long(response, 0);

            if (data.startedEpoch <= 0)
            {
                data.startedEpoch = DateTimeOffset.Now.ToUnixTimeSeconds();
                bite.Send($"s {key}.startedEpoch {data.startedEpoch}");
            }
        });
    }

    void SaveTimePlayed(int time)
    {
        if (data.timePlayed < 0) // Wait to be loaded for the first time.
            return;

        data.timePlayed += time;
        bite.Send($"s {key}.timePlayed {data.timePlayed}");
    }

    void SaveLastEpoch()
    {
        data.lastEpoch = DateTimeOffset.Now.ToUnixTimeSeconds();
        bite.Send($"s {key}.lastEpoch {data.lastEpoch}");
    }

    void SaveLastPosition()
    {
        if (!position || !lastPositionLoaded)
            return;

        if (data.lastPosition == position.transform.position)
            return;

        data.lastPosition = position.transform.position;

        // Multiples sets in one send.
        var x = $"s {key}.lastPosition.x {data.lastPosition.x}\n";
        var y = $"s {key}.lastPosition.y {data.lastPosition.y}\n";
        var z = $"s {key}.lastPosition.z {data.lastPosition.z}";
        bite.Send($"{x}{y}{z}");
    }

    public void SetName(string name)
    {
        data.name = name;
        bite.Send($"s {key}.name {data.name}");
    }
}

[System.Serializable]
public class AnalyticsData
{
    public string name;
    public int timePlayed = -1;
    public Vector3 lastPosition;
    public long lastEpoch = -1;
    public long startedEpoch = -1;
}

internal class Pos
{
    public float x;
    public float y;
    public float z;
}