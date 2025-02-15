using System.Collections;
using GGM.Application.Base;
using GGM.Application.Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GGM.Application.OutGame.UI
{
    [RequireComponent(typeof(Button))]
    public class RequesterButton : MonoBehaviour
    {
        public void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick() => StartCoroutine(SendRequest());

        private IEnumerator SendRequest()
        {
            var req = new ReqHelloworld_Hello()
            {
                Name = "Han"
            };

            yield return GameInstance.WebClient.SendGetRequest<ReqHelloworld_Hello, ResHelloworld_Hello>(
                req,
                (res) => print(res.Message),
                () => Debug.LogError("reqfail"));
        }


        private Button _button;
    }
}