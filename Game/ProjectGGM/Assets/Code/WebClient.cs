using System;
using System.Collections;
using System.Text.Json;
using GGM.Application.Protocol;
using UnityEngine;
using UnityEngine.Networking;

#nullable enable

namespace GGM.Framework
{
    public class WebClient
    {
        public WebClient(string serverUri = "http://127.0.0.1:5057")
        {
            _serverUri = serverUri;
        }

        public IEnumerator SendGetRequest<REQ, RES>(REQ payload, Action<RES>? onCompleted = null, Action? onFaliure = null)
            where REQ : class, IReqBase
            where RES : class, new()
        {
            var reqEndpoint = payload.GetEndpoint();
            var reqQuery = payload.ToQuerystring();
            var reqUri = GetRequestUri($"{reqEndpoint}{reqQuery}");
            var req = UnityWebRequest.Get(reqUri);

            

            // TODO: trycatch
            Debug.Log($"SendGetRequest(reqUri)");
            yield return req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
            {
                var resJson = req.downloadHandler.text;
                var res = JsonSerializer.Deserialize<RES>(resJson);

                if (res == null)
                {
                    Debug.LogWarning("NullResSendGetRequest()");
                    res = new();
                }

                onCompleted?.Invoke(res);
            }
            else
            {
                Debug.LogError($"FailedSendGetRequest({req.result}/{req.error})");
                onFaliure?.Invoke();
            }
        }


        private string GetRequestUri(string inEndpoint) =>
            $"{_serverUri}/api/{inEndpoint}";

        private readonly string _serverUri;
    }
}