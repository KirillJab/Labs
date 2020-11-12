//---------------------------------------------------------------------------

#ifndef ProgrammH
#define ProgrammH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.ComCtrls.hpp>
#include "List.h"

//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TListBox *ListBox;
	TDateTimePicker *DateTimePicker;
	TEdit *Name;
	TButton *Add;
	TButton *Update;
	TButton *CompleteTheOrder;
	TButton *ShowInfo;
	TEdit *Id;
	TEdit *Address;
	TListBox *DoneListBox;
	TCheckBox *CheckOverlaps;
	TStaticText *Orders;
	TStaticText *DoneOrders;
	TComboBox *ComboBox;
	TStaticText *StaticText1;
	TStaticText *StaticText2;
	TButton *Exit;
	void __fastcall AddClick(TObject *Sender);
	void __fastcall CompleteTheOrderClick(TObject *Sender);
	void __fastcall UpdateClick(TObject *Sender);
	void __fastcall ComboBoxSelect(TObject *Sender);
	void __fastcall ShowInfoClick(TObject *Sender);
	void __fastcall ExitClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
