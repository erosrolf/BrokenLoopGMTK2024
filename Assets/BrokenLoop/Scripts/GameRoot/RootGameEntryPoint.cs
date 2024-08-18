using System.Collections;
using BrokenLoop.GameRoot.Unils;
using BrokenLoop.Scripts.Gameplay.Root;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BrokenLoop.GameRoot
{
    public class RootGameEntryPoint
    {
        private static RootGameEntryPoint _instance;
        private readonly UIRootView _uiRoot;
        private readonly Coroutines _coroutines;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStartGame()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            _instance = new RootGameEntryPoint();
            _instance.RunGame();
        }

        private RootGameEntryPoint()
        {
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);
            
            var prefabUIRoot = Resources.Load<UIRootView>("UIRoot");
            _uiRoot = Object.Instantiate(prefabUIRoot);
            Object.DontDestroyOnLoad(_uiRoot.gameObject);
        }

        private void RunGame()
        {
#if UNITY_EDITOR
            var sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == SceneNames.GAMEPLAY)
            {
                _coroutines.StartCoroutine(LoadAndStartGameplay());
                return;
            }

            if (sceneName != SceneNames.BOOT)
            {
                _uiRoot.HideLoadingScree();
                return;
            }
#endif
            _coroutines.StartCoroutine(LoadAndStartGameplay());
        }

        private IEnumerator LoadAndStartGameplay()
        {
            _uiRoot.ShowLoadingScreen();

            yield return LoadScene(SceneNames.BOOT);
            yield return LoadScene(SceneNames.GAMEPLAY);

            yield return null;
            // yield return new WaitForSeconds(2);
            
            var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
            sceneEntryPoint.Run();
            
            _uiRoot.HideLoadingScree();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}