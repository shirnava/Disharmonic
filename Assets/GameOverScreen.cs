using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

  

  public void Setup()
  {
    //gameObject.setActive(true);
    
  }
  public void Update()
  {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
  }

  public void RestartButton()
  {
      
    SceneManager.LoadScene("Town");
  }

  public void ExitButton()
  {
    SceneManager.LoadScene("Town");
  }
}