//---------------------------------------------------------------------------

#ifndef _TriangleH
#define _TriangleH
#include "_Figure.h"
//---------------------------------------------------------------------------

class _Triangle : public Figure
{
	public:
	int x0, y0, xn1, xn2, xn3, yn1, yn2, yn3;
	_Triangle() : Figure(){};

	void OnMouseDown (TStaticText*, TStaticText*, TStaticText*, TStaticText*, int, int) override;
	virtual void OnMouseUp (TStaticText*, TStaticText*,TStaticText*, TStaticText*, TCanvas*, int, int) override;
	virtual void OnMouseMove(TStaticText*, TStaticText*, TStaticText*, TStaticText*, TCanvas*, int, int) override;
	void calc() override;
	void rotate(TCanvas*, int) override;
	void show(TCanvas*);
	void show(TCanvas*, int, int, int, int, int, int);
	void scaleUp(TCanvas*) override;
	void scaleDown(TCanvas*) override;
};

#endif
