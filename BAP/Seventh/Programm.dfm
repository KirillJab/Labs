object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 285
  ClientWidth = 432
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Memo: TMemo
    Left = 8
    Top = 16
    Width = 225
    Height = 261
    ReadOnly = True
    TabOrder = 0
    OnClick = MemoUpdate
  end
  object TaskDeleteButton: TButton
    Left = 303
    Top = 229
    Width = 98
    Height = 32
    Caption = 'Delete (K1; K2)'
    TabOrder = 1
    OnClick = TaskDeleteButtonClick
  end
  object AddButton: TButton
    Left = 303
    Top = 97
    Width = 98
    Height = 32
    Caption = 'Add'
    TabOrder = 2
    OnClick = AddButtonClick
  end
  object Button3: TButton
    Left = 303
    Top = 27
    Width = 98
    Height = 32
    Caption = 'Randomize'
    TabOrder = 3
    OnClick = Button3Click
  end
  object EditK1: TEdit
    Left = 336
    Top = 175
    Width = 65
    Height = 21
    TabOrder = 4
  end
  object EditK2: TEdit
    Left = 336
    Top = 202
    Width = 65
    Height = 21
    TabOrder = 5
  end
  object StaticText1: TStaticText
    Left = 310
    Top = 206
    Width = 20
    Height = 17
    Caption = 'K2:'
    TabOrder = 6
  end
  object StaticText2: TStaticText
    Left = 310
    Top = 179
    Width = 20
    Height = 17
    Caption = 'K1:'
    TabOrder = 7
  end
  object EditKey: TEdit
    Left = 336
    Top = 70
    Width = 65
    Height = 21
    TabOrder = 8
  end
  object StaticText3: TStaticText
    Left = 308
    Top = 74
    Width = 26
    Height = 17
    Caption = 'Key:'
    TabOrder = 9
  end
  object DeleteButton: TButton
    Left = 303
    Top = 135
    Width = 98
    Height = 32
    Caption = 'Delete'
    TabOrder = 10
    OnClick = DeleteButtonClick
  end
end
