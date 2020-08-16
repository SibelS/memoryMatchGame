
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;
    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<Button> btns = new List<Button>();


    private bool firsGuess;
    private bool secondGuess;
    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;
    private int firsGuessIndex, secondGuessIndex;
    private string firstGuessPuzzle, secondGuessPuzzle;
    AudioSource effect = new AudioSource();

  

    private void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        gameGuesses = gamePuzzles.Count / 2;
       effect=GetComponent<AudioSource>();
    }
    private void Awake()
    {
        //uzzles = Resources.LoadAll<Sprite>("Sprites/Icons");
        puzzles= Resources.LoadAll<Sprite>("Sprites/Icons");

    }

    void GetButtons()
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Puzzle Button");
        
        for (int i = 0; i < objects.Length; i++) {
                btns.Add(objects[i].GetComponent<Button>());
                btns[i].image.sprite = bgImage;
            }
      
        }
    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
    void AddListeners() {
            foreach (Button btn in btns)
            {
                btn.onClick.AddListener(() => PickAPuzzle());
            btn.onClick.AddListener(() => effect.Play());
            }
        }
        void AddGamePuzzles() {
        {
            int looper = btns.Count;
            int index = 0;
            for (int i = 0; i < looper; i++)
            {

                if (index == looper / 2) { index = 0; }

                gamePuzzles.Add(puzzles[index]);
                index++;
            }
        }Shuffle(gamePuzzles);
        }
        public void PickAPuzzle()
        {

            if (!firsGuess)
            {
                firsGuess = true;
                firsGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
                firstGuessPuzzle = gamePuzzles[firsGuessIndex].name;
                btns[firsGuessIndex].image.sprite = gamePuzzles[firsGuessIndex];
            }
            else if (!secondGuess) {
                secondGuess = true;
                secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
                secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
                btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];
                countGuesses++;
                StartCoroutine(CheckIfThePuzzlesMatch());
            }
        }

        IEnumerator CheckIfThePuzzlesMatch()
        {
            yield return new WaitForSeconds(1f);
            if (firstGuessPuzzle == secondGuessPuzzle)
            {
                yield return new WaitForSeconds(.5f);

                btns[firsGuessIndex].interactable = false;
                btns[secondGuessIndex].interactable = false;

                btns[firsGuessIndex].image.color = new Color(0, 0, 0, 0);
                btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
                CheckIfTheGameIsFinished();
            }
            else
            {
                yield return new WaitForSeconds(.5f);
                btns[firsGuessIndex].image.sprite = bgImage;
                btns[secondGuessIndex].image.sprite = bgImage;
            }
            yield return new WaitForSeconds(.5f);
            firsGuess = secondGuess = false;
        }

        private void CheckIfTheGameIsFinished()
        {
            countCorrectGuesses++;
            if (countCorrectGuesses == gameGuesses)
            {
                Debug.Log("Game finished");
                Debug.Log("It took you" + countGuesses + "many guesses to finish the game");
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

    }


