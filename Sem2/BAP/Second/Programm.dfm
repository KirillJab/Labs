object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 587
  ClientWidth = 752
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Add: TButton
    Left = 560
    Top = 224
    Width = 137
    Height = 25
    Caption = 'Add'
    TabOrder = 0
    OnClick = AddClick
  end
  object Load: TButton
    Left = 560
    Top = 442
    Width = 137
    Height = 25
    Caption = 'Load'
    TabOrder = 1
    OnClick = LoadClick
  end
  object Sort: TButton
    Left = 560
    Top = 286
    Width = 137
    Height = 25
    Caption = 'Sort'
    Enabled = False
    TabOrder = 2
    OnClick = SortClick
  end
  object Save: TButton
    Left = 560
    Top = 411
    Width = 137
    Height = 25
    Caption = 'Save'
    TabOrder = 3
    OnClick = SaveClick
  end
  object Find: TButton
    Left = 560
    Top = 317
    Width = 137
    Height = 25
    Caption = 'Find'
    Enabled = False
    TabOrder = 4
    OnClick = FindClick
  end
  object Exit: TButton
    Left = 560
    Top = 536
    Width = 137
    Height = 25
    Caption = 'Exit'
    TabOrder = 5
    OnClick = ExitClick
  end
  object Name: TEdit
    Left = 560
    Top = 76
    Width = 137
    Height = 21
    ParentShowHint = False
    ShowHint = True
    TabOrder = 6
    TextHint = 'Name'
  end
  object Sold: TEdit
    Left = 560
    Top = 130
    Width = 137
    Height = 21
    ParentShowHint = False
    ShowHint = True
    TabOrder = 7
    TextHint = 'Sold'
  end
  object Available: TEdit
    Left = 560
    Top = 103
    Width = 137
    Height = 21
    ParentShowHint = False
    ShowHint = True
    TabOrder = 8
    TextHint = 'Available'
  end
  object Color: TEdit
    Left = 560
    Top = 157
    Width = 137
    Height = 21
    ParentShowHint = False
    ShowHint = True
    TabOrder = 9
    TextHint = 'Color'
  end
  object Delivery: TEdit
    Left = 560
    Top = 184
    Width = 137
    Height = 21
    ParentShowHint = False
    ShowHint = True
    TabOrder = 10
    TextHint = 'Delivery'
  end
  object GroupName: TEdit
    Left = 560
    Top = 49
    Width = 137
    Height = 21
    ParentShowHint = False
    ShowHint = True
    TabOrder = 11
    TextHint = 'Group Name'
  end
  object Delete: TButton
    Left = 560
    Top = 380
    Width = 137
    Height = 25
    Caption = 'Delete'
    Enabled = False
    TabOrder = 12
    OnClick = DeleteClick
  end
  object ComboBox: TComboBox
    Left = 560
    Top = 348
    Width = 137
    Height = 21
    Enabled = False
    TabOrder = 13
    Text = 'Search by'
    OnSelect = ComboBoxSelect
    Items.Strings = (
      'by Name'
      'by Name, Group and Color'
      'by Identical attributes (1-3)')
  end
  object Memo: TMemo
    AlignWithMargins = True
    Left = 24
    Top = 49
    Width = 481
    Height = 512
    ScrollBars = ssVertical
    TabOrder = 14
  end
  object StaticText1: TStaticText
    Left = 24
    Top = 26
    Width = 465
    Height = 23
    AutoSize = False
    Caption = 'Group Name'#9'       Name        Avail.'#9'Sold'#9'  Color'#9'     Delivery'
    TabOrder = 15
  end
  object DeleteEdit: TEdit
    Left = 703
    Top = 382
    Width = 23
    Height = 21
    TabOrder = 16
    Visible = False
  end
  object Show: TButton
    Left = 560
    Top = 255
    Width = 137
    Height = 25
    Caption = 'Show'
    TabOrder = 17
    OnClick = ShowClick
  end
  object OpenDialog1: TOpenDialog
    Left = 560
    Top = 496
  end
  object SaveDialog1: TSaveDialog
    Left = 664
    Top = 496
  end
end
