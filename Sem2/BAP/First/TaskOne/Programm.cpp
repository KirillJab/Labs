//---------------------------------------------------------------------------

#pragma hdrstop

#include "Programm.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
Cart cart(100, 400, 265, 450, 10, clWebDarkOrange);
Cargo cargo1(110, 200, 157, 350, clYellow);
Cargo cargo2(165, 250, 253, 300, clOlive);
bool filled;
int i = 0, vertical, k = 1, speed = 8, x1 = cart.x1, x2;



__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{
	Image->Canvas->Pen->Color=clWebLightSkyBlue;
	Image->Canvas->Brush->Color = clWebLightSkyBlue ;
	Image->Canvas->Rectangle(0, 0, 900, 430);
	Image->Canvas->Pen->Color=clWebYellowGreen;
	Image->Canvas->Brush->Color = clWebYellowGreen;
	Image->Canvas->Rectangle(0, 430, 900, 500);

}

void __fastcall TForm1::Button1Click(TObject *Sender)
{
	cart.show(Image->Canvas);
	Button2->Visible = true;
}

void __fastcall TForm1::Button2Click(TObject *Sender)
{
	CargoTimer->Enabled = true;
}

void __fastcall TForm1::Button3Click(TObject *Sender)
{
	k *= -1;
}

void __fastcall TForm1::Button4Click(TObject *Sender)
{
	speed = SpeedScrollBar->Position;
	Timer->Enabled = !Timer->Enabled;
	if(Timer->Enabled)
	{
		Button4->Caption = "Stop the cart";
	}
	else
	{
		Button4->Caption = "Push the cart";
	}
}

void __fastcall TForm1::TimerTimer(TObject *Sender)
{
	cart.hide(Image->Canvas);
	cart.move(Canvas, k * speed, 0, k * speed, 0);
	cart.show(Image->Canvas);
	x2 = x1;
	x1 = cart.x1;
	cargo1.hide(Image->Canvas);
	cargo1.move(Canvas, k * abs(x1 - x2), 0, k * abs(x1 - x2), 0);
	cargo1.show(Image->Canvas);
	cargo2.hide(Image->Canvas);
	cargo2.move(Canvas, k * abs(x1 - x2), 0, k * abs(x1 - x2), 0);
	cargo2.show(Image->Canvas);
}

void __fastcall TForm1::CargoTimerTimer(TObject *Sender)
{
	if(cargo1.y2 != cart.y1)
	{
	cargo1.hide(Image->Canvas);
	cargo1.move(Canvas, 0, 1, 0, 1);
	cargo1.show(Image->Canvas);
	}
	if(cargo2.y2 != cart.y1)
	{
	cargo2.hide(Image->Canvas);
	cargo2.move(Canvas, 0, 1, 0, 1);
	cargo2.show(Image->Canvas);
	}
	if(cargo1.y2 == cart.y1  && cargo2.y2 == cart.y1 )
	{
		CargoTimer->Enabled = false;
		Button3->Visible = true;
		Button4->Visible = true;
		SpeedScrollBar->Visible = true;
		SpeedText->Visible = true;
	}
}

void __fastcall TForm1::SpeedScrollBarChange(TObject *Sender)
{
	speed = SpeedScrollBar->Position;
}

