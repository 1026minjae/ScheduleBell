   M S B A M L   `   `   `  ����G  CScheduleBell, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ScheduleBellScheduleBell  5   	       ScheduleBell.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ScheduleBell     5   	   -   5          �Name$  window��5   	    � Title$ ScheduleBell��6   $	��400��6.   $	��310��6;    � 
ResizeMode$ NoResize=�6G    � WindowStyle$
 None=�6]    � WindowStartupLocation$ Manual=�6p    � Topmost .  � Icon$ schedulebell.png��6�    � AllowsTransparency . ��6�   Z� .��5	      � .+�5
   
   � -   5         �Name$ working��5
      $y�Visible=�6    $	��250��65   $��Right=�6A   .+�5      �� ���	#FFDACAB7$
��Left=�6)   $	��137��6D   $��0,0,0,0q�6Q   $	��Top=�6b   $	��250��6z   
���   �6�   �� 5      $
��Left=�6   $��18��63   $��	10,10,0,0q�6?   $
��Wrap=�6R   $��현재 일정��6f   $	��Top=�6s   $	��190��6�   $��Malgun Gothic)�6�   �� 5      -   5        $
��sche��5      ���	#FFDACAB7$
��Left=�69   $��42��6T   $��	10,30,0,0q�6`   $��일정이 없습니다.��6s   $	��Top=�6�   $	��230��6�   $��Malgun Gothic)�6�   $��16(�6�   	 �� TextWrapping$
	 Wrap=�6�   "
 �� VerticalScrollBarVisibility$

 Auto=�6�    �� 
IsReadOnly . 6  �� 5      ���	#FF343434$
��Left=�6)   $��4��6D   $��	10,77,0,0q�6O   $	��Top=�6b   $	��230��6z   �� 5      -   5         ��Name$
 cloc��5      $
��Left=�6&   $��26��6A   $��	10,86,0,0q�6M   $
��Wrap=�6`   $	��Top=�6t   $	��230��6�   $��16(�6�    �� TextAlignment$ Center=�6�   �� 6�   $�0000-00-00 오전 00:00��6�   �� 6�   $	�:00��6�   6�   �� 5      
�������$
��Left=�6%   $	��263��6@   $��	0,137,0,0q�6M   
���   �$	��Top=�6o   $	��250��6�   �� 5      -   5         ��Name$ MissionName��5      $
��Left=�6+   $��23��6F   $��	5,142,0,0q�6R   $
	 Wrap=�6e   $	��Top=�6y   $	��185��6�   6�   �� 5      -   5         ��Name$ AddMissionBtn��5      $��+��6,   $
��Left=�68   $��23��6S   $��195,142,0,0q�6_   $	��Top=�6t   $��50��6�   $��1,0,1,4q�6�   �� 5      $
��Left=�6   $	��220��66   $��	5,170,0,0q�6C   $	��Top=�6V   $	��240��6n   $��2,0,0,0q�6z   .��5      �� -   5         ��Name$
 list��5      $
��Left=�6+   $	��Top=�6F   5      5      �� 5      -   5        $	 min��5         MIN#��[  6"   $
��Left=�6?   $��20��6Z   $��101,112,0,0q�6f   $	��Top=�6{   $��48��6�   .��5      �� $��토글��6   $��0,-1,0,0q�6&   $
��Bold"�68   $��10(�6J   5      5      �� 5   
   -	   5        $ reshow��5        RES#��[ 6!   $
��Left=�6>   $��77��6Y   $��0,10,0,0q�6e   $	��Top=�6w   $��60��6�   $y�Hidden=�6�   6�   5      5      