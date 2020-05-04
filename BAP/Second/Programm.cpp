//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Programm.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
int sze = 0, capacity = 10;
Tool* shelf = (Tool*)malloc(25*sizeof*shelf);
Tool curtool;
int i;

__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{

}

void push(Tool tool)
{
	if(sze > capacity)
	{
		realloc(shelf, capacity * sizeof(class Tool));
		capacity *= 2;
	}
	shelf[i++] = tool;
}

void __fastcall TForm1::AddClick(TObject *Sender)
{
	wchar_t* temp;
	GroupName->GetTextBuf(curtool.groupName, GroupName->GetTextLen());
	Name->GetTextBuf(curtool.name, Name->GetTextLen());
	Color->GetTextBuf(curtool.color, Color->GetTextLen());
	curtool.available = Available->Text.ToInt();
    curtool.sold = Sold->Text.ToInt();
	if(Delivery->Text == "Yes")
	{
		curtool.delivery = true;
	}
	else
	{
		curtool.delivery = false;
	}
	push(curtool);
}

void __fastcall TForm1::LoadClick(TObject *Sender)
{
	if(OpenDialog1->Execute())
	{
		TFileStream * stream = new TFileStream(OpenDialog1->FileName, fmOpenRead);
		TStringList * strlist = new TStringList;
		strlist->LoadFromStream(stream);
		for(int i = 0; i < strlist->Count; i++)
		{
		shelf[i].extract(strlist->Strings[i].c_str());
		Memo->Lines->Add(shelf[i].string);
		}
		delete stream;
	}
}

void __fastcall TForm1::SaveClick(TObject *Sender)
{
	Memo->Lines->SaveToFile("Shelf.txt");
}






void printTool(Tool curtool)
{
	//Memo->Lines->Add(curtool.groupName>>curtool.nameext>>curtool.available<<" - - "<<curtool.sold<<" - - "<<curtool.color<<" - - "<<curtool.delivery);
}

void __fastcall TForm1::ExitClick(TObject *Sender)
{
	free(shelf);
}

