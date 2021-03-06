//---------------------------------------------------------------------------

#ifndef _CircleH
#define _CircleH
#include "_Square.h"
//---------------------------------------------------------------------------

class _Circle : public _Square
{
	public:
	void OnMouseUp (TStaticText*, TStaticText*,TStaticText*, TStaticText*, TCanvas*, int, int) override;
	void OnMouseMove(TStaticText*, TStaticText*, TStaticText*, TStaticText*, TCanvas*, int, int) override;
	void calc() override;
	void scaleUp(TCanvas*) override;
	void scaleDown(TCanvas*) override;
};

#endif
