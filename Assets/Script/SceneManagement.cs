using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void GoToSampleScene()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToUIScene()
    {
        SceneManager.LoadScene(0);
    }
}
