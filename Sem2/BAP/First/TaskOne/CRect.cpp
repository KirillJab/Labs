//---------------------------------------------------------------------------

#pragma hdrstop

#include "CRect.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)

CRect::CRect(int x1, int y1, int x2, int y2, System::Uitypes::TColor color)
{
	this->x1 = x1;
	this->y1 = y1;
	this->x2 = x2;
	this->y2 = y2;
	this->color = color;
}

void CRect::hide (TCanvas* Canvas)
{
	Canvas->Pen->Color = clWhite;
	Canvas->Brush->Color = clWhite;
	Canvas->Rectangle(x1, y1, x2, y2);
}

void CRect::show (TCanvas* Canvas)
{
	Canvas->Pen->Color = clBlack;
	Canvas->Brush->Color = color;
	Canvas->Rectangle(x1, y1, x2, y2);
}

void CRect::moveto (int a, int b, int c, int d)
{
	x1 += a;
	y1 += b;
	x2 += c;
	y2 += d;
}

void CRect::move (TCanvas* Canvas, int a, int b, int c, int d)
{
	this->hide(Canvas);
	this->moveto(a, b, c, d);
	this->show(Canvas);
}

