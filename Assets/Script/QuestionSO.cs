using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Quiz Question",fileName = "New Question")]
public class QuestionSO : ScriptableObject 
{
    [TextArea(2,4)]
    [SerializeField] string question="Enter question here :^)";
    public string GetQuestion(){
        return question;
    }
}

