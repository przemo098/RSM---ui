   M S B A M L   `   `   `  ����I  ELiveCharts.Wpf, Version=0.7.1.5, Culture=neutral, PublicKeyToken=null/clr-namespace:LiveCharts.WpfLiveCharts.Wpf  5       #    LiveCharts.Wpf.DefaultTooltip   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,wpfclr-namespace:LiveCharts.Wpf     5       $	��1.3q�5#      ��5$      �� 5%   
     �� Color$  #202020��6    �� Opacity$ .8Q�6*    � 	Resources 5'       �� 
TargetType �� Property �� Value$   LiveCharts.Wpf.SharedConverter   SharedConverter.   (LiveCharts.Wpf.SharedVisibilityConverter  SharedVisibilityConverter-   'LiveCharts.Wpf.ChartPointLabelConverter  ChartPointLabelConverter5   /LiveCharts.Wpf.ParticipationVisibilityConverter $  ParticipationVisibilityConverter��%�   '��       &	  \     &	 o     &	 �     &	 �     �� 5(   
   " ��6   .�5)      ��  � �� 6+   �� *
Foreground+6J   5*        5+   
   6     5,   
   6(     5-   
   6'     5.   
   6/   5/      ��50      �� 51   
   .R�52      ��  �� Padding$
 10 5q�53   A   ��52      �� *
Background+ �� CornerRadius 67   �� *CornerRadius+��53      �� *BorderThickness+._�54      ��  �� Orientation$ Vertical=�6   .+�55      �� $��Center=�6b   $
��Bold"�6   ��6    �� *Data+	 �� 	Converter#	 [  y�56       �� *Data+#	 [ �� 57      
 � IsSharedSizeScope
 . ��6#   �� *Data.Points+��58      �� 59       �� DataType'   !LiveCharts.Wpf.DataPointViewModel"  6+   .R�5:   "   � $��2q�6'    � ColumnDefinitions 5;   &   �� 5<   *   $
��Auto �6;   �� 5=   *   $
��Auto �6;    z� SharedSizeGroup$ Title��6H   �� 5>   *   $
��Auto �6;   $ Label��6H   �� 5?   *   $
��Auto �6;   $ Participation��6H   .+�5A   &   A� $��11��6.   $��11��69   ��6E   �� *Series.StrokeThickness+��5B   .   �� *Series.Stroke+��6O   �� *Series.Fill+�� 5C   &   $��1��60   $��Center=�6^   $��5 0 0 0q�6y   ��6@   �� *Series.Title+6y   �� 5E   &   $��2��60   $��5 0 0 0q�6�   ��6@   �� *
ChartPoint+#	 [ 6�   �� 5G   &   $��3��60   $��Center=�5H   0   $��5 0 0 0q�6K   ��5G   @   �� *ChartPoint.Participation+ �� StringFormat$ {0:P}��y�5I   0   �� *DataContext.Data+ �� RelativeSource �� *FindAncestor+ �� AncestorType" ��#	 [ 5L   #   5M      5O      5P      5Q      5R      5T      