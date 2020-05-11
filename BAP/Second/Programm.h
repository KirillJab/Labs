//---------------------------------------------------------------------------

#ifndef ProgrammH
#define ProgrammH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.Dialogs.hpp>
#include <string>
#include <list>
#include <stdlib.h>
#include <stdio.h>
#include <malloc.h>
#include "Tool.h"

using namespace std;

//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TButton *Add;
	TButton *Load;
	TButton *Sort;
	TButton *Save;
	TButton *Find;
	TButton *Exit;
	TEdit *Name;
	TEdit *Sold;
	TEdit *Available;
	TEdit *Color;
	TEdit *Delivery;
	TEdit *GroupName;
	TButton *Delete;
	TComboBox *ComboBox;
	TMemo *Memo;
	TOpenDialog *OpenDialog1;
	TSaveDialog *SaveDialog1;
	TStaticText *StaticText1;
	TEdit *DeleteEdit;
	TButton *Show;
	void __fastcall AddClick(TObject *Sender);
	void __fastcall LoadClick(TObject *Sender);
	void __fastcall SaveClick(TObject *Sender);
	void __fastcall ExitClick(TObject *Sender);
	void __fastcall SortClick(TObject *Sender);
	void __fastcall ComboBoxSelect(TObject *Sender);
	void __fastcall FindClick(TObject *Sender);
	void __fastcall DeleteClick(TObject *Sender);
	void __fastcall ShowClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
