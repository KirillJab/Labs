object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 253
  ClientWidth = 840
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object ListBox: TListBox
    Left = 8
    Top = 8
    Width = 338
    Height = 225
    ItemHeight = 13
    MultiSelect = True
    TabOrder = 0
    OnClick = ListBoxClick
  end
  object InsertButton: TButton
    Left = 368
    Top = 160
    Width = 105
    Height = 34
    Caption = 'Add Above Chosen'
    Enabled = False
    TabOrder = 1
    Visible = False
    OnClick = InsertButtonClick
  end
  object ExitButton: TButton
    Left = 368
    Top = 200
    Width = 105
    Height = 33
    Caption = 'Exit'
    TabOrder = 2
    OnClick = ExitButtonClick
  end
  object ChooseButton: TButton
    Left = 368
    Top = 120
    Width = 105
    Height = 34
    Caption = 'Save to buffer'
    Enabled = False
    TabOrder = 3
    Visible = False
    OnClick = ChooseButtonClick
  end
  object MemoBuff: TMemo
    Left = 494
    Top = 8
    Width = 338
    Height = 225
    ReadOnly = True
    TabOrder = 4
  end
  object ChangeButton: TButton
    Left = 368
    Top = 8
    Width = 105
    Height = 25
    Caption = 'Change The Task'
    TabOrder = 5
    OnClick = ChangeButtonClick
  end
  object PushButton: TButton
    Left = 368
    Top = 81
    Width = 105
    Height = 33
    Caption = 'Push'
    TabOrder = 6
    OnClick = PushButtonClick
  end
  object PopButton: TButton
    Left = 368
    Top = 120
    Width = 105
    Height = 34
    Caption = 'Pop'
    TabOrder = 7
    OnClick = PopButtonClick
  end
  object CheckEmptyButton: TButton
    Left = 368
    Top = 160
    Width = 105
    Height = 34
    Caption = 'Check If Empty'
    TabOrder = 8
  end
  object QueueEdit: TEdit
    Left = 368
    Top = 54
    Width = 105
    Height = 21
    ParentShowHint = False
    ShowHint = True
    TabOrder = 9
    TextHint = 'Enter new queue member '
  end
end
