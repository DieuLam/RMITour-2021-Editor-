using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void UI()
    {
        SceneManager.LoadScene(0);
    }
    public void ARNavigation()
    {
        SceneManager.LoadScene(1);
    }
    public void ScanRoom()
    {
        SceneManager.LoadScene(2);
    }
    public void view360()
    {
        SceneManager.LoadScene(3);
    }
    public void roomview(){
        SceneManager.LoadScene(7);
    }
    public void officeview(){
        SceneManager.LoadScene(8);
    }
    public void maclabview(){
        SceneManager.LoadScene(9);
    }
}
