using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    // [Header("Questions")]
    [SerializeField] TextMeshProUGUI questiontext;
    [SerializeField] QuestionSO question;
    // [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly;
    // [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    // [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        GetNextQuestion();
        // Display();
    }
    void Update(){
        timerImage.fillAmount=timer.fillFraction;
        if(timer.loadNextQuestion){
            hasAnsweredEarly=false;
            GetNextQuestion();
            timer.loadNextQuestion=false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion){
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
    public void OnAnswerSelect(int index)

    {
        hasAnsweredEarly=true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.cancelTimer();
    }
    void DisplayAnswer(int index){
        Image buttonImage;
        if(index==question.GetCorrectAnswerIndex()){
            questiontext.text="Correct";
            buttonImage=answerButtons[index].GetComponent<Image>();
            buttonImage.sprite=correctAnswerSprite;
        }
        else{
            correctAnswerIndex=question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questiontext.text = "Oops, the correct answer was :\n"+ correctAnswer;
            buttonImage=answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite=correctAnswerSprite;
        }
    }
    void GetNextQuestion(){
        SetButtonState(true);
        SetDefaultButtonSprite();
        Display();
    }
    void Display(){
        questiontext.text=question.GetQuestion();
        for(int i=0;i<answerButtons.Length;i++){
            TextMeshProUGUI buttonText=answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text=question.GetAnswer(i);
        }
    } 
    void SetButtonState(bool state){
        for(int i=0;i<answerButtons.Length;i++){
            Button button=answerButtons[i].GetComponent<Button>();
            button.interactable=state;
        }
    }
    void SetDefaultButtonSprite(){
        for(int i=0;i<answerButtons.Length;i++){
            Image buttonImage=answerButtons[i].GetComponent<Image>();
            buttonImage.sprite=defaultAnswerSprite;
        }
    }
}
