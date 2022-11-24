using UnityEngine;
using UnityEngine.SceneManagement;
using SceneMan = UnityEngine.SceneManagement.SceneManager;

namespace NjoyKidzCase.Managers
{
    public class SceneManager : MonoBehaviour
    {
        private void Awake()
        {
            for (int i = 1; i < 5; i++)
            {
                Scene scene = SceneMan.GetSceneByBuildIndex(i);

                if (!scene.isLoaded)
                {
                    SceneMan.LoadScene(i, LoadSceneMode.Additive);
                }
            }
        }
    }
}