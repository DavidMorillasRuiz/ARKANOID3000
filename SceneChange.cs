using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    private Animator transitionAnimator;
    [SerializeField] private float transitionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        GameManager.Instance.BlockDestroyed();
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(SceneLoad(nextSceneIndex));
    }


    public IEnumerator SceneLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }

}
