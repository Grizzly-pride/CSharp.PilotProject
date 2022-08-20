using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using static System.Console;
using static System.String;
using static PilotProject.StringMod;
using PilotProject.CustomExeptions;


namespace PilotProject
{
    internal class TableBuilder
    {
        #region Line items
        private const string TopLeftJoint = "┌";
        private const string TopRightJoint = "┐";
        private const string BottomLeftJoint = "└";
        private const string BottomRightJoint = "┘";
        private const string TopJoint = "┬";
        private const string BottomJoint = "┴";
        private const string LeftJoint = "├";
        private const string MiddleJoint = "┼";
        private const string RightJoint = "┤";
        private const string HorizontalLine = "─";
        private const string VerticalLine = "│";
        #endregion

        private string[] _headers;
        private int[] _columnSizes;

        public string[] Headers
        {
            get { return _headers; }
            set
            {
                if (value.Length == _headers.Length)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        _headers[i] = value[i];
                    }
                }
                else
                {
                    throw new ArgumentInvalidRangeException("Argument range is not equiels the table columns count.", value.Length);
                }                
            }
        }
        public int[] ColumnSizes
        {
            get { return _columnSizes; }
            set
            {
                if (value.Length == _columnSizes.Length)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        _columnSizes[i] = value[i];
                    }
                }
                else
                {
                    throw new ArgumentInvalidRangeException("Argument range is not equiels the table columns count.", value.Length);
                }
            }
        }

   
        private StringBuilder _sb = new();     

        public TableBuilder(int columnsCount)
        {
            _headers = new string[columnsCount]; 
            _columnSizes = new int[columnsCount];
        }


        #region Return string
        public string AddHeader()
        {
            _sb.Clear();

            for (int head = 0; head < _headers.Length; head++)
            {
                string text = head switch
                {
                    int i when i == 0 => Concat(VerticalLine, Format("{0," + _columnSizes[head] + "}",
                    _headers[head].StringCut(Math.Abs(_columnSizes[head]))), VerticalLine),

                    int i when i == _headers.Length - 1 => Concat(Format("{0," + _columnSizes[head] + "}",
                    _headers[head]).StringCut(Math.Abs(_columnSizes[head])), VerticalLine),

                    _ => Concat(Format("{0," + _columnSizes[head] + "}",
                    _headers[head].StringCut(Math.Abs(_columnSizes[head]))), VerticalLine)
                };
                _sb.Append(text);
            }
            return _sb.ToString();
        }


        public string AddRow(params object[] items)
        {
            _sb.Clear();
            for (int item = 0; item < items.Length; item++)
            {
                string text = item switch
                {
                    int i when i == 0 => Concat(VerticalLine, Format("{0," + _columnSizes[item] + "}",
                    items[item]).StringCut(Math.Abs(_columnSizes[item])), VerticalLine),

                    _ => Concat(Format("{0," + _columnSizes[item] + "}",
                    items[item]).StringCut(Math.Abs(_columnSizes[item])), VerticalLine)
                };
                _sb.Append(text);
            }
            return _sb.ToString();
        }

        public string AddTopLine() => Line(TopLeftJoint, TopJoint, TopRightJoint);
        public string AddMiddleLine() => Line(LeftJoint, MiddleJoint, RightJoint);
        public string AddEndLine() => Line(BottomLeftJoint, BottomJoint, BottomRightJoint);
        #endregion

        #region Print
        public void PrintHeader()
        {
            WriteLine(AddTopLine(), "\n");

            for (int head = 0; head < _headers.Length; head++)
            {
                string text = head switch
                {
                    int i when i == 0 => Concat(VerticalLine, Format("{0," + _columnSizes[head] + "}",
                    _headers[head].StringCut(Math.Abs(_columnSizes[head]))), VerticalLine),

                    int i when i == _headers.Length -1 => Concat(Format("{0," + _columnSizes[head] + "}",
                    _headers[head]).StringCut(Math.Abs(_columnSizes[head])), VerticalLine, "\n"),

                    _ => Concat(Format("{0," + _columnSizes[head] + "}",
                    _headers[head].StringCut(Math.Abs(_columnSizes[head]))), VerticalLine)
                };
                Write(text);
            }

            WriteLine(AddMiddleLine());
        }


        public void PrintRow(params object[] items)
        {
            for (int item = 0; item < items.Length; item++)
            {
                string text = item switch
                {
                    int i when i == 0 => Concat(VerticalLine, Format("{0," + _columnSizes[item] + "}",
                    items[item]).StringCut(Math.Abs(_columnSizes[item])), VerticalLine),

                    int i when i == _headers.Length - 1 => Concat(Format("{0," + _columnSizes[item] + "}",
                    items[item]).StringCut(Math.Abs(_columnSizes[item])), VerticalLine, "\n"),

                    _ => Concat(Format("{0," + _columnSizes[item] + "}",
                    items[item]).StringCut(Math.Abs(_columnSizes[item])), VerticalLine)
                };
                Write(text);
            }           
        }
        #endregion

        private string Line(string leftJoint, string midleJoint, string rightJoint)
        {
            _sb.Clear();
            
            for (int column = 0; column < _columnSizes.Length; column++)
            {
                int size = Math.Abs(_columnSizes[column]);

                for (int joint = 0; joint <= size; joint++)
                {
                    if (column == 0)
                    {
                        switch (joint)
                        {
                            case 0: _sb.Append(leftJoint); break;
                            case int j when j == size: _sb.Append(HorizontalLine + midleJoint); break;
                            default: _sb.Append(HorizontalLine); break;
                        }
                    }
                    else if (column == _columnSizes.Length-1)
                    {
                        switch (joint)
                        {                         
                            case int j when j == size: _sb.Append(rightJoint); break;
                            default: _sb.Append(HorizontalLine); break;
                        }
                    }
                    else
                    {
                        switch (joint)
                        {
                            case int j when j == size: _sb.Append(midleJoint); break;
                            default: _sb.Append(HorizontalLine); break;
                        }
                    }
                }
            }
            return _sb.ToString();
        }
    }
}