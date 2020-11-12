//---------------------------------------------------------------------------

#ifndef _ProgrammH
#define _ProgrammH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.ExtCtrls.hpp>
#include "_Rectangle.h"
#include "_Square.h"
#include "_Ellipse.h"
#include "_Circle.h"
#include "_Triangle.h"

//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TImage *Image;
	TRadioGroup *RadioGroup1;
	TRadioButton *Rectangle;
	TRadioButton *Square;
	TRadioButton *Ellipse;
	TRadioButton *Circle;
	TStaticText *TextX;
	TStaticText *TextY;
	TStaticText *TextX2;
	TStaticText *TextY2;
	TStaticText *PerimetrText;
	TStaticText *AreaText;
	TStaticText *StaticText3;
	TStaticText *StaticText4;
	TEdit *AngleEdit;
	TStaticText *StaticText1;
	TStaticText *StaticText2;
	TStaticText *StaticText5;
	TStaticText *StaticText6;
	TRadioButton *Triangle;
	void __fastcall ImageOnMouseDown(TObject *Sender, TMouseButton Button, TShiftState Shift,
		  int X, int Y);
	void __fastcall ImageMouseUp(TObject *Sender, TMouseButton Button, TShiftState Shift,
		  int X, int Y);
	void __fastcall RectangleClick(TObject *Sender);
	void __fastcall SquareClick(TObject *Sender);
	void __fastcall ImageMouseMove(TObject *Sender, TShiftState Shift, int X, int Y);
	void __fastcall CircleClick(TObject *Sender);
	void __fastcall EllipseClick(TObject *Sender);
	void __fastcall AngleEditChange(TObject *Sender);
	void __fastcall TriangleClick(TObject *Sender);
	void __fastcall FormMouseWheelUp(TObject *Sender, TShiftState Shift, TPoint &MousePos,
          bool &Handled);
	void __fastcall FormMouseWheelDown(TObject *Sender, TShiftState Shift, TPoint &MousePos,
          bool &Handled);







private:	// User declarations
public:		// User declarations
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
