//---------------------------------------------------------------------------

#pragma hdrstop

#include "Cargo.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)

Cargo::Cargo (int a, int b, int c, int d, System::Uitypes::TColor color) : CRect(a, b, c, d, color)
{ }

void Cargo::show (TCanvas* Canvas)
{
	Canvas->Pen->Color = clBlack;
	Canvas->Brush->Color = color;
	Canvas->Rectangle(x1, y1, x2, y2);
	Canvas->Brush->Color = clBlack;
	Canvas->MoveTo(x1 + 1, y1);
	Canvas->LineTo(x2 - 1, y2);
	Canvas->MoveTo(x2 - 1, y1);
	Canvas->LineTo(x1 + 1, y2);

}

void Cargo::hide (TCanvas* Canvas)
{
	Canvas->Pen->Color = clWebLightSkyBlue;
	Canvas->Brush->Color = clWebLightSkyBlue;
	Canvas->Rectangle(x1, y1, x2, y2);
}
