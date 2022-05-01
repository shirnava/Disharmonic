using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

  [SerializeField] GameObject Correct;
  [SerializeField] GameObject Incorrect;
  [SerializeField] GameObject Choose;

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

  public void CorrectChoice()
  {
    Choose.gameObject.SetActive(false);
    Correct.gameObject.SetActive(true);

    //if clicked anywhere
    RestartButton();
  }

  public void IncorrectChoice()
  {
    Choose.gameObject.SetActive(false);
    Incorrect.gameObject.SetActive(true);

    //if clicked anywhere
    RestartButton();
  }

}