//---------------------------------------------------------------------------

#ifndef ProgrammH
#define ProgrammH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.Grids.hpp>
#include <Vcl.ComCtrls.hpp>
#include "Tree.h"
#include <Vcl.ExtCtrls.hpp>
#include <Vcl.Imaging.jpeg.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TStringGrid *StringGrid;
	TTreeView *TreeView;
	TMemo *Memo;
	TEdit *NameEdit;
	TEdit *KeyEdit;
	TButton *Add;
	TButton *Delete;
	TButton *ShowAs;
	TButton *Find;
	TImage *LineImage;
	TRadioGroup *RadioGroup;
	TRadioButton *RadioButton2;
	TRadioButton *RadioButton1;
	TRadioButton *RadioButton3;
	TButton *Task;
	void __fastcall AddClick(TObject *Sender);
	void __fastcall ShowAsClick(TObject *Sender);
	void __fastcall RadioButton2Click(TObject *Sender);
	void __fastcall RadioButton1Click(TObject *Sender);
	void __fastcall RadioButton3Click(TObject *Sender);
	void __fastcall FindClick(TObject *Sender);
	void __fastcall DeleteClick(TObject *Sender);
	void __fastcall TaskEvent(TObject *Sender);
	void __fastcall TaskClick(TObject *Sender);
	void __fastcall BalanceClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
