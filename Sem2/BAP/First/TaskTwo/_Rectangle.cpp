//---------------------------------------------------------------------------

#pragma hdrstop

#include "_Rectangle.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)



void _Rectangle::OnMouseDown(TStaticText* TextX, TStaticText* TextY, TStaticText* AreaText, TStaticText* PerimetrText, int X, int Y)
{
	if ((x1 < X && y1 < Y && x2 > X && y2 > Y) || (x2 < X && y2 < Y && x1 > X && y1 > Y) || (x1 < X && y2 < Y && x2 > X && y1 > Y) || (x2 < X && y1 < Y && x1 > X && y2 > Y))
	{
		xm = x2 - X;
		ym = y2 - Y;
		inFigure = true;

		PerimetrText->Caption = perimetr;
		AreaText->Caption = area;
	}
	else
	{
		x1 = X;
		y1 = Y;
		x3 = x1;
		y3 = y1;
		move = true;
		TextX->Caption = X;
		TextY->Caption = Y;
	}
}

void _Rectangle::OnMouseUp(TStaticText* TextX, TStaticText* TextY, TStaticText* AreaText, TStaticText* PerimetrText, TCanvas* Canvas, int X, int Y)
{
	if(!inFigure)
	{
		x2 = X;
		y2 = Y;
		Canvas->Pen->Color = clBlack;
		Canvas->Rectangle(x1, y1, x2, y2);
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

void _Rectangle::OnMouseMove (TStaticText* TextX, TStaticText* TextY, TStaticText* AreaText, TStaticText* PerimetrText, TCanvas* Canvas, int X, int Y)
{
	if(move)
	{
		Canvas->Pen->Color = clWhite;
		Canvas->Rectangle(x1, y1, x3, y3);
		Canvas->Rectangle((x1 + x3) / 2 - 1 , (y1 + y3) / 2 - 1, (x1 + x3) / 2 + 1, (y1 + y3) / 2 + 1);
		x2 = X;
		y2 = Y;
		Canvas->Pen->Color = clBlack;
		Canvas->Rectangle(x1, y1, x2, y2);
		Canvas->Rectangle((x1 + x2) / 2 - 1 , (y1 + y2) / 2 - 1, (x1 + x2) / 2 + 1, (y1 + y2) / 2 + 1);
		x3 = x2;
		y3 = y2;

		calc();
		TextX->Caption = x2;
		TextY->Caption = y2;
		PerimetrText->Caption = perimetr;
		AreaText->Caption = area;
	}
	if(inFigure)
	{
		Canvas->Pen->Color = clWhite;
		Canvas->Rectangle(x1, y1, x3, y3);
		x1 = X - x2 + x1 + xm;
		y1 = Y - y2 + y1 + ym;
		x2 = X + xm;
		y2 = Y + ym;
		Canvas->Pen->Color = clBlack;
		Canvas->Rectangle(x1, y1, x2, y2);
		Canvas->Rectangle((x1 + x2) / 2 - 1 , (y1 + y2) / 2 - 1, (x1 + x2) / 2 + 1, (y1 + y2) / 2 + 1);
		x3 = x2;
		y3 = y2;
	}
}

void _Rectangle::calc()
{
	area = abs((x2 - x1) * (y2 - y1));
	perimetr = abs((x2 - x1) + (y2 - y1)) * 2;
}

void _Rectangle::rotate(TCanvas* Canvas, int angl)
{
	double ang = angl / 180.0 * 3.141590;
	x0 = (x2 + x1) / 2;
	y0 = (y2 + y1) / 2;

	Canvas->Pen->Color = clWhite;
	Canvas->Rectangle(x1, y1, x2, y2);
    Canvas->MoveTo(xn1, yn1);
	Canvas->LineTo(xn2, yn2);
	Canvas->LineTo(xn4, yn4);
	Canvas->LineTo(xn3, yn3);
	Canvas->LineTo(xn1, yn1);

	xn1 = round(x0 + (x1 - x0) * cos(ang) - (y1 - y0) * sin(ang));
	xn2 = round(x0 + (x2 - x0) * cos(ang) - (y1 - y0) * sin(ang));
	xn3 = round(x0 + (x1 - x0) * cos(ang) - (y2 - y0) * sin(ang));
	xn4 = round(x0 + (x2 - x0) * cos(ang) - (y2 - y0) * sin(ang));

	yn1 = round(y0 + (x1 - x0) * sin(ang) + (y1 - y0) * cos(ang));
	yn2 = round(y0 + (x2 - x0) * sin(ang) + (y1 - y0) * cos(ang));
	yn3 = round(y0 + (x1 - x0) * sin(ang) + (y2 - y0) * cos(ang));
	yn4 = round(y0 + (x2 - x0) * sin(ang) + (y2 - y0) * cos(ang));

	Canvas->Pen->Color = clBlack;
	Canvas->MoveTo(xn1, yn1);
	Canvas->LineTo(xn2, yn2);
	Canvas->LineTo(xn4, yn4);
	Canvas->LineTo(xn3, yn3);
	Canvas->LineTo(xn1, yn1);
	Canvas->Rectangle(x0 - 1, y0 - 1, x0 + 1, y0 + 1);
}

void _Rectangle::scaleUp(TCanvas* Canvas)
{
	Canvas->Pen->Color = clWhite;
	Canvas->Rectangle(x1, y1, x2, y2);
	x1 -= 10;
	x2 += 10;
	y1 -= 10;
	y2 += 10;
    Canvas->Pen->Color = clBlack;
	Canvas->Rectangle(x1, y1, x2, y2);
	Canvas->Rectangle((x1 + x2) / 2 - 1 , (y1 + y2) / 2 - 1, (x1 + x2) / 2 + 1, (y1 + y2) / 2 + 1);
}

void _Rectangle::scaleDown(TCanvas* Canvas)
{
	Canvas->Pen->Color = clWhite;
	Canvas->Rectangle(x1, y1, x2, y2);
	x2 -= 10;
	x1 += 10;
	y2 -= 10;
	y1 += 10;
	Canvas->Pen->Color = clBlack;
	Canvas->Rectangle(x1, y1, x2, y2);
	Canvas->Rectangle((x1 + x2) / 2 - 1 , (y1 + y2) / 2 - 1, (x1 + x2) / 2 + 1, (y1 + y2) / 2 + 1);
}
