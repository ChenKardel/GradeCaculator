using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeApp
{
    public class Subject : IEnumerable
    {
        private string _className;
        private int _grade;
        private bool _isCompulsory;
        private double _credit;
        private string _description;
        public string ClassName
        {
            get => _className;
            set => _className = value;
        }

        public int Grade
        {
            get => _grade;
            set => _grade = value;
        }

        public bool IsCompulsory
        {
            get => _isCompulsory;
            set => _isCompulsory = value;
        }

        public double Credit
        {
            get => _credit;
            set => _credit = value;
        }
        public string Description { get => _description; set => _description = value; }

        public Subject()
        {
        }

        public Subject(string className, int grade, bool isCompulsory, int credit, string description)
        {
            _className = className;
            _grade = grade;
            _isCompulsory = isCompulsory;
            _credit = credit;
            Description = description;
        }

        public double GetMultiply()
        {
            return this.Credit * this.Grade;
        }

        public override string ToString()
        {
            return this.ClassName + "   " + this.Grade + "   " + this.Credit + "   " + this.IsCompulsory + "   " +
                   this.Description;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
