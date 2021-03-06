//---------------------------------------------------------------------------

#pragma hdrstop

#include "Cart.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)

Cart::Cart (int a, int b, int c, int d, int size, System::Uitypes::TColor color) : CRect(a, b, c, d, color)
{
	this->wheelrad = size;
}

void Cart::show (TCanvas* Canvas)
{
	Canvas->Pen->Color = clBlack;
	Canvas->Brush->Color = color;
	Canvas->Rectangle(x1, y1, x2, y2);
	Canvas->Brush->Color = clMedGray;
	Canvas->Rectangle(x1, y1 - 100, x1 + 5, y1);
	Canvas->Rectangle(x1 - 13, y1 - 100, x1 + 5, y1 - 95);
	Canvas->Brush->Color = clBlack;
	Canvas->Ellipse(x1 - wheelrad, y2 - wheelrad * 2, x1 + wheelrad * 3, y2 + wheelrad * 2);
	Canvas->Ellipse(x2 - wheelrad * 3, y2 - wheelrad * 2, x2 + wheelrad, y2 + wheelrad * 2);
}

void Cart::hide (TCanvas* Canvas)
{
	Canvas->Pen->Color=clWebLightSkyBlue;
	Canvas->Brush->Color = clWebLightSkyBlue ;
	Canvas->Rectangle(0, 0, 900, 430);
	Canvas->Pen->Color=clWebYellowGreen;
	Canvas->Brush->Color = clWebYellowGreen;
	Canvas->Rectangle(0, 430, 900, 500);
}

void Cart::moveto (int a, int b, int c, int d)
{
	if(x1 + a > wheelrad)
	{
		x1 += a;
	}
	else
	{
		if(x1 == wheelrad)
		{
			x1 = wheelrad;
			x2 -= c;
		}
		else
		{
			x1 = wheelrad;
			x2 -= x1 - wheelrad;
        }
	}
	if(y1 + b > 0)
	{
		y1 += b;
	}
	else
	{
		y1 = 0;
		y2 -= d;
	}
	if(x2 + c < 900 - wheelrad)
	{
		x2 += c;
	}
	else
	{
		if(x2 == 900 - wheelrad)
		{
			x2 = 900 - wheelrad;
			x1 -= a;
		}
		else
		{
			x2 = 900 - wheelrad;
			x1 -= x2 - 900 + wheelrad;
		}
	}
	if(y2 + d < 500)
	{
		y2+=d;
	}
	else
	{
		y2=500;
		y1 -= b;
	}
}

