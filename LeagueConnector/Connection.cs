using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using LeagueConnector.Enum;
using LeagueConnector.Events;
using LeagueConnector.Exceptions;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocket = WebSocketSharp.WebSocket;

namespace LeagueConnector
{
    public class Connection
    {
        #region Fields
        private bool _isConnected;
        private readonly HttpClient _client;
        private WebSocket _socket;
        private int _port;
        private string _token;
        #endregion

        #region Events
        public Action<ConnectionChangedEvent> OnConnectionChangedEvent;
        public event Action<WebsocketEventBase> OnWebsocketEvent;
        #endregion

        public bool IsConnected
        {
            get => _isConnected;
            private set
            {
                if(value == _isConnected) return;
                _isConnected = value;
                OnConnectionChangedEvent?.Invoke(new ConnectionChangedEvent
                {
                    Status = value
                });
            }
        }

        public Connection()
        {
            _client = new HttpClient(new HttpClientHandler
            {
                SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls,
                ServerCertificateCustomValidationCallback = (a, b, c, d) => true
            });
        }

        public void Connect(int port, string token)
        {
            _port = port;
            _token = token;

            var byteArray = Encoding.ASCII.GetBytes("riot:" + token);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            _socket = new WebSocket("wss://127.0.0.1:" + port + "/", "wamp");
            _socket.SetCredentials("riot", token, true);
            _socket.SslConfiguration.EnabledSslProtocols = SslProtocols.Tls12;
            _socket.SslConfiguration.ServerCertificateValidationCallback = (a, b, c, d) => true;
            _socket.OnClose += OnSocketClose;
            _socket.OnOpen += OnSocketOpen;
            _socket.OnMessage += HandleMessage;
            _socket.Connect();
        }

        private void OnSocketOpen(object sender, EventArgs eventArgs)
        {
            _socket.Send("[5,\"OnJsonApiEvent\"]");
            IsConnected = true;
        }

        private void OnSocketClose(object sender, CloseEventArgs closeEventArgs)
        {
            IsConnected = false;
            _socket = null;
        }

        private void HandleMessage(object sender, MessageEventArgs args)
        {
            if (!args.IsText) return;
            var load = JsonConvert.DeserializeObject<dynamic>(args.Data);

            if (load.Count != 3) return;
            if ((long)load[0] != 8 || !((string)load[1]).Equals("OnJsonApiEvent")) return;

            var ev = load[2];

            OnWebsocketEvent?.Invoke(new WebsocketEventBase
            {
                Path = ev["uri"],
                Type = System.Enum.Parse(typeof(ESocketEventType), ev["eventType"].ToString()),
                RawData = ev["eventType"] == "Delete" ? null : ev["data"].ToString()
            });
        }

        public async Task<bool> Delete(string url)
        {
            var resp = await Send(HttpMethod.Delete, url);
            return IsGoodResponse(resp.StatusCode);
        }

        public async Task<byte[]> GetByteArray(string url)
        {
            var resp = await Send(HttpMethod.Get, url);
            return await resp.Content.ReadAsByteArrayAsync();
        }

        public async Task<bool> Post(string url, string body, string mediaType = "application/json")
        {
            var content = new StringContent(body, Encoding.UTF8, mediaType);
            var resp = await Send(HttpMethod.Post, url, content);
            return IsGoodResponse(resp.StatusCode);
        }

        public async Task<T> Get<T>(string url)
        {
            var resp = await Send(HttpMethod.Get, url);
            var respContent = await resp.Content.ReadAsStringAsync();

            if (IsGoodResponse(resp.StatusCode))
            {
                return JsonConvert.DeserializeObject<T>(respContent);
            }
            else
            {
                return default(T);
            }
        }

        private async Task<HttpResponseMessage> Send(HttpMethod method, string url, HttpContent content = null)
        {
            if (!IsConnected) throw new NotConnectedException();

            var req = new HttpRequestMessage(method, "https://127.0.0.1:" + _port + url);
        
            if (content != null) req.Content = content;

            return await _client.SendAsync(req);
        }

        private bool IsGoodResponse(HttpStatusCode code)
        {
            switch (code)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.OK:
                    return true;
                default:
                    return false;
            }
        }

    }
}