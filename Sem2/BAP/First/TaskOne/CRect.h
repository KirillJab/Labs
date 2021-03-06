﻿//---------------------------------------------------------------------------
#include <vcl.h>
#ifndef CRectH
#define CRectH
//---------------------------------------------------------------------------
using namespace std;
class CRect
{
	public:
		int x1, y1, x2, y2;
		System::Uitypes::TColor color;
		CRect(int, int, int, int, System::Uitypes::TColor);
		virtual void hide(TCanvas*);
		virtual void moveto(int, int, int, int);
		virtual void show(TCanvas*);
		virtual void move(TCanvas*, int, int, int, int);
};
#endif
