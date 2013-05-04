using System;
using System.Diagnostics;
using Exceptions_Homework;

public class SimpleMathExam : Exam
{
    private const int DefaultMaxProblems = 10;
    private const int DefaultMinGrade = 2;
    private const int DefaultMaxGrade = 6;      
    
    private int problemsSolved;

    private int maxProblems;

    private int minGrade;

    private int maxGrade;

    public SimpleMathExam(int problemsSolved, int maxProblems = DefaultMaxProblems,
        int minGrade = DefaultMinGrade, int maxGrade = DefaultMaxGrade)
    {
        this.MaxProblems = maxProblems;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;   
        this.ProblemsSolved = problemsSolved;             
    }

    #region Properties
    public int MaxProblems
    {
        get
        {
            return this.maxProblems;
        }
        set
        {
            if (value < 0)
            {
                throw new ExamException("Maximum number of problems solved cant be negative",
                    "SimpleMathExam Constructor", "maxProblems");
            }
            this.maxProblems = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }
        set
        {
            if (value < 0)
            {
                throw new ExamException("Minimal grade can't be negative.",
                    "SimpleMathExam constructor", "minGrade");
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
        set
        {
            if (value <= this.minGrade)
            {
                throw new ExamException("Maximal grade can't less than or equal to minimal grade",
                    "SimpleMathExam constructor", "maxGrade");
            }
            this.maxGrade = value;
        }
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }
        private set
        {
            if (value < 0 || value > this.MaxProblems)
            {
                var exMessage = string.Format(
                    "Number of solved tasks should be between 0 and {0}.",
                    this.MaxProblems);
                throw new ExamException(exMessage, "SimpleMathExam Construnctor");
            }
            this.problemsSolved = value;
        }
    }

    #endregion

    public override ExamResult Check()
    { 
        double percentegeSolved = (double)this.ProblemsSolved / (double)this.MaxProblems;
        double finalGrade = Math.Floor(this.MinGrade + percentegeSolved * (this.MaxGrade - this.MinGrade));
        string comment = this.GenerateComment(finalGrade, this.MinGrade, this.MaxGrade);
        ExamResult result = new ExamResult((int)finalGrade, this.MinGrade, this.MaxGrade, comment);
        return result;
    }

    private string GenerateComment(double grade, double minGrade, double maxGrade)
    {
        Debug.Assert(minGrade < maxGrade, "Passed maxGrade >= minGrade in GenerateComment method. ");
        double difference = maxGrade - minGrade;
        string comment = null ;
        if (grade == minGrade)
        {
            comment = "Bad result: nothing done.";
        }
        else if (grade < (minGrade + difference / 2))
        {
            comment = "low result: something done.";
        }
        else if (grade < (minGrade + 3 * difference / 4))
        {
            comment = "average results: mostly done.";
        }
        else if (grade < maxGrade)
        {
            comment = "Hight results: mostly done.";
        }
        else if (grade == maxGrade)
        {
            comment = "Exceptional results: everything done ";
        }

        Debug.Assert(comment != null && comment != string.Empty, "Metod GenerateComment failed to generate comment ");

        return comment;
    }
}