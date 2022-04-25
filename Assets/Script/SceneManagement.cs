using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void ARNavigation()
    {
        SceneManager.LoadScene(1);
    }
    public void UI()
    {
        SceneManager.LoadScene(0);
    }
    public void ImageTracking()
    {
        SceneManager.LoadScene(2);
    }
}
