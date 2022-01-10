using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public Counter counter;

    private void Awake() {
        Debug.Log("Opened scene " + SceneManager.GetActiveScene().name);
    }

    IEnumerator Start() {
        yield return new WaitForSeconds(1f);

        counter.enabled = true;

        while (counter.Counts < 20)
            yield return null;

        counter.enabled = false;

        var currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == SceneManager.sceneCountInBuildSettings - 1)
            Application.Quit();
        else
            SceneManager.LoadScene(currentScene + 1);
    }
}

/*
Last time: 5,92950000ms. Average time: 4.70300000ms.
Last time: 5,24520000ms. Average time: 5.16572300ms.
Last time: 5,72050000ms. Average time: 5.27535200ms.
Last time: 5,31740000ms. Average time: 5.37361200ms.
Last time: 5,23010000ms. Average time: 5.38139000ms.
Last time: 5,44450000ms. Average time: 5.37614700ms.
Last time: 5,19760000ms. Average time: 5.38396500ms.
Last time: 5,19720000ms. Average time: 5.37461600ms.
Last time: 5,29340000ms. Average time: 5.39589100ms.
Last time: 5,27220000ms. Average time: 5.39965600ms.
Last time: 5,52250000ms. Average time: 5.39409400ms.
Last time: 5,89810000ms. Average time: 5.40899300ms.
Last time: 9,81520000ms. Average time: 5.51917600ms.
Last time: 5,67560000ms. Average time: 5.66103000ms.
Last time: 7,05230000ms. Average time: 5.70246500ms.
Last time: 5,55180000ms. Average time: 5.71722000ms.
Last time: 5,23190000ms. Average time: 5.69618700ms.
Last time: 5,48250000ms. Average time: 5.67950000ms.
Last time: 5,18260000ms. Average time: 5.66916800ms.
Last time: 5,70960000ms. Average time: 5.65763100ms.
*/