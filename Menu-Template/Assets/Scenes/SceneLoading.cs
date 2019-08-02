using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{

    public Image progressBar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncOperation()); //Funcion que empieza fuera del hilo principal
    }

    IEnumerator LoadAsyncOperation()
    {

        AsyncOperation gameLevel = SceneManager.LoadSceneAsync("Nivel1");

        while(gameLevel.progress < 1)
        {
            progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
