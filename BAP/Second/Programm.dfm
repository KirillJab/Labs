object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 587
  ClientWidth = 745
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
    Top = 255
    Width = 137
    Height = 25
    Caption = 'Add'
    TabOrder = 0
    OnClick = AddClick
  end
  object Load: TButton
    Left = 560
    Top = 410
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
    TabOrder = 2
  end
  object Save: TButton
    Left = 560
    Top = 379
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
    TabOrder = 4
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
  object Button1: TButton
    Left = 560
    Top = 348
    Width = 137
    Height = 25
    Caption = 'Delete'
    TabOrder = 12
  end
  object ComboBox1: TComboBox
    Left = 560
    Top = 441
    Width = 137
    Height = 21
    TabOrder = 13
    Text = 'ComboBox1'
  end
  object Memo: TMemo
    AlignWithMargins = True
    Left = 24
    Top = 24
    Width = 481
    Height = 537
    Lines.Strings = (
      
        'Group Name          Name         Available         Sold         ' +
        'Color         Delivery')
    ScrollBars = ssVertical
    TabOrder = 14
  end
  object OpenDialog1: TOpenDialog
    Left = 568
    Top = 496
  end
  object SaveDialog1: TSaveDialog
    Left = 608
    Top = 496
  end
end
