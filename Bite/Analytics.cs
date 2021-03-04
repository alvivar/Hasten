using System;
using UnityEngine;

internal class Pos
{
    public float x;
    public float y;
    public float z;
}

[System.Serializable]
public class AnalyticsData
{
    public string name;
    public int timePlayed;
    public Vector3 lastPosition;
    public long lastEpoch;
    public long startedEpoch;
}

public class Analytics : MonoBehaviour
{
    public string user = "team.game.user";

    [Header("Info")]
    public string id; // SystemInfo.deviceUniqueIdentifier
    public string key;
    public AnalyticsData data;

    [Header("Config")]
    public int tick = 3;
    public float timer = 3;

    [Header("Optional")]
    public Transform position;

    private bool firstConnection = false;
    private bool lastPositionLoaded = false;

    private Bite bite;

    void Start()
    {
        id = SystemInfo.deviceUniqueIdentifier;
        key = $"{user}.{id}";

        Connect();
    }

    void Update()
    {
        // Tick.
        if (Time.time < timer)
            return;
        timer = Time.time + tick;

        // Ping until first response.
        if (!firstConnection)
        {
            bite.Send("g");
            return;
        }

        // Statistics.
        SaveTimePlayed(tick);

        SaveLastEpoch();

        SaveLastPosition();
    }

    void Connect()
    {
        bite = new Bite("142.93.180.20", 1984);
        bite.OnResponse += OnResponse;
        bite.OnError += OnError;
    }

    void OnDestroy()
    {
        if (bite != null)
        {
            bite.Stop();

            bite.OnResponse -= OnResponse;
            bite.OnError -= OnError;
        }
    }

    void OnError(string error)
    {
        Debug.Log($"Analytics error: {error}");
    }

    void OnResponse(string response)
    {
        if (!firstConnection)
        {
            firstConnection = true;

            Debug.Log($"Analytics started!");

            LoadDataFromServer();

            LoadOrSetStartedEpoch();
        }
    }

    void LoadDataFromServer()
    {
        bite.Send($"g {key}.name", response =>
        {
            if (response.Trim().Length < 1)
                response = "?";

            data.name = response;
        });

        bite.Send($"g {key}.timePlayed", response =>
        {
            data.timePlayed = Bite.Int(response, 0);
        });

        bite.Send($"j {key}.lastPosition", response =>
        {
            var json = JsonUtility.FromJson<Pos>(response);

            data.lastPosition = new Vector3(
                Bite.Float($"{json.x}", 0),
                Bite.Float($"{json.y}", 0),
                Bite.Float($"{json.z}", 0));

            lastPositionLoaded = true;
        });
    }

    void SaveTimePlayed(int time)
    {
        data.timePlayed += time;
        bite.Send($"s {key}.timePlayed {data.timePlayed}");
    }

    void SaveLastEpoch()
    {
        data.lastEpoch = DateTimeOffset.Now.ToUnixTimeSeconds();
        bite.Send($"s {key}.lastEpoch {data.lastEpoch}");
    }

    void LoadOrSetStartedEpoch()
    {
        bite.Send($"g {key}.startedEpoch", response =>
        {
            data.startedEpoch = Bite.Long(response, 0);

            if (data.startedEpoch <= 0)
            {
                data.startedEpoch = DateTimeOffset.Now.ToUnixTimeSeconds();
                bite.Send($"s {key}.startedEpoch {data.startedEpoch}");
            }
        });
    }

    void SaveLastPosition()
    {
        if (!position || !lastPositionLoaded)
            return;

        if (data.lastPosition == position.transform.position)
            return;

        data.lastPosition = position.transform.position;

        bite.Send($"s {key}.lastPosition.x {data.lastPosition.x}");
        bite.Send($"s {key}.lastPosition.y {data.lastPosition.y}");
        bite.Send($"s {key}.lastPosition.z {data.lastPosition.z}");
    }

    public void SetName(string name)
    {
        data.name = name;
        bite.Send($"s {key}.name {data.name}");
    }
}