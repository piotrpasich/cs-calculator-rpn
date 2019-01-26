using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator
{
    class CalculationElement
    {
        private string[] allowedChars = new string[] { "+", "-", "*", "/", "^" };

        private string element;

        public CalculationElement(string fromString)
        {
            if (!IsValid(fromString)) {
                throw new Exception("Wrong parameter");
            }

            element = fromString;
        }

        public override string ToString()
        {
            return element;
        }

        public void AddNumber(string fromString)
        {
            if (!IsValid(fromString)) {
                throw new Exception("Wrong parameter");
            }

            element += fromString;
        }

        public bool isOperation()
        {
            return isOperation(element);
        }

        private bool IsValid(string fromString)
        {
            return isOperation(fromString) || isNumber(fromString);
        }

        private bool isOperation(string fromString)
        {
            return allowedChars.Contains(fromString);
        }

        private bool isNumber(string fromString)
        {
            try {
                double.Parse(fromString);
                return true;
            } catch (Exception) {
                return false;
            }
        }
    }

    class StringPresenter
    {
        private List<CalculationElement> elements = new List<CalculationElement>();

        public bool Add(string whatToAdd)
        {
            try {
                if (elements.Count == 0 || elements.Last().isOperation()) {
                    elements.Add(new CalculationElement(whatToAdd));
                } else {
                    elements.Last().AddNumber(whatToAdd);
                }
            } catch (Exception) {
                return false;
            }
            return true;
        }

        public void RemoveLast()
        {
            if (elements.Count > 0) {
                elements.RemoveAt(elements.Count - 1);
            }
        }

        public void Clean()
        {
            elements.Clear();
        }

        public double getResult()
        {
            double result = 0;
            double lastNumber = 0;
            foreach (var item in elements) {
                if (item.isOperation()) {
                    switch (item.ToString()) {
                        case "+":
                            result += lastNumber;
                            break;
                    }
                } else {
                    lastNumber = 0;
                }
            }

            return result;
        }

        override public string ToString()
        {
            string finalString = "";
            foreach (var item in elements) {
                finalString += item.ToString();
            }
            return finalString;
            //return String.Concat(",", elements.Select(x => x.ToString()).ToArray());
        }
    }
}
