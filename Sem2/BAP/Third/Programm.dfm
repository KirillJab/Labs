object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 662
  ClientWidth = 722
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
    Top = 48
    Width = 473
    Height = 283
    ItemHeight = 13
    ParentShowHint = False
    ShowHint = False
    TabOrder = 1
    TabWidth = 40
  end
  object DateTimePicker: TDateTimePicker
    Left = 584
    Top = 48
    Width = 105
    Height = 21
    Date = 43964.000000000000000000
    Time = 0.417114687501452900
    ParentShowHint = False
    ShowHint = True
    TabOrder = 2
  end
  object Address: TEdit
    Left = 520
    Top = 102
    Width = 169
    Height = 21
    ParentShowHint = False
    ShowHint = True
    TabOrder = 3
    TextHint = 'Address'
  end
  object Name: TEdit
    Left = 520
    Top = 75
    Width = 169
    Height = 21
    ParentShowHint = False
    ShowHint = True
    TabOrder = 4
    TextHint = 'Name'
  end
  object Add: TButton
    Left = 545
    Top = 146
    Width = 120
    Height = 25
    Caption = 'Add'
    TabOrder = 5
    OnClick = AddClick
  end
  object Update: TButton
    Left = 545
    Top = 208
    Width = 120
    Height = 25
    Caption = 'Update'
    TabOrder = 6
    OnClick = UpdateClick
  end
  object CompleteTheOrder: TButton
    Left = 545
    Top = 239
    Width = 120
    Height = 25
    Caption = 'Complete the order'
    TabOrder = 7
    OnClick = CompleteTheOrderClick
  end
  object ShowInfo: TButton
    Left = 545
    Top = 270
    Width = 120
    Height = 25
    Caption = 'Show Info'
    Enabled = False
    TabOrder = 8
    OnClick = ShowInfoClick
  end
  object Id: TEdit
    Left = 520
    Top = 48
    Width = 58
    Height = 21
    ParentShowHint = False
    ShowHint = True
    TabOrder = 9
    TextHint = 'Id'
  end
  object DoneListBox: TListBox
    Left = 8
    Top = 376
    Width = 473
    Height = 278
    AutoComplete = False
    ItemHeight = 13
    ParentShowHint = False
    ShowHint = False
    TabOrder = 0
    TabWidth = 40
  end
  object CheckOverlaps: TCheckBox
    Left = 552
    Top = 177
    Width = 105
    Height = 25
    Caption = 'Delete Overlaps'
    TabOrder = 10
  end
  object Orders: TStaticText
    Left = 8
    Top = 8
    Width = 273
    Height = 17
    AutoSize = False
    Caption = 'Orders:'
    TabOrder = 11
  end
  object DoneOrders: TStaticText
    Left = 8
    Top = 337
    Width = 67
    Height = 17
    Caption = 'Done orders:'
    TabOrder = 12
  end
  object ComboBox: TComboBox
    Left = 545
    Top = 301
    Width = 120
    Height = 21
    TabOrder = 13
    Text = 'By:'
    OnSelect = ComboBoxSelect
    Items.Strings = (
      'By Id'
      'By Date'
      'By Name')
  end
  object StaticText1: TStaticText
    Left = 16
    Top = 353
    Width = 265
    Height = 17
    AutoSize = False
    Caption = 'Id'#9'    Name'#9'             Address '#9'Date'
    TabOrder = 14
  end
  object StaticText2: TStaticText
    Left = 16
    Top = 25
    Width = 265
    Height = 17
    AutoSize = False
    Caption = 'Id'#9'    Name'#9'             Address '#9'Date'
    TabOrder = 15
  end
  object Exit: TButton
    Left = 520
    Top = 469
    Width = 169
    Height = 76
    Caption = 'Exit'
    TabOrder = 16
    OnClick = ExitClick
  end
end
