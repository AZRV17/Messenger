   M S B A M L   `   `   `  ����B  >Message, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MessageMessage  5   	       Message.AdminChat   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   'localclr-namespace:Message     5   	     � Title$  	AdminChat��5   	   $	��450��6   $
��1000��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��10q�6%   .+�5      �� $��Connection Log:��6   $
��Bold"�6/   �� 5      -   5         ��Name$ 
LogListBox��5      $	��100��6P   $��5q�6]   ��6*   �� *ConnectionLog+6]   5      �� 5   
   $��1��6   $��10q�6%   .+�5      �� $��
User List:��6   $
��Bold"�6*   �� 5      -   5        $ UsersListBox��5      $	��100��6M   $��5q�6Z   ��6,   �� *
UserList+6Z   5      � 5   
   $��2��6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $��1��6   .��5      �� -   5        $ MessagesListBox��5      65   5      �� 5       $��2��6    �� Orientation$ 
Horizontal=�6&   $��10q�6?   .+�5!      �� -   5         ��Name$ MessageTextBox��5!      $	��300��6O   $��5q�6[   ��62   �� *MessageText+6[   �� 5"      -   5         ��Name$ 
SendButton��5"      $
��Send��6-   $��5q�6w   ��6W   �� *SendCommand+6w   5#      5$      5%      5&      