using System.Collections;
using GGM.Application.Base;
using UnityEngine;
using UnityEngine.UI;

namespace GGM.Application.OutGame
{
    [RequireComponent(typeof(Button))]
    public class RequesterButton : MonoBehaviour
    {
        public void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClick);
        }

        public void OnButtonClick() => StartCoroutine(SendRequest());

        private IEnumerator SendRequest()
        {
            yield return GameInstance.WebClient.SendGetRequest("api/helloworld/bye?name=오늘수업");
        }


        private Button _button;
    }
}