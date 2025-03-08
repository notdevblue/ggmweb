using GGM.Framework;
using UnityEngine;

namespace GGM.Application.Base
{
    public class GameInstance : MonoBehaviour
    {
        public void Awake()
        {
            _webClient = new WebClient();
        }

        private static GameInstance _instance;
        public static GameInstance GetInstance()
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<GameInstance>();
                if (_instance == null)
                {
                    var newGameObject = new GameObject("GameInstance");
                    var instance = newGameObject.AddComponent<GameInstance>();
                    _instance = instance;
                }
                DontDestroyOnLoad(_instance);
            }

            return _instance; //GameInstance.WebClient.SendGetRequest(); 이렇게 쓰려고 만듬
        }


        private WebClient _webClient = default;
        public static WebClient WebClient => GetInstance()._webClient;
    }
}