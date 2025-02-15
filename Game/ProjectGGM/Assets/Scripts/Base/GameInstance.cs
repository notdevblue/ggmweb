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


        private static GameInstance _instance = null;
        private static GameInstance GetInstance()
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

            return _instance;
        }

        private WebClient _webClient = new();
        public static WebClient WebClient => GetInstance()._webClient;
    }
}