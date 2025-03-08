using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace GGM.Framework
{
    public class WebClient
    {
        public WebClient(string serverUri = "http://127.0.0.1:5076")
        {
            _serverUri = serverUri;
        }

        public IEnumerator SendGetRequest(string endpoint)
        {
            var req = UnityWebRequest.Get($"{_serverUri}/{endpoint}"); // 준비
            yield return req.SendWebRequest(); // 실제로 요청을 보냄

            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = req.downloadHandler.text;

                Debug.Log(res);
            }
            else
            {
                Debug.LogError($"FAILED_REQUEST ({req.result}/{req.error})");
            }
        }

        private string _serverUri = string.Empty;
    }
}