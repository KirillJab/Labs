//---------------------------------------------------------------------------

#ifndef ProgrammH
#define ProgrammH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <malloc.h>
#include "List.h"

using namespace std;
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TListBox *ListBox;
	TButton *InsertButton;
	TButton *ExitButton;
	TButton *ChooseButton;
	TMemo *MemoBuff;
	TButton *ChangeButton;
	TButton *PushButton;
	TButton *PopButton;
	TButton *CheckEmptyButton;
	TEdit *QueueEdit;
	void __fastcall ListBoxClick(TObject *Sender);
	void __fastcall ChooseButtonClick(TObject *Sender);
	void __fastcall InsertButtonClick(TObject *Sender);
	void __fastcall ExitButtonClick(TObject *Sender);
	void __fastcall ChangeButtonClick(TObject *Sender);
	void __fastcall ChangeTask(TObject *Sender);
	void __fastcall PushButtonClick(TObject *Sender);
	void __fastcall PopButtonClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
