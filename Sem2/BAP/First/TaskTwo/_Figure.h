//---------------------------------------------------------------------------

#ifndef _FigureH
#define _FigureH
#include <vcl.h>
//---------------------------------------------------------------------------

class Figure
{
	public:
	int x1, y1, x2, y2, x3, y3, xm, ym, area, perimetr;
	bool move, inFigure;
	Figure();

	virtual void OnMouseDown(TStaticText*, TStaticText*, TStaticText*, TStaticText*,  int, int);
	virtual void OnMouseMove(TStaticText*, TStaticText*,TStaticText*, TStaticText*, TCanvas*, int, int);
	virtual void OnMouseUp(TStaticText*, TStaticText*,TStaticText*, TStaticText*, TCanvas*, int, int);
	virtual void calc();
	virtual void rotate(TCanvas*, int);
	virtual void scaleUp(TCanvas*);
    virtual void scaleDown(TCanvas*);
};

#endif
