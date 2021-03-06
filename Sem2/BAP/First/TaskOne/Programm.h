//---------------------------------------------------------------------------

#ifndef ProgrammH
#define ProgrammH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.ExtCtrls.hpp>
#include <vcl.h>
#include "CRect.h"
#include "Cargo.h"
#include "Cart.h"

//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TImage *Image;
	TButton *Button1;
	TButton *Button2;
	TButton *Button3;
	TTimer *Timer;
	TButton *Button4;
	TTimer *CargoTimer;
	TScrollBar *SpeedScrollBar;
	TStaticText *SpeedText;
	void __fastcall TimerTimer(TObject *Sender);
	void __fastcall Button1Click(TObject *Sender);
	void __fastcall Button4Click(TObject *Sender);
	void __fastcall Button3Click(TObject *Sender);
	void __fastcall Button2Click(TObject *Sender);
	void __fastcall CargoTimerTimer(TObject *Sender);
	void __fastcall SpeedScrollBarChange(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
