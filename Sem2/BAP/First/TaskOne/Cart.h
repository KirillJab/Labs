//---------------------------------------------------------------------------

#ifndef CartH
#define CartH
#include "CRect.h"
//---------------------------------------------------------------------------


class Cart : public CRect
{
	int wheelrad, length;
	public:
	Cart(int, int, int, int, int, System::Uitypes::TColor);
	void show (TCanvas* Canvas) override;
	void hide (TCanvas* Canvas) override;
    virtual void moveto (int, int, int, int) override;
};
#endif
