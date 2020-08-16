using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control2 : MonoBehaviour
{
    public List<Button> btns1 = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
        GetButtons();
        AddListeners();
    }

    private void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Main2 Button");
        for (int i = 0; i < objects.Length; i++)
        {
            btns1.Add(objects[i].GetComponent<Button>());
        }
    }

    private void AddListeners()
    {
        foreach (Button btn in btns1)
        {
            btn.onClick.AddListener(() => doExitGame());

        }

    }


    void doExitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
