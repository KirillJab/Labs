//---------------------------------------------------------------------------

#pragma hdrstop

#include "_Figure.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)

Figure::Figure()
{
	this->x1 = this->x2 = this->x3 = this->xm = this->y1 = this->y2 = this->y3 = this->ym = 0;
	this->inFigure = false;
	this->move = false;
}

void Figure::OnMouseDown(TStaticText* TextX, TStaticText* TextY, TStaticText* AreaText, TStaticText* PerimetrText,  int X, int Y)
{
	if(x1 < X && y1 < Y && x2 > X && y2 > Y)
	{
		xm = x2 - X;
		ym = y2 - Y;
		inFigure = true;
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


void Figure::OnMouseMove(TStaticText* TextX, TStaticText* TextY, TStaticText* AreaText, TStaticText* PerimetrText, TCanvas* Canvas, int x, int y)
{

}
void Figure::OnMouseUp(TStaticText* TextX, TStaticText* TextY, TStaticText* AreaText, TStaticText* PerimetrText, TCanvas* Canvas, int x, int y)
{

}
void Figure::calc()
{

}
void Figure::rotate(TCanvas* Canvas, int ang)
{

}
void Figure::scaleUp(TCanvas* Canvas)
{
	x1-=10;
	x2+=10;
	y1-=10;
	y2+=10;
}
void Figure::scaleDown(TCanvas* Canvas)
{
	x2-=10;
	x1+=10;
	y2-=10;
	y1+=10;
}


