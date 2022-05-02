using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

  [SerializeField] GameObject Correct;
  [SerializeField] GameObject Incorrect;
  [SerializeField] GameObject Choose;
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
          done=false;
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

    /*
    if(InvManager.Instance.day==1)
    {
      InvManager.Instance.hasWonFirstDay = true;
    }
    if(InvManager.Instance.day==2)
    {
      InvManager.Instance.hasWonSecondDay = true;
    }
    if(InvManager.Instance.day==3)
    {
      InvManager.Instance.hasWonThirdDay = true;
    }
    */

    //increment day by one
    //InvManager.Instance.day=InvManager.Instance.day+1;

    //toggle boolean to indicate user can now leave end day scene
    done=true;
  }

  public void IncorrectChoice()
  {
    done=false;
    Choose.gameObject.SetActive(false);
    Incorrect.gameObject.SetActive(true);

     //increment day by one
    //InvManager.Instance.day=InvManager.Instance.day+1;

     //toggle boolean to indicate user can now leave end day scene
    done=true;
  }

}