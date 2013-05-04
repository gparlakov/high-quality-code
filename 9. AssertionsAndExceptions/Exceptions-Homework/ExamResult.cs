using System;
using Exceptions_Homework;

public class ExamResult
{
    private int grade;

    private int minGrade;

    private int maxGrade;

    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }
        private set
        {
            if (value < 0)
            {
                throw new ExamException("Grade of exam can't be negative", "Constructor ExamResult");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }
        private set
        {
            if (value < 0)
            {
                throw new ExamException("Minimal grade for exam can't be negative", "Constructor ExamResult");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }
        private set
        {
            if (value <= this.minGrade)
            {
                throw new ExamException("Maximal grade for exam can't be negative", "Constructor ExamResult");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }
        private set
        {
            if (value == null || value == String.Empty)
            {
                throw new ExamException("Comment can't be null or empty", "Constructor ExamResult");
            }

            this.comments = value;
        }
    }
}