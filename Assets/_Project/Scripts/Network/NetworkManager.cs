// File: Assets/_Project/Scripts/Network/NetworkManager.cs
// Singleton wrapping TMSKSocket + dispatch inbound packets to CmdRegistry on main thread.

using UnityEngine;

namespace ThanMaOrigin.Network
{
    public class NetworkManager : MonoBehaviour
    {
        public static NetworkManager Instance { get; private set; } = null!;

        // Gateway endpoints (gốc Script_ClientDef.lua:5-9 had 61.28.227.* IPs).
        // DEVIATION: redirect to thanmaorigin LocalServer.
        public string ServerHost = "127.0.0.1";
        public int ServerPort = 11001;

        private TMSKSocket _sock = new TMSKSocket();

        public bool Connected => _sock.Connected;

        void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Wire CmdRegistry → outbound socket
            CmdRegistry.OnSendCmd += OnSendCmd;
        }

        public bool Connect()
        {
            return _sock.Connect(ServerHost, ServerPort);
        }

        void OnSendCmd(int cmdId, byte[] payload)
        {
            _sock.Send(cmdId, payload);
        }

        void Update()
        {
            // Dispatch inbound packets on main thread
            while (_sock.InboundQueue.TryDequeue(out var pkt))
            {
                CmdRegistry.OnPacketReceived(pkt.opcode, pkt.payload);
            }
        }

        void OnDestroy()
        {
            CmdRegistry.OnSendCmd -= OnSendCmd;
            _sock.Close();
            if (Instance == this) Instance = null!;
        }
    }
}
