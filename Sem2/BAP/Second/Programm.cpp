//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Programm.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
int choice = 0;
int cap = 4;
int length = 0;
Tool *shelf = (Tool*)malloc (cap);

void Push(Tool *tool)
{
	if (length > cap)
	{
		cap *= 2;
		shelf = (Tool*)realloc (shelf, cap);
	}
	shelf[length++] = *tool;
}

void Clear()
{
	length = 0;
}

void Delete(int k)
{
	if(k < length && k > -1)
	{
		length--;
		for(; k < length; k++)
		{
			swap(shelf[k], shelf[k+1]);
		}
	}
	else
	{
		ShowMessage("Invalid Input");
    }
}

void Sort()
{
	for(int i = 0; i < length; i++)
	{
		for(int j = i + 1; j < length; j++)
		{
			if(shelf[i].Available < shelf[j].Available)
			{
				swap(shelf[i], shelf[j]);
			}
		}
	}
}

void MemoAdd(Tool *tool, TMemo *Memo)
{
	AnsiString buff;
	buff = tool->GroupName.c_str();
	buff += "\t";
	buff += tool->Name.c_str();
	buff += "\t";
	buff += tool->Available;
	buff += "\t";
	buff += tool->Sold;
	buff += "\t";
	buff += tool->Color.c_str();
	buff += "\t";
	if(tool->Delivery)
	{
		buff += "Yes";
	}
	else
	{
		buff += "No";
	}
	Memo->Lines->Add(buff);
}

void MemoSearch(TMemo *Memo, string name)
{
	Memo->Lines->Clear();
	for(int i = 0; i < length; i++)
	{
		if(shelf[i].Name == name)
		{
			MemoAdd(&shelf[i], Memo);
		}
	}
}

void MemoSearch(TMemo *Memo, string group, string name, string color)
{
	Memo->Lines->Clear();
	for(int i = 0; i < length; i++)
	{
		if(shelf[i].GroupName == group && shelf[i].Name == name && shelf[i].Color == color)
		{
			MemoAdd(&shelf[i], Memo);
		}
	}
}

void MemoSearch(TMemo *Memo, string name, int z)
{
	Memo->Lines->Clear();

	for(int i = 0; i < length; i++)
	{
		if(shelf[i].Name == name)
		{
			for(int j = 0; j < length; j++)
			{
				if(shelf[j].Name == name)
				{
					int commons = 0;
					string str;

					if(j == i)
					{
						continue;
					}
					if(shelf[i].GroupName == shelf[j].GroupName)
					{
						commons++;
					}
					if(shelf[i].Available == shelf[j].Available)
					{
						commons++;
					}
					if(shelf[i].Sold == shelf[j].Sold)
					{
						commons++;
					}
					if(shelf[i].Color == shelf[j].Color)
					{
						commons++;
					}
					if(shelf[i].Delivery == shelf[j].Delivery)
					{
						commons++;
					}
					if(commons > 0 && commons < 4)
					{
						MemoAdd(&shelf[i], Memo);
						break;
					}
				}
			}
		}
	}
}

void MemoShow(TMemo *Memo)
{
	Memo->Lines->Clear();
	for(int i = 0; i < length; i++)
	{
		MemoAdd(&shelf[i], Memo);
	}
}
//--------------------------------------------------------//
__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{

}

void __fastcall TForm1::AddClick(TObject *Sender)
{
    MemoShow(Memo);
	Tool tool;
	AnsiString buff;

	tool.GroupName = ((AnsiString)GroupName->Text).c_str();
	tool.Name = ((AnsiString)Name->Text).c_str();
	tool.Available = Available->Text.ToInt();
	tool.Sold = Sold->Text.ToInt();
	tool.Color = ((AnsiString)Color->Text).c_str();
	buff = Delivery->Text;
	if(buff == "Yes")
	{
		tool.Delivery = true;
	}
	else
	{
		tool.Delivery = false;
	}

	//Output
	MemoAdd(&tool, Memo);
	Push(&tool);
	Sort->Enabled = true;
	ComboBox->Enabled = true;
	Delete->Enabled = true;
	DeleteEdit->Visible = true;
}

void __fastcall TForm1::LoadClick(TObject *Sender)
{
	if(OpenDialog1->Execute())
	{
		Clear();
		AnsiString buff;
		int count;

		Memo->Lines->LoadFromFile(OpenDialog1->FileName);
		count = Memo->Lines->Count;
		for(int i = 0; i < count; i++)
		{
			Tool *tool = new Tool();

			tool->FromString(((AnsiString)Memo->Lines->Strings[i]).c_str());
			Push(tool);
            tool = NULL;
		}
		if(length > 0)
		{
			Sort->Enabled = true;
			Delete->Enabled = true;
			ComboBox->Enabled = true;
			DeleteEdit->Visible = true;
		}
	}
}

void __fastcall TForm1::SaveClick(TObject *Sender)
{
	if(SaveDialog1->Execute())
	{
		Memo->Lines->SaveToFile(SaveDialog1->FileName);
	}
}

void __fastcall TForm1::ExitClick(TObject *Sender)
{
	free(shelf);
	Form1->Close();
}

void __fastcall TForm1::SortClick(TObject *Sender)
{
	::Sort();
	::MemoShow(Memo);
}

void __fastcall TForm1::ComboBoxSelect(TObject *Sender)
{
	choice = ComboBox->ItemIndex;
    Find->Enabled = true;

	switch(choice)
	{
		case 0:
		{
			GroupName->Enabled = false;
			Available->Enabled = false;
			Sold->Enabled = false;
			Color->Enabled = false;
			Delivery->Enabled = false;
			break;
		}
		case 1:
		{
			Available->Enabled = false;
			Sold->Enabled = false;
			Delivery->Enabled = false;
			break;
		}
		case 2:
		{
			GroupName->Enabled = false;
			Available->Enabled = false;
			Sold->Enabled = false;
			Color->Enabled = false;
			Delivery->Enabled = false;
			break;
		}
	}
}

void __fastcall TForm1::FindClick(TObject *Sender)
{
	 switch(choice)
	 {
		 case 0:
		 {
			MemoSearch(Memo, ((AnsiString)Name->Text).c_str());
			break;
		 }
		 case 1:
		 {
			MemoSearch(Memo, ((AnsiString)GroupName->Text).c_str(), ((AnsiString)Name->Text).c_str(), ((AnsiString)Color->Text).c_str());
			break;
		 }
		 case 2:
		 {
			MemoSearch(Memo, ((AnsiString)Name->Text).c_str(), 1);
			break;
		 }
		 deafult:
		 {
			break;
		 }
	 }

	GroupName->Enabled = true;
	Name->Enabled = true;
	Available->Enabled = true;
	Sold->Enabled = true;
	Color->Enabled = true;
	Delivery->Enabled = true;
}

void __fastcall TForm1::DeleteClick(TObject *Sender)
{
	::Delete(DeleteEdit->Text.ToInt() - 1);
    ::MemoShow(Memo);
}

void __fastcall TForm1::ShowClick(TObject *Sender)
{
    MemoShow(Memo);
}

