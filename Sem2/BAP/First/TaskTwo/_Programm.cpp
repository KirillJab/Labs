

#include <vcl.h>
#pragma hdrstop

#include "_Programm.h"

#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
_Rectangle rec;
_Square sq;
_Ellipse ell;
_Circle circ;
_Triangle trig;

int X1, Y1, X2, Y2, X3, Y3, XM, YM, choice = 1;
bool move = false, inFigure = false;

__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{
	Image->Canvas->Pen->Color = clBlack;
}

void __fastcall TForm1::ImageOnMouseDown(TObject *Sender, TMouseButton Button, TShiftState Shift, int X, int Y)
{
	switch(choice)
		{
			case 1:
			{
				rec.OnMouseDown(TextX, TextY, AreaText, PerimetrText, X, Y);
				break;
			}
			case 2:
			{
				sq.OnMouseDown(TextX, TextY, AreaText, PerimetrText, X, Y);
				break;
			}
			case 3:
			{
				ell.OnMouseDown(TextX, TextY, AreaText, PerimetrText, X, Y);
				break;
			}
			case 4:
			{
				circ.OnMouseDown(TextX, TextY, AreaText, PerimetrText, X, Y);
				break;
			}
			case 5:
			{
				trig.OnMouseDown(TextX, TextY, AreaText, PerimetrText, X, Y);
				break;
			}
		}
}

void __fastcall TForm1::ImageMouseUp(TObject *Sender, TMouseButton Button, TShiftState Shift, int X, int Y)
{
	switch(choice)
		{
			case 1:
			{
				rec.OnMouseUp(TextX2, TextY2, AreaText, PerimetrText, Image->Canvas, X, Y);
				break;
			}
			case 2:
			{
				sq.OnMouseUp(TextX2, TextY2, AreaText, PerimetrText, Image->Canvas, X, Y);
				break;
			}
			case 3:
			{
				ell.OnMouseUp(TextX2, TextY2, AreaText, PerimetrText, Image->Canvas, X, Y);
				break;
			}
			case 4:
			{
				circ.OnMouseUp(TextX2, TextY2, AreaText, PerimetrText, Image->Canvas, X, Y);
				break;
			}
			case 5:
			{
				trig.OnMouseUp(TextX2, TextY2, AreaText, PerimetrText, Image->Canvas, X, Y);
				break;
			}
		}
}

void __fastcall TForm1::ImageMouseMove(TObject *Sender, TShiftState Shift, int X,
		  int Y)
{
	switch(choice)
	{
		case 1:
		{
			rec.OnMouseMove(TextX2, TextY2, AreaText, PerimetrText, Image->Canvas, X, Y);
			break;
		}
		case 2:
		{
			sq.OnMouseMove(TextX2, TextY2, AreaText, PerimetrText, Image->Canvas, X, Y);
			break;
		}
		case 3:
		{
			ell.OnMouseMove(TextX2, TextY2, AreaText, PerimetrText, Image->Canvas, X, Y);
			break;
		}
		case 4:
		{
			circ.OnMouseMove(TextX2, TextY2, AreaText, PerimetrText, Image->Canvas, X, Y);
			break;
		}
		case 5:
		{
			trig.OnMouseMove(TextX2, TextY2, AreaText, PerimetrText, Image->Canvas, X, Y);
			break;
		}
	}
}

void __fastcall TForm1::AngleEditChange(TObject *Sender)
{
	if(AngleEdit->Text != "")
	{
		int ang;
		ang = AngleEdit->Text.ToInt();

		switch(choice)
		{
			case 1:
			{
				rec.rotate(Image->Canvas, ang);
				break;
			}
			case 2:
			{
				sq.rotate(Image->Canvas, ang);
				break;
			}
			case 3:
			{
				ell.rotate(Image->Canvas, ang);
				break;
			}
			case 4:
			{

				break;
			}
			case 5:
			{
				trig.rotate(Image->Canvas, ang);
				break;
			}
		}
	}
}

void __fastcall TForm1::FormMouseWheelUp(TObject *Sender, TShiftState Shift, TPoint &MousePos,
		  bool &Handled)
{
	switch(choice)
	{
		case 1:
		{
			rec.scaleUp(Image->Canvas);
			break;
		}
		case 2:
		{
			sq.scaleUp(Image->Canvas);
			break;
		}
		case 3:
		{
			ell.scaleUp(Image->Canvas);
			break;
		}
		case 4:
		{
			circ.scaleUp(Image->Canvas);
			break;
		}
		case 5:
		{
			trig.scaleUp(Image->Canvas);
			break;
		}
	}
}

void __fastcall TForm1::FormMouseWheelDown(TObject *Sender, TShiftState Shift, TPoint &MousePos,
		  bool &Handled)
{
	switch(choice)
	{
		case 1:
		{
			rec.scaleDown(Image->Canvas);
			break;
		}
		case 2:
		{
			sq.scaleDown(Image->Canvas);
			break;
		}
		case 3:
		{
			ell.scaleDown(Image->Canvas);
			break;
		}
		case 4:
		{
			circ.scaleDown(Image->Canvas);
			break;
		}
		case 5:
		{
			trig.scaleDown(Image->Canvas);
			break;
		}
	}
}

void __fastcall TForm1::RectangleClick(TObject *Sender)
{
	choice = 1;
}

void __fastcall TForm1::SquareClick(TObject *Sender)
{
	choice = 2;
}

void __fastcall TForm1::EllipseClick(TObject *Sender)
{
	choice = 3;
}

void __fastcall TForm1::CircleClick(TObject *Sender)
{
	choice = 4;
}

void __fastcall TForm1::TriangleClick(TObject *Sender)
{
	choice = 5;
}


