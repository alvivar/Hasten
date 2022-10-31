using UnityEngine;
using BiteClient;
using System.Text;

public class BiteTest : MonoBehaviour
{
    public string command = "s test ";
    public string subscription = "#g test";

    [Header("Network")]
    public string host = "127.0.0.1";
    public int port = 1984;

    private Bite bite;

    public void OnEnable() { Connect(); }
    public void OnDisable() { bite.Shutdown(); }

    [ContextMenu("Test")]
    public void Connect()
    {
        var uid = SystemInfo.deviceUniqueIdentifier;

        bite = new Bite(host, port);
        bite.OnConnected += frame =>
        {
            Debug.Log($"BITE ID {frame.ClientId}");

            bite.Send($"! ping from {uid}", frame =>
            {
                var clientId = frame.ClientId;
                var messageId = frame.MessageId;
                var text = frame.Text.Trim();

                Debug.Log($"Client {clientId} Message {messageId}");
                Debug.Log($"Bytes ({frame.Size}): {string.Join(" ", frame.Data)}");
                Debug.Log($"Text ({text.Length}): {text}");

                SendMaxBytes();
            });
        };

        bite.OnFrameReceived += frame =>
        {
            var clientId = frame.ClientId;
            var messageId = frame.MessageId;
            var text = frame.Text.Trim();

            Debug.Log($"Client {clientId} Message {messageId}");
            Debug.Log($"Bytes ({frame.Size}): {string.Join(" ", frame.Data)}");
            Debug.Log($"Text ({text.Length}): {text}");
        };
    }

    public void SendMaxBytes()
    {
        bite.Send($"{subscription}", frame =>
        {
            Debug.Log("SendMaxBytes subscription response");

            var clientId = frame.ClientId;
            var messageId = frame.MessageId;
            var text = frame.Text.Trim();

            Debug.Log($"Client {clientId} Message {messageId}");
            Debug.Log($"Bytes ({frame.Size}): {string.Join(" ", frame.Data)}");
            Debug.Log($"Text ({text.Length}): {text}");
        });

        var from = 0;
        var to = 255;
        var ascii = 0;

        var max = 65535;
        var commandSize = command.Length + 6;

        var builder = new StringBuilder();
        for (int i = 0; i < max - commandSize; i++)
        {
            ascii = ascii > to ? from : ascii;
            builder.Append((char)ascii);
            ascii += 1;
        }

        string content = builder.ToString();
        Debug.Log($"{command}content ({content.Length}): {content}");

        bite.Send($"{command}{content}", frame =>
        {
            Debug.Log("SendMaxBytes set response");

            var clientId = frame.ClientId;
            var messageId = frame.MessageId;
            var text = frame.Text.Trim();

            Debug.Log($"Client {clientId} Message {messageId}");
            Debug.Log($"Bytes ({frame.Size}): {string.Join(" ", frame.Data)}");
            Debug.Log($"Text ({text.Length}): {text}");
        });
    }
}
