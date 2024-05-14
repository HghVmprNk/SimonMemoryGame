using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public ButtonB[] btns;
    //public Text scoreText;

    //int score = 0;

    static int simonMax;
    static float simonTime;

    static List<int> userList = new List<int>();
    static List<int> simonList = new List<int>();

    public static bool simonIsSaying;

    void Start()
    {
        Instance = this;
        simonMax = 3;
        simonTime = 0.5f;

        StartCoroutine(SimonSays());
    }

    public void PlayerAction(ButtonB b)
    {
        userList.Add(b.id);
        if (userList[userList.Count - 1] != simonList[userList.Count - 1])
        {
            Start();
            Debug.Log("Loose");
        }
        else if (userList.Count == simonList.Count)
        {
            Debug.Log("Next Level");
            StartCoroutine(SimonSays());
        }
        /*if (userList.Count == simonList.Count && AreListsEqual(userList, simonList))
        {
            IncrementScore();
            Debug.Log("Correct sequence score" + score);
        }*/
    }

    IEnumerator SimonSays()
    {
        Debug.Log("Prepare");
        yield return new WaitForSeconds(1);
        simonIsSaying = true;

        simonList.Clear(); // Clear the list before adding new elements
        userList.Clear(); // Clear the list before adding new elements
        userList = new List<int>();
        simonList = new List<int>();

        for (int i = 0; i < simonMax; i++)
        {
            int rand = Random.Range(0, 3);
            simonList.Add(rand);
            btns[rand].Action();

            yield return new WaitForSeconds(simonTime);
        }
        simonTime -= 0.05f;
        simonMax++;
        simonIsSaying = false;
    }
}

