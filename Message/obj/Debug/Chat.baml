   M S B A M L   `   `   `  ����B  >Message, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MessageMessage  5   	       Message.Chat   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   'localclr-namespace:Message     5   	   -   5          � Title$
  Chat��5	   	   $	��450��6   $	��800��6#   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      6!   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   .+�5      �� $��Chat with: ��6   $
��Bold"�6+   $��Center=�6=   �� 5      $��Center=�62   ��6   �� *
ChatName+62   5      �� 5   
   $��1��6   .��5      �� -   5         ��Name$ UsersListBox��5      6.   5      �� 5   
   $��1��6   $��1��6'   .��5      �� -   5        $ MessagesListBox��5      61   5      �� 5   
   $��2��6   $ 
Horizontal=�6"   $��2��6;   $��10q�6O   .+�5      �� -   5         ��Name$ MessageTextBox��5      $	��300��6K   $��5q�6W   ��6.   �� *MessageText+6W   �� 5       -   5         ��Name$ 
SendButton��5       $
��Send��6)   $��5q�6s   ��68   �� *SendCommand+6s   �� 5!      -   5        $ 
ExitButton��5!      $
��Exit��6)   $��5q�6R   5"      5#      5$      