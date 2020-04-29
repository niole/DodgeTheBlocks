using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // this is how you define a singletone
    // access via: GameManager.Instance
    public static GameManager Instance { get; private set; }

    public static float blockGravityScale = 1f;

    private float slowness = 10f;

    void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void HandleEndGame ()
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        yield return new WaitForSeconds(2f / slowness);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public float IncrementGravityScale(float inc)
    {
        blockGravityScale += inc;
        return blockGravityScale;
    }

    public float SetGravityScale(float newScale)
    {
        blockGravityScale = newScale;
        Debug.Log($"SetGravityScale {blockGravityScale}");
        return blockGravityScale;
    }

    public float GetGravityScale()
    {
        return blockGravityScale;
    }

}
