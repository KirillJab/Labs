object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 699
  ClientWidth = 1047
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnMouseWheelDown = FormMouseWheelDown
  OnMouseWheelUp = FormMouseWheelUp
  PixelsPerInch = 96
  TextHeight = 13
  object Image: TImage
    Left = 0
    Top = 8
    Width = 800
    Height = 700
    OnMouseDown = ImageOnMouseDown
    OnMouseMove = ImageMouseMove
    OnMouseUp = ImageMouseUp
  end
  object RadioGroup1: TRadioGroup
    Left = 831
    Top = 16
    Width = 185
    Height = 233
    Caption = 'Figure:'
    TabOrder = 0
  end
  object Rectangle: TRadioButton
    Left = 848
    Top = 40
    Width = 113
    Height = 17
    Caption = 'Rectangle'
    Checked = True
    TabOrder = 1
    TabStop = True
    OnClick = RectangleClick
  end
  object Square: TRadioButton
    Left = 848
    Top = 72
    Width = 113
    Height = 17
    Caption = 'Square'
    TabOrder = 2
    OnClick = SquareClick
  end
  object Ellipse: TRadioButton
    Left = 848
    Top = 104
    Width = 113
    Height = 17
    Caption = 'Ellipse'
    TabOrder = 3
    OnClick = EllipseClick
  end
  object Circle: TRadioButton
    Left = 848
    Top = 136
    Width = 113
    Height = 17
    Caption = 'Circle'
    TabOrder = 4
    OnClick = CircleClick
  end
  object TextX: TStaticText
    Left = 831
    Top = 304
    Width = 10
    Height = 17
    Caption = 'X'
    TabOrder = 5
  end
  object TextY: TStaticText
    Left = 831
    Top = 336
    Width = 10
    Height = 17
    Caption = 'Y'
    TabOrder = 6
  end
  object TextX2: TStaticText
    Left = 887
    Top = 304
    Width = 10
    Height = 17
    Caption = 'X'
    TabOrder = 7
  end
  object TextY2: TStaticText
    Left = 887
    Top = 336
    Width = 10
    Height = 17
    Caption = 'Y'
    TabOrder = 8
  end
  object PerimetrText: TStaticText
    Left = 981
    Top = 304
    Width = 66
    Height = 17
    Caption = 'PerimetrText'
    TabOrder = 9
  end
  object AreaText: TStaticText
    Left = 981
    Top = 336
    Width = 49
    Height = 17
    Caption = 'AreaText'
    TabOrder = 10
  end
  object StaticText3: TStaticText
    Left = 927
    Top = 304
    Width = 48
    Height = 17
    Caption = 'Perimetr:'
    TabOrder = 11
  end
  object StaticText4: TStaticText
    Left = 927
    Top = 336
    Width = 31
    Height = 17
    Caption = 'Area:'
    TabOrder = 12
  end
  object AngleEdit: TEdit
    Left = 848
    Top = 200
    Width = 81
    Height = 21
    Hint = 'Type angle to rotate the figure'
    ParentShowHint = False
    ShowHint = True
    TabOrder = 13
    TextHint = 'Type to rotate'
    OnChange = AngleEditChange
  end
  object StaticText1: TStaticText
    Left = 806
    Top = 304
    Width = 20
    Height = 17
    Caption = 'x1:'
    TabOrder = 14
  end
  object StaticText2: TStaticText
    Left = 806
    Top = 336
    Width = 20
    Height = 17
    Caption = 'y1:'
    TabOrder = 15
  end
  object StaticText5: TStaticText
    Left = 863
    Top = 304
    Width = 20
    Height = 17
    Caption = 'x2:'
    TabOrder = 16
  end
  object StaticText6: TStaticText
    Left = 863
    Top = 336
    Width = 20
    Height = 17
    Caption = 'y2:'
    TabOrder = 17
  end
  object Triangle: TRadioButton
    Left = 848
    Top = 168
    Width = 113
    Height = 17
    Caption = 'Triangle'
    TabOrder = 18
    OnClick = TriangleClick
  end
end
