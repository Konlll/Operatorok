using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_05_19
{
    internal class Operation
    {
        int operand1;
        string theOperator;
        int operand2;

        public Operation(int operand1, string theOperator, int operand2) {
            this.operand1 = operand1;
            this.theOperator = theOperator;
            this.operand2 = operand2;
        }

        public Operation(string fileRow)
        {
            var fields = fileRow.Split(' ');
            this.operand1 = int.Parse(fields[0]);
            this.theOperator = fields[1];
            this.operand2 = int.Parse(fields[2]);

        }

        public int getOperand1() { return this.operand1; }
        public int getOperand2() { return this.operand2; }
        public string getOperator() { return this.theOperator; }

    }
}
