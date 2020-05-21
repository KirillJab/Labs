

#include <vcl.h>
#pragma hdrstop

#include "Programm.h"

#pragma package(smart_init)
#pragma resource "*.dfm"

TForm1 *Form1;
float a, b, c, d, e;

bool IsVar(char ch)
{
	if (96 < ch && ch < 102)
	{
		return true;
	}
	return false;
}

int IsOper(char ch)
{
	if (ch == '+' || ch == '-')
	{
		return 1;
	}
	if (ch == '*' || ch == '/')
	{
		return 2;
	}
	if (ch == '(')
	{
		return 3;
	}
	if( ch == ')')
	{
		return 4;
	}
    if( ch == ']')
	{
		return 5;
	}
	return 0;
}

float GetValue(char ch)
{
	switch(ch)
	{
		case 'a':
		{
			return a;
			break;
		}
		case 'b':
		{
			return b;
			break;
		}
		case 'c':
		{
			return c;
			break;
		}
		case 'd':
		{
			return d;
			break;
		}
		case 'e':
		{
			return e;
			break;
		}
	}
}

float Calc(float a, float b, char ch)
{
switch(ch)
	{
		case '+':
		{
			return a + b;
			break;
		}
		case '-':
		{
			return a - b;
			break;
		}
		case '*':
		{
			return a * b;
			break;
		}
		case '/':
		{
			if (b != 0)
			{
				return a / b;
			}
			throw 1; //Division by zero
			break;
		}
	}
}
//		'abc*+de-/'
float Calculate(string inp)
{
	Stack vars;
	Stack ops;
	float result = 0;
	char A, B;
	float a, b;

	for (int i = 0; i < inp.length(); i++)
	{
		if(IsVar(inp[i]))
		{
			vars.Push(inp[i]);
		}
		else
		{
			b = GetValue(vars.Back()->Value);
			vars.Pop();
			a = GetValue(vars.Back()->Value);
			vars.Pop();
			vars.Push(Calc(a, b, inp[i]));
		}
	}
	return vars.Back()->Value - 48;
}

AnsiString Convert(string inp)
{
	Stack ops;
	AnsiString str;
	int brackets = 0;

	inp += ']';

	for (int i = 0; i < inp.length(); i++)
	{
		if(IsVar(inp[i]))
		{
			str += inp[i];
		}
		else
		{
			switch(IsOper(inp[i]))
			{
				case 1:// '+' || '-'
				{
					if(!ops.Empty() && ops.Back()->Value != '(')
					{
						str += ops.Back()->Value;
						ops.Pop();
					}
					ops.Push(inp[i]);
					break;
				}
				case 2:// '*' || '/'
				{
					if(!ops.Empty() && ops.Back()->Value != '(')
					{
						if(IsOper(ops.Back()->Value) == 2)
						{
							str += ops.Back()->Value;
							ops.Pop();
						}
					}
					ops.Push(inp[i]);
					break;
				}
				case 3:// '('
				{
					ops.Push(inp[i]);
					brackets++;
					break;
				}
				case 4:// ')'
				{
					if(!ops.Empty() && brackets != 0)
					{
						while(ops.Back()->Value != '(' && !ops.Empty())
						{
							str += ops.Back()->Value;
							ops.Pop();
						}
					}
					else
					{
						ShowMessage("Invalid Input"); //Uneven number of brackets
						throw 8;
					}
					break;
				}
				case 5:// End symbol
				{
					while(!ops.Empty())
					{
						if(ops.Back()->Value != '(')
						{
							str += ops.Back()->Value;
						}
						ops.Pop();
					}
					break;
				}
				default:
				{
					ShowMessage("Invalid Input"); //No such variable or operator available
					throw 8;
					break;
				}
			}
		}
	}
	delete ops.Tail;
	return str;
}

__fastcall TForm1::TForm1(TComponent* Owner) : TForm(Owner)
{

}

void __fastcall TForm1::FillVariantButtonClick(TObject *Sender)
{
	a = 9.1;
	b = 0.6;
	c = 2.4;
	d = 3.7;
	e = 8.5;
	AEdit->Text = "9.1";
	BEdit->Text = "0.6";
	CEdit->Text = "2.4";
	DEdit->Text = "3.7";
	EEdit->Text = "8.5";
	Task->Text = "(a+b*c)/(d-e)";
}
void __fastcall TForm1::SolveButtonClick(TObject *Sender)
{
	Notation->Text = Convert(((AnsiString)Task->Text).c_str());
	Result->Text = Calculate(((AnsiString)Notation->Text).c_str());

}
