using System;
using Exceptions_Homework;

public class CSharpExam : Exam
{
    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }
        private set
        {
            if (value < 0)
            {
                throw new ExamException("Score from exam can't be negative.", "CSharpExam constructor");
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.Score > 100)
        {
            throw new ExamException("Score from exam can't be bigger than 100.", "ExamResult method in CSharpExam class");
        }

        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");       
    }
}