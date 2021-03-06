//---------------------------------------------------------------------------

#pragma hdrstop

#include "_Triangle.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
//---------------------------------------------------------------------------

void _Triangle::OnMouseDown(TStaticText* TextX, TStaticText* TextY, TStaticText* AreaText, TStaticText* PerimetrText, int X, int Y)
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

void _Triangle::OnMouseUp(TStaticText* TextX, TStaticText* TextY, TStaticText* AreaText, TStaticText* PerimetrText, TCanvas* Canvas, int X, int Y)
{
	if(!inFigure)
	{
		x2 = X;
		y2 = Y;
		xn1 = x1;
		xn2 = x2;
		xn3 = x1;
		yn1 = y1;
		yn2 = y2;
		yn3 = y2;
		Canvas->Pen->Color = clBlack;
		show(Canvas);

		calc();
		TextX->Caption = x2;
		TextY->Caption = y2;
		PerimetrText->Caption = perimetr;
		AreaText->Caption = area;
	}
	move = false;
	inFigure = false;
}

void _Triangle::OnMouseMove (TStaticText* TextX, TStaticText* TextY, TStaticText* AreaText, TStaticText* PerimetrText, TCanvas* Canvas, int X, int Y)
{
	if(move)
	{
		Canvas->Pen->Color = clWhite;
		show(Canvas, x1, y1, x1, y3, x3, y3);
		x2 = X;
		y2 = Y;
		Canvas->Pen->Color = clBlack;
		show(Canvas);
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
		show(Canvas, x1, y1, x1, y3, x3, y3);
		x1 = X - x2 + x1 + xm;
		y1 = Y - y2 + y1 + ym;
		x2 = X + xm;
		y2 = Y + ym;
		Canvas->Pen->Color = clBlack;
		show(Canvas);
		x3 = x2;
		y3 = y2;
	}
}

void _Triangle::calc()
{
	area = abs((x2 - x1) * (y2 - y1)) / 2;
	perimetr = abs(round((x2 - x1) + (y2 - y1) + sqrt((x2-x1) * (x2-x1) + (y2 - y1) * (y2 - y1))));
}

void _Triangle::rotate(TCanvas* Canvas, int angl)
{
	double ang = angl / 180.0 * 3.141590;
	x0 = (x1 + x2 + x1) / 3;
	y0 = (y2 + y1 + y2) / 3;

	Canvas->Pen->Color = clWhite;
	show(Canvas, xn1, yn1, xn2, yn2, xn3, yn3);

	xn1 = round(x0 + (x1 - x0) * cos(ang) - (y1 - y0) * sin(ang));
	xn2 = round(x0 + (x2 - x0) * cos(ang) - (y2 - y0) * sin(ang));
	xn3 = round(x0 + (x1 - x0) * cos(ang) - (y2 - y0) * sin(ang));
	yn1 = round(y0 + (x1 - x0) * sin(ang) + (y1 - y0) * cos(ang));
	yn2 = round(y0 + (x2 - x0) * sin(ang) + (y2 - y0) * cos(ang));
	yn3 = round(y0 + (x1 - x0) * sin(ang) + (y2 - y0) * cos(ang));

	Canvas->Pen->Color = clBlack;
	show(Canvas, xn1, yn1, xn2, yn2, xn3, yn3);
}

void _Triangle::show(TCanvas* Canvas, int xn1, int yn1, int xn2, int yn2, int xn3, int yn3)
{
	Canvas->MoveTo(xn1, yn1);
	Canvas->LineTo(xn2, yn2);
	Canvas->LineTo(xn3, yn3);
	Canvas->LineTo(xn1, yn1);
	Canvas->FloodFill((xn1 + xn2 + xn3) / 3, (yn1 + yn2 + yn3) / 3, clWhite, fsSurface);
	Canvas->Rectangle((xn1 + xn2 + xn3) / 3 - 1 , (yn1 + yn2 + yn3) / 3 - 1, (xn1 + xn2 + xn3) / 3 + 1, (y1 + y2 + y3) / 3 + 1);
}

void _Triangle::show(TCanvas* Canvas)
{
	Canvas->MoveTo(x1, y1);
	Canvas->LineTo(x1, y2);
	Canvas->LineTo(x2, y2);
	Canvas->LineTo(x1, y1);
	Canvas->FloodFill((x1 + x2 + x1) / 3, (y1 + y2 + y2) / 3, clWhite, fsSurface);
	Canvas->Rectangle((x1 + x2 + x1) / 3 - 1 , (y1 + y2 + y2) / 3 - 1, (x1 + x2 + x1) / 3 + 1, (y1 + y2 + y2) / 3 + 1);
}

void _Triangle::scaleUp(TCanvas* Canvas)
{
	Canvas->Pen->Color = clWhite;
	show(Canvas);
	x1-=10;
	x2+=10;
	y1-=10;
	y2+=10;
	Canvas->Pen->Color = clBlack;
	show(Canvas);
}

void _Triangle::scaleDown(TCanvas* Canvas)
{
	Canvas->Pen->Color = clWhite;
	show(Canvas);
	x2-=10;
	x1+=10;
	y2-=10;
	y1+=10;
	Canvas->Pen->Color = clBlack;
	show(Canvas);
}
