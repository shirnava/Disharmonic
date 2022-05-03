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
  public bool correct;
  public bool incorrect;
  public Day_Vote_Tracker tracker;


    public void Setup()
  {
    //gameObject.setActive(true);
    
  }
    void Start()
    {
        tracker = GameObject.Find("DayTracker").GetComponent<Day_Vote_Tracker>();

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
    if (tracker.day == 1)
        {
            SceneManager.LoadScene("Town");
        }
        else if (tracker.day == 2)
        {
           SceneManager.LoadScene("OutroCutscene");

          // if(tracker.correctVotes == 2)
          // {
          //   //good ending scene
          //    SceneManager.LoadScene("");
          // }
          // else
          // {
          //   //bad ending scene
          //    SceneManager.LoadScene("");
          // }
        }
  }

  public void CorrectChoice()
  {
    done=false;
    Choose.gameObject.SetActive(false);
    Correct.gameObject.SetActive(true);
        correct = true;

        tracker.correctVotes += 1;
        tracker.day += 1;

        //increment day by one
        //InvManager.Instance.day=InvManager.Instance.day+1;

        //toggle boolean to indicate user can now leave end day scene
        done = true;
  }

  public void IncorrectChoice()
  {
    done=false;
    Choose.gameObject.SetActive(false);
    Incorrect.gameObject.SetActive(true);

    incorrect = true;

    tracker.day += 1;


        //increment day by one
        //InvManager.Instance.day=InvManager.Instance.day+1;

        //toggle boolean to indicate user can now leave end day scene
        done = true;
  }

}