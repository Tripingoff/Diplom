   M S B A M L   `   `   `  ���� H  DИС ККТД, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ИС_ККТД.PagesИС_ККТД.Pages  b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes #    ИС_ККТД.Pages.AddGroups   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:ИС_ККТД.Pages     ]themeKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2       N� Title$B  <Добавление/Редактирование групп�� � 	Resources    FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType �� 
TargetType	 ��Name
 �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName  FocusVisual1  TextBox.Static.Background  ComboBoxEditableTextBox ��Name  ComboBox.Static.Background  ComboBox.Static.Border  ComboBox.Static.Glyph ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border . *ComboBox.Static.Editable.Button.Background * &ComboBox.Static.Editable.Button.Border ! ComboBox.MouseOver.Background �� EndPoint �� 
StartPoint � Color � Offset  ComboBox.MouseOver.Border  ComboBox.MouseOver.Glyph * &ComboBox.MouseOver.Editable.Background & "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Background  ComboBox.Pressed.Border  ComboBox.Pressed.Glyph ( $ComboBox.Pressed.Editable.Background $   ComboBox.Pressed.Editable.Border /! +ComboBox.Pressed.Editable.Button.Background +" 'ComboBox.Pressed.Editable.Button.Border  # ComboBox.Disabled.Background $ ComboBox.Disabled.Border % ComboBox.Disabled.Glyph )& %ComboBox.Disabled.Editable.Background %' !ComboBox.Disabled.Editable.Border 0( ,ComboBox.Disabled.Editable.Button.Background ,) (ComboBox.Disabled.Editable.Button.Border * ComboBoxToggleButton F�Name ^� 
Conditions �� Binding �� RelativeSource �� AncestorType �� Value �� Mode��%a  &	        &	 N     &	 a     &	 t     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
 �     7   7  7  7  7  7 	 &	     &	 Q    &	 f    &	 �    &	 �    &	 �    &	 �    &	     &	 &    &	 =    &	 T    &	 �    &	 �    &	 �    &	 �    &	     &	 \    &	 q    &	 �    &	 �    &	 �    &	  �    &	! �    &	" 0    &	# C    &	$ X    &	% k    &	& �    &	' �    &	( �    &	) �    &	* �    7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7   7 ! 7 " 7 % 7 # 7 $ 7 & 7 ' 7 ( 7 ) �� .���  � �� �� .R��� $��2q�$	 1 2R�#��� �� . $��1���� $ #5A06EC���� $ #5A06EC���� $ #5A06EC���� $ #5A06EC���� $ #5A06EC���� $ #5A06EC���� $ #5A06EC���� $ #5A06EC���� $ White���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��
 �������  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $	 border��#��z��#��z��#��z��$
 20�� . ._��� $ contentPresenter��|�.  #��z��#��z����. # z #��z�� P�  �@��IsDefaulted . . ��� $ border��# � �� � ��P�  �@J�IsMouseOver . . ��� $ border�� � �� �#4700C3�� $ border�� � �� �#4700C3P�  � �� . . ��� $ border�� � �� �#370098�� $ border�� � �� �#370098P�  � {� .  . ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8   � ���� .���  � �� �� .R��� $��2q�$	 1 2R�#��� �� . $��1���� $ 	#FFFFFFFF���� " ��.���  �@�OverridesDefaultStyle . ��  �@J�	AllowDrop . ��  � ��$ 0����  � ��$ 0����  �@�FocusVisualStyle Z� ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " ��.R��� $ PART_ContentHost��
������ |�.  $��Hidden=�$��Hidden=��� $ #FFFFFF���� $ #5A06EC���� $ 	#FF606060���� $ 	#FFFFFFFF���� $ #5A06EC���� $ Transparent���� $ Transparent���� $	 0,1&�$	 0,0&�.��� $ 	#FFECF4FC��$	 0.0Q�� $ 	#FFDCECFC��$	 1.0Q��� $ 	#FF7EB4EA���� $ 	#FF000000���� $ 	#FFFFFFFF���� $ 	#FF7EB4EA���� $	 0,1&�$	 0,0&�.��� $ 	#FFEBF4FC��$	 0.0Q�� $ 	#FFDCECFC��$	 1.0Q��� $ 	#FF7EB4EA���� $ 	LightGray���� $ #5A06EC���� $ 	#FF000000���� $ 	#FFFFFFFF���� $ #5A06EC���� $	 0,1&�$	 0,0&�.��� $ 	#FFDAEBFC��$	 0.0Q�� $ 	#FFC4E0FC��$	 1.0Q��� $ #5A06EC���� $ 	#FFF0F0F0���� $ #5A06EC���� $ 	#FFBFBFBF���� $ 	#FFFFFFFF���� $ 	#FFBFBFBF���� $ Transparent���� $ Transparent���� " d�.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  �@��	ClickMode$ Press=���  � �� �� " d�.R��� $	 templateRoot��8��  8�� #��z��$
 12�� . ._��� $	 splitBorder��
������ $��1q�$��Right=�$��0q� . #��� r�._�F� $ arrow��F����        ���( ��( јaQ     јaQ P����̰( � �    P����        ���#5A06EC$��Center=�$��0q�$��Center=� ^�  ��  �� *
IsEditable+ �� " �� true��  �� *IsMouseOver+ �� $
 Self=�	 false��  �� *	IsPressed+ �� $
 Self=�	 false��  �� *	IsEnabled+ �� $
 Self=� true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  �@J�IsMouseOver . . ��� $ arrow��8   � ��^�  ��  �� *IsMouseOver+ �� $
 Self=� true��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ��^�  ��  �� *IsMouseOver+ �� $
 Self=� true��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8 	  � ���� $ templateRoot��8 
  � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  � �� . . ��� $ arrow��8   � ��^�  ��  �� *	IsPressed+ �� $
 Self=� true��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ��^�  ��  �� *	IsPressed+ �� $
 Self=� true��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  � {� .  . ��� $ arrow��8   � ��^�  ��  �� *	IsEnabled+ �� $
 Self=�	 false��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ��^�  ��  �� *	IsEnabled+ �� $
 Self=�	 false��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��.���� ���#5A06EC$��2q�
�������$
 30��._��  � RowDefinitions �� $��40 ��� $��* ��� $��24 �.+���  �� Orientation$ 
Horizontal=�$��0��$��Center=�$��Center=�� $��1��$��Center=�$��Center=� �� $��60 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 � � ColumnDefinitions �� �� .+��� $��8��$ Vertical=�$��Center=�$��0��$��2��.+��� -    ��Name$ BtnSave��#��� 
 $��Сохранить��$��20(����#5A06EC
�������$��Center=�$	��Top=�$	��200��$��1��$��213,3,222,0q��� $��0��$��8��$��0��$ Vertical=�$��Right=�.+��� $��0��$��0��$��Номер группы��$
��10 4q�$��20(����#5A06EC$��Right=��� $��1��$��0��$��Код группы��$
��10 5q�$��20(����#5A06EC$��Right=��� $��2��$��0��$ ��Специальность��$
��10 5q�$��20(����#5A06EC$��Right=��� $��3��$��0��$��Курс��$
��10 5q�$��20(����#5A06EC$��Right=��� $��4��$��0��$��Куратор��$
��10 5q�$��20(����#5A06EC$��Right=��� $��6��$��0��$-��'Количество студентов��$
��10 5q�$��20(����#5A06EC$��Right=��� $ Vertical=�$��1��$��0��$��8��$
��Left=�.+��� -     ��Name$  	TxtNumber��$��0 0 0 1q����#5A06EC$��1��$
��Left=�$	��0,2q�$��30��$	��200��$
��10 3q����� *Id_группы+�� -   $  TxtKod��$��0 0 0 1q����#5A06EC$��3��$	��0,2q�$
��Left=�$��30��$	��200��$
��10 3q����� *код_группы+�� -   ! ��Name$! CmbSpecialnost�� + ComboBoxStyle1#��� + $��30��$��2��$
��10 3q�$
��Left=�" �� DisplayMemberPath$" Название��# �� SelectedValuePath$## Id_специальности��$	��200��$ �� SelectedItem$ �� *Специальности+�� -   $  TxtKyrs��$��0 0 0 1q����#5A06EC$	��200��$
��Left=�$��4��$	��0,2q�$��30��$
��10 3q����� *
курс+�� -   $! 
CmbCurator��$#" Id_преподавателя��$## Id_преподователя��$	��200��$��8��$
��Left=�$��1��$	��0,2q�$��30��$
��10 3q�$ �� *Преподователи+�� -   $  TxtCount��$��0 0 0 1q����#5A06EC$	��200��$��30��% �� TextWrapping$
% Wrap=�$��11��$��1��$	��0,2q�$
��Left=�$
��10 3q����� *)'Количество_студентов+�� $��2��