using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

  [SerializeField] GameObject Correct;
  [SerializeField] GameObject Incorrect;
  [SerializeField] GameObject Choose;
  public int day=1;
  public bool done=false;

  public void Setup()
  {
    //gameObject.setActive(true);
    
  }
  public void Update()
  {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if(done)
        {
          //if clicked any key
          if (Input.anyKey)
          {
          RestartButton();
          }
        }
       
  }

  public void RestartButton()
  {
    //change to second day when second day scene ready
    SceneManager.LoadScene("Town");
  }

  public void CorrectChoice()
  {
    done=false;
    Choose.gameObject.SetActive(false);
    Correct.gameObject.SetActive(true);

    if(day==1)
    {
      InvManager.Instance.hasWonFirstDay = true;
    }
    if(day==2)
    {
      InvManager.Instance.hasWonSecondDay = true;
    }
    if(day==3)
    {
      InvManager.Instance.hasWonThirdDay = true;
    }
    day=day+1;

    done=true;
  }

  public void IncorrectChoice()
  {
    done=false;
    Choose.gameObject.SetActive(false);
    Incorrect.gameObject.SetActive(true);
    day=day+1;

    done=true;
  }

}