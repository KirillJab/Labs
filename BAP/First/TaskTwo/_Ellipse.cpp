//---------------------------------------------------------------------------

#pragma hdrstop

#include "_Ellipse.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)


void _Ellipse::OnMouseUp(TStaticText* TextX, TStaticText* TextY, TStaticText* AreaText, TStaticText* PerimetrText, TCanvas* Canvas, int X, int Y)
{
	if(!inFigure)
	{
		x2 = X;
		y2 = Y;
		Canvas->Pen->Color = clBlack;
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

void _Ellipse::OnMouseMove (TStaticText* TextX, TStaticText* TextY, TStaticText* AreaText, TStaticText* PerimetrText, TCanvas* Canvas, int X, int Y)
{
	if(move)
	{
		Canvas->Pen->Color = clWhite;
		Canvas->Ellipse(x1, y1, x3, y3);
		Canvas->Rectangle((x1 + x3) / 2 - 1 , (y1 + y3) / 2 - 1, (x1 + x3) / 2 + 1, (y1 + y3) / 2 + 1);
		x2 = X;
		y2 = Y;
		Canvas->Pen->Color = clBlack;
		Canvas->Ellipse(x1, y1, x2, y2);
		Canvas->Rectangle((x1 + x2) / 2 - 1 , (y1 + y2) / 2 - 1, (x1 + x2) / 2 + 1, (y1 + y2) / 2 + 1);
		x3 = x2;
		y3 = y2;

		TextX->Caption = x2;
		TextY->Caption = y2;
	}
	if(inFigure)
	{
		Canvas->Pen->Color = clWhite;
		Canvas->Ellipse(x1, y1, x3, y3);
		x1 = X - x2 + x1 + xm;
		y1 = Y - y2 + y1 + ym;
		x2 = X + xm;
		y2 = Y + ym;
		Canvas->Pen->Color = clBlack;
		Canvas->Ellipse(x1, y1, x2, y2);
		Canvas->Rectangle((x1 + x2) / 2 - 1 , (y1 + y2) / 2 - 1, (x1 + x2) / 2 + 1, (y1 + y2) / 2 + 1);
		x3 = x2;
		y3 = y2;
	}
}

void _Ellipse::calc()
{
	area = abs(3.14159 * ((x2 - x1) * (y2 - y1)) / 4);
	if((y2 - y1) || (x2 - x1))
		perimetr = abs(4 * 3.14159 * (((x2 - x1) * (y2 - y1)) / 4 + (x2 - x1)/2 - (y2 - y1)/2) / ((x2 - x1)/2 + (y2 - y1)/2));
	else
		perimetr = 0;
}

void _Ellipse::rotate(TCanvas* Canvas, int angl)
{
	double ang = angl;
	int i = 0, xn1, xn2, yn1, yn2, x0, y0;
	if (ang > 0)
	{
		while(ang > 90)
		{
			ang -= 90;
			i++;
		}
	}
	else
	{
		while(ang < -90)
		{
			ang += 90;
			i++;
		}
	}
	if(i%2)
	{
		ang = 3.141590/2;
	}
	else
	{
		ang = 0;
	}
	x0 = (x2 + x1) / 2;
	y0 = (y2 + y1) / 2;

	Canvas->Pen->Color = clWhite;
	Canvas->Rectangle(x1, y1, x2, y2);

	xn1 = round(x0 + (x1 - x0) * cos(ang) - (y1 - y0) * sin(ang));
	xn2 = round(x0 + (x2 - x0) * cos(ang) - (y2 - y0) * sin(ang));
	yn1 = round(y0 + (x1 - x0) * sin(ang) + (y1 - y0) * cos(ang));
	yn2 = round(y0 + (x2 - x0) * sin(ang) + (y2 - y0) * cos(ang));

	x1 = xn1;
	x2 = xn2;
	y1 = yn1;
	y2 = yn2;

	Canvas->Pen->Color = clBlack;
	Canvas->Ellipse(x1, y1, x2, y2);
	Canvas->Rectangle(x0 - 1, y0 - 1, x0 + 1, y0 + 1);
}

void _Ellipse::scaleUp(TCanvas* Canvas)
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

void _Ellipse::scaleDown(TCanvas* Canvas)
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
