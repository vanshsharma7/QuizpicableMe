using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questiontext;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    void Start()
    {
        Display();
    }
    public void OnAnswerSelect(int index)

    {
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
        SetButtonState(false);
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
