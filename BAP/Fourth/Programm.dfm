object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 254
  ClientWidth = 529
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Task: TEdit
    Left = 20
    Top = 27
    Width = 197
    Height = 21
    ParentShowHint = False
    ShowHint = True
    TabOrder = 0
    TextHint = 'Your Expression'
  end
  object AEdit: TEdit
    Left = 437
    Top = 27
    Width = 73
    Height = 21
    TabOrder = 1
  end
  object BEdit: TEdit
    Left = 437
    Top = 54
    Width = 73
    Height = 21
    TabOrder = 2
  end
  object CEdit: TEdit
    Left = 437
    Top = 81
    Width = 73
    Height = 21
    TabOrder = 3
  end
  object DEdit: TEdit
    Left = 437
    Top = 108
    Width = 73
    Height = 21
    TabOrder = 4
  end
  object Letter: TStaticText
    Left = 411
    Top = 54
    Width = 20
    Height = 17
    Caption = ' b: '
    TabOrder = 5
  end
  object StaticText1: TStaticText
    Left = 411
    Top = 27
    Width = 20
    Height = 17
    Caption = ' a: '
    TabOrder = 6
  end
  object StaticText2: TStaticText
    Left = 411
    Top = 81
    Width = 19
    Height = 17
    Caption = ' c: '
    TabOrder = 7
  end
  object StaticText5: TStaticText
    Left = 411
    Top = 108
    Width = 20
    Height = 17
    Caption = ' d: '
    TabOrder = 8
  end
  object EEdit: TEdit
    Left = 437
    Top = 135
    Width = 73
    Height = 21
    TabOrder = 9
  end
  object StaticText6: TStaticText
    Left = 411
    Top = 135
    Width = 20
    Height = 17
    Caption = ' e: '
    TabOrder = 10
  end
  object StaticText3: TStaticText
    Left = 239
    Top = 29
    Width = 12
    Height = 17
    Caption = '='
    TabOrder = 11
  end
  object Result: TEdit
    Left = 268
    Top = 27
    Width = 114
    Height = 21
    ParentShowHint = False
    ReadOnly = True
    ShowHint = True
    TabOrder = 12
    Text = 'Result'
  end
  object SolveButton: TButton
    Left = 411
    Top = 205
    Width = 99
    Height = 34
    Caption = 'Solve'
    TabOrder = 13
    OnClick = SolveButtonClick
  end
  object FillVariantButton: TButton
    Left = 411
    Top = 162
    Width = 99
    Height = 37
    Caption = '15th Variant'
    TabOrder = 14
    OnClick = FillVariantButtonClick
  end
  object Notation: TEdit
    Left = 20
    Top = 70
    Width = 197
    Height = 21
    ParentShowHint = False
    ReadOnly = True
    ShowHint = True
    TabOrder = 15
    Text = 'Reverse Polish Notation'
  end
end
