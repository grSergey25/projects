   M S B A M L   `   `   `  ���� J  FGetExchangeRate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:GetExchangeRateGetExchangeRate       GetExchangeRate.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:GetExchangeRate     -     � Title$*  $Получить курс валют��$	��200��$	��600�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�.���  � ColumnDefinitions �� �� $
��Auto ��� $
��0.8* �.+�� $��2q� � RowDefinitions �� �� $
��Auto ��� $
��Auto �.+��  �� �� $
��Auto ��� .+��� -    ��Name$ ComboBox_Сurrency_1��$
��Bold"�$��Center=�$��Center=�$��80��$��30��$��4q�$��Right=��� $��/��$��1��$
��Bold"�$��19(�$��Center=�$��Center=��� -   $ ComboBox_Сurrency_2��$
��Bold"�$��Center=�$��Center=�$��2��$��80��$��30��$��4q�$
��Left=��� $��1��$��2���� -    ��Name$ Button_GetExchangeRate��{�.  $��2��$	��140��$��30��$*��$Получить курс валют��$��4q�$
��Bold"��� $	��0.4q�
�������$��1��� $��2��$��2q� �� $
��0.6* ���  �� �� $
��Auto ��� �� �� �� �� $
��Auto ��� .+��� $��2��$��Парметры БД:��$��Italic$�$��12(�$
��Bold"�$��Center=�$��Center=��� $��1��$��2���� $��2��$��Сервер:��$��12(�$��Italic$�$��Right=�$��Center=��� $��3��$��БД:��$��12(�$��Italic$�$��Right=�$��Center=��� $��4��$��Логин:��$��12(�$��Italic$�$��Right=�$��Center=��� $��5��$��Пароль:��$��12(�$��Italic$�$��Right=�$��Center=��� -    ��Name$ TextBox_serv��$��Center=�$��MYSQLSERVER\MYSQLSERVER��$��2��$��1��$��2q�$��12(�$
��Bold"��� -   $ 
TextBox_db��$��Center=�$��TESTDB��$��3��$��1��$��2q�$��12(�$
��Bold"��� -   $ TextBox_log��$��Center=�$��sa��$��4��$��1��$��2q�$��12(�$
��Bold"�G� -    G�Name$ PasswordBox_psw��	 G� Password$	 	Gfhjkm123��$��Center=�$��5��$��1��$��2q�$��12(�$
��Bold"��� $��6��$��2���� -	   $ Button_ConnectDB��$��7��$��2q�$��Подключиться��$��12(�$
��Bold"�$��2��$	��100��