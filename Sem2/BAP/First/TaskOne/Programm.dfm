object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 501
  ClientWidth = 1031
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Image: TImage
    Left = 0
    Top = 0
    Width = 900
    Height = 500
  end
  object Button1: TButton
    Left = 920
    Top = 176
    Width = 93
    Height = 42
    Caption = 'Create a cart'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 920
    Top = 240
    Width = 93
    Height = 41
    Caption = 'Fill the cart'
    TabOrder = 1
    Visible = False
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 920
    Top = 304
    Width = 93
    Height = 45
    Caption = 'Change direction'
    TabOrder = 2
    Visible = False
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 920
    Top = 368
    Width = 93
    Height = 41
    Caption = 'Push the cart'
    TabOrder = 3
    Visible = False
    OnClick = Button4Click
  end
  object SpeedScrollBar: TScrollBar
    Left = 920
    Top = 432
    Width = 93
    Height = 17
    Max = 6
    Min = 1
    PageSize = 0
    Position = 1
    TabOrder = 4
    Visible = False
    OnChange = SpeedScrollBarChange
  end
  object SpeedText: TStaticText
    Left = 920
    Top = 455
    Width = 34
    Height = 17
    Caption = 'Speed'
    TabOrder = 5
    Visible = False
  end
  object Timer: TTimer
    Enabled = False
    Interval = 17
    OnTimer = TimerTimer
    Left = 976
    Top = 16
  end
  object CargoTimer: TTimer
    Enabled = False
    Interval = 10
    OnTimer = CargoTimerTimer
    Left = 928
    Top = 16
  end
end
