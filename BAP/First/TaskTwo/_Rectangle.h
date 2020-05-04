//---------------------------------------------------------------------------

#ifndef _RectangleH
#define _RectangleH
#include "_Figure.h"
//---------------------------------------------------------------------------

class _Rectangle : public Figure
{
	int x0, y0, xn1, xn2, xn3, xn4, yn1, yn2, yn3, yn4;
	public:
	_Rectangle() : Figure(){};

	void OnMouseDown (TStaticText*, TStaticText*, TStaticText*, TStaticText*, int, int) override;
	virtual void OnMouseUp (TStaticText*, TStaticText*,TStaticText*, TStaticText*, TCanvas*, int, int) override;
	virtual void OnMouseMove(TStaticText*, TStaticText*, TStaticText*, TStaticText*, TCanvas*, int, int) override;
	void calc() override;
	void rotate(TCanvas*, int) override;
	void scaleUp(TCanvas*) override;
	void scaleDown(TCanvas*) override;
};

#endif
