//---------------------------------------------------------------------------

#ifndef _EllipseH
#define _EllipseH
#include "_Rectangle.h"
//---------------------------------------------------------------------------

class _Ellipse : public _Rectangle
{
	public:
	void OnMouseUp (TStaticText*, TStaticText*,TStaticText*, TStaticText*, TCanvas*, int, int) override;
	void OnMouseMove(TStaticText*, TStaticText*, TStaticText*, TStaticText*, TCanvas*, int, int) override;
	void calc() override;
	void rotate(TCanvas*, int) override;
	void scaleUp(TCanvas*) override;
	void scaleDown(TCanvas*) override;
};

#endif

