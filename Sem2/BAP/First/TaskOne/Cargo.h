//---------------------------------------------------------------------------
#include "CRect.h"
#ifndef CargoH
#define CargoH
//---------------------------------------------------------------------------

class Cargo : public CRect
{
	public:
	Cargo (int, int, int, int, System::Uitypes::TColor);
	void show (TCanvas* Canvas) override;
    void hide (TCanvas* Canvas) override;
};
#endif
