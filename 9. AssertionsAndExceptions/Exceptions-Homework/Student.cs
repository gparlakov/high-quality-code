using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private string firstName;

    private string lastName;

    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    #region Properties
    
    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(
                    "Passed null or empty  argument \"firstName\"at Student construnctor.");
            }
            
            this.firstName = value;
        }
    }
    
    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(
                    "Passed null or empty argument \"lastName\" at Student construnctor.");
            }
            this.lastName = value;
        }
    }
    
    public IList<Exam> Exams
    {
        get
        {
            IList<Exam> copy = this.GetCopy(this.exams);
            return copy;
        }
        set
        {
            IList<Exam> copy = this.GetCopy(value);
            this.exams = copy;
        }
    }
    
    #endregion
    
    public double CalcAverageResult()
    {
        if (this.Exams == null || this.Exams.Count == 0)
        {
            throw new ArgumentException(
                "Argument this.exams is invalid (null or empty)  at method CalcAverageResult() of the Student class. ");
        }
        
        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                          ((double)examResults[i].Grade - examResults[i].MinGrade) /
                          (examResults[i].MaxGrade - examResults[i].MinGrade);
        }
        
        return examScore.Average();
    }
    
    #region Private Methods
    
    private IList<ExamResult> CheckExams()
    {
        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }
        
        return results;
    }
    
    private IList<Exam> GetCopy(IList<Exam> list)
    {
        //copy of null is still null ;)
        if (list == null)
        {
            return null;
        }
        
        Exam[] copy = new Exam[list.Count];
        list.CopyTo(copy, 0);
        return copy.ToList();
    }

    #endregion
}