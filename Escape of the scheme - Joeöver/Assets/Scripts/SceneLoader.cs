using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string _scene;
    private WaveManager _wave;
    void Start()
    {
        _wave = FindAnyObjectByType<WaveManager>();
    }

    // Update is called once per frame
    public void LoadScene(int wave)
    {
        if (wave >= 11)
        {
            SceneManager.LoadScene(_scene);
        }
    }

}
