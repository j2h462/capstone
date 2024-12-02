using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;

    [SerializeField]
    private Image Loading_Bar; // Inspector에서 할당

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }

    void Start()
    {
        if (Loading_Bar == null)
        {
            Debug.LogWarning("Loading_Bar가 Inspector에서 연결되지 않았습니다. GameObject.Find로 시도합니다.");
            GameObject barObject = GameObject.Find("LoadingBar");
            if (barObject != null)
            {
                Loading_Bar = barObject.GetComponent<Image>();
            }

            if (Loading_Bar == null)
            {
                Debug.LogError("Loading_Bar를 찾을 수 없습니다!");
                return;
            }
        }

        Loading_Bar.fillAmount = 0; // 로딩바를 비운 상태로 시작
        Debug.Log($"초기 fillAmount 값: {Loading_Bar.fillAmount}");

        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                Loading_Bar.fillAmount = Mathf.Lerp(Loading_Bar.fillAmount, op.progress / 0.9f, Time.deltaTime * 10f);
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                float fillValue = Mathf.Lerp(0.9f, 1.0f, timer);
                Loading_Bar.fillAmount = fillValue;

                if (fillValue >= 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
