//---------------------------------------------------------------------------

#ifndef ProgrammH
#define ProgrammH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include "MyVariantTable.h"

using namespace std;

//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TMemo *Memo;
	TButton *TaskDeleteButton;
	TButton *AddButton;
	TButton *Button3;
	TEdit *EditK1;
	TEdit *EditK2;
	TStaticText *StaticText1;
	TStaticText *StaticText2;
	TEdit *EditKey;
	TStaticText *StaticText3;
	TButton *DeleteButton;
	void __fastcall Button3Click(TObject *Sender);
	void __fastcall MemoUpdate(TObject *Sender);
	void __fastcall AddButtonClick(TObject *Sender);
	void __fastcall FormCreate(TObject *Sender);
	void __fastcall DeleteButtonClick(TObject *Sender);
	void __fastcall TaskDeleteButtonClick(TObject *Sender);
	void __fastcall Task(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
