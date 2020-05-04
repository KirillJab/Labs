//---------------------------------------------------------------------------

#ifndef _SquareH
#define _SquareH
#include "_Rectangle.h"
//---------------------------------------------------------------------------

class _Square : public _Rectangle
{
    public:
	void OnMouseUp (TStaticText*, TStaticText*,TStaticText*, TStaticText*, TCanvas*, int, int) override;
	void OnMouseMove(TStaticText*, TStaticText*, TStaticText*, TStaticText*, TCanvas*, int, int) override;

};

#endif
