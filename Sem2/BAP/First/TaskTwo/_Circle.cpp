//---------------------------------------------------------------------------

#pragma hdrstop

#include "_Circle.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)

void _Circle::OnMouseUp(TStaticText* TextX, TStaticText* TextY, TStaticText* AreaText, TStaticText* PerimetrText, TCanvas* Canvas, int X, int Y)
{
	if(!inFigure)
	{
		x2 = X;
		y2 = Y;
		if (abs(x2 - x1) > abs(y2 - y1))
		{
			x2 = x1 + y2 - y1;
		}
		else
		{
			y2 = y1 + x2 - x1;
		}
		Canvas->Ellipse(x1, y1, x2, y2);
		Canvas->Rectangle((x1 + x2) / 2 - 1 , (y1 + y2) / 2 - 1, (x1 + x2) / 2 + 1, (y1 + y2) / 2 + 1);

		calc();
		TextX->Caption = x2;
		TextY->Caption = y2;
		PerimetrText->Caption = perimetr;
		AreaText->Caption = area;
	}
	move = false;
	inFigure = false;
}

void _Circle::OnMouseMove (TStaticText* TextX, TStaticText* TextY, TStaticText* AreaText, TStaticText* PerimetrText, TCanvas* Canvas, int X, int Y)
{
	if(move)
	{
		Canvas->Pen->Color = clWhite;
		Canvas->Ellipse(x1, y1, x3, y3);
		Canvas->Rectangle((x1 + x3) / 2 - 1 , (y1 + y3) / 2 - 1, (x1 + x3) / 2 + 1, (y1 + y3) / 2 + 1);
		x2 = X;
		y2 = Y;
		if (abs(x2 - x1) > abs(y2 - y1))
		{
			x2 = x1 + y2 - y1;
		}
		else
		{
			y2 = y1 + x2 - x1;
		}
		Canvas->Pen->Color = clBlack;
		Canvas->Ellipse(x1, y1, x2, y2);
		Canvas->Rectangle((x1 + x2) / 2 - 1 , (y1 + y2) / 2 - 1, (x1 + x2) / 2 + 1, (y1 + y2) / 2 + 1);
		x3 = x2;
		y3 = y2;


		TextX->Caption = x2;
		TextY->Caption = y2;
		PerimetrText->Caption = perimetr;
		AreaText->Caption = area;
	}
	if(inFigure)
	{
		Canvas->Pen->Color = clWhite;
		Canvas->Ellipse(x1, y1, x3, y3);
		x1 = X - x2 + x1 + xm;
		y1 = Y - y2 + y1 + ym;
		x2 = X + xm;
		y2 = Y + ym;
		if (abs(x2 - x1) > abs(y2 - y1))
		{
			x2 = x1 + y2 - y1;
		}
		else
		{
			y2 = y1 + x2 - x1;
		}
		Canvas->Pen->Color = clBlack;
		Canvas->Ellipse(x1, y1, x2, y2);
		Canvas->Rectangle((x1 + x2) / 2 - 1 , (y1 + y2) / 2 - 1, (x1 + x2) / 2 + 1, (y1 + y2) / 2 + 1);
		x3 = x2;
		y3 = y2;
	}
}

void _Circle::calc()
{
	area = abs(3.14159 * (x2 - x1) * (x2 - x1) / 4);
	perimetr = abs(3.14159 * (x2 - x1));
}

void _Circle::scaleUp(TCanvas* Canvas)
{
	Canvas->Pen->Color = clWhite;
	Canvas->Ellipse(x1, y1, x2, y2);
	x1-=10;
	x2+=10;
	y1-=10;
	y2+=10;
	Canvas->Pen->Color = clBlack;
	Canvas->Ellipse(x1, y1, x2, y2);
	Canvas->Rectangle((x1 + x2) / 2 - 1 , (y1 + y2) / 2 - 1, (x1 + x2) / 2 + 1, (y1 + y2) / 2 + 1);
}

void _Circle::scaleDown(TCanvas* Canvas)
{
	Canvas->Pen->Color = clWhite;
	Canvas->Ellipse(x1, y1, x2, y2);
	x1+=10;
	x2-=10;
	y1+=10;
	y2-=10;
	Canvas->Pen->Color = clBlack;
	Canvas->Ellipse(x1, y1, x2, y2);
	Canvas->Rectangle((x1 + x2) / 2 - 1 , (y1 + y2) / 2 - 1, (x1 + x2) / 2 + 1, (y1 + y2) / 2 + 1);
}
