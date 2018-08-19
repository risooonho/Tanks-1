GDPC                                                                                 @   res://.import/bullet.png-b16a0fd9e3deba2429a8bb0d93aef77c.stex  �6      3      ��Ы���	.�ji<   res://.import/tank.png-00b3e3d9edf6f2455090fab291073052.stexp:      $      ���q�C�H�%T�($   res://Tanks/BaseTank/Bullet.gd.remap�=      0       C�z�#�pl�_+�5ǈ    res://Tanks/BaseTank/Bullet.gdc �      3      ��%����8�N��r�(    res://Tanks/BaseTank/Bullet.tscn�            �Q���D��_�c,   res://Tanks/BaseTank/PlayerNameText.gd.remap>      8       ��Y��!G�	���@(   res://Tanks/BaseTank/PlayerNameText.gdc       m      ���:Z|d~ఇ��(   res://Tanks/BaseTank/PlayerNameText.tscn�            壣o�eU���xj�3$   res://Tanks/BaseTank/Tank.gd.remap  P>      .       ��@����E&����;��    res://Tanks/BaseTank/Tank.gdc   �      2      ��Qm��7Ucf�7�    res://Tanks/BaseTank/Tank.tscn  �-      �      �p�eS:U�᠀�:(   res://Tanks/BaseTank/bullet.png.import   8      C      �u]^��0�+*d[�%$   res://Tanks/BaseTank/tank.png.import�;      =      '�TZ���l�F��q�   res://icon.png  �>      �      �~dg`!����I�҃   res://project.binary0L      �       �H�jR&Vb�8tA��            GDSC            {      ������������τ�   �������϶���   ����Ҷ��   �����Ӷ�   �����Ӷ�   ��������ض��   �����ڶ�   ������¶   �����϶�   �����������ƶ���   ���������������Ŷ���   ����׶��   ���������������Ӷ���   �������Ķ���   ����������ƶ   ���������Ӷ�   ���ڶ���            �                      Bullets           Tanks         take_hit                                           "      )   	   3   
   4      :      ?      @      G      Q      W      b      f      q      t      y      5TT:=�  �  LNMT:=�  �  T:=�  �  TT3�  L�  MR�  =�  �  P�  �  �  �  P�  L�  MTT3�  LMR�  �	  L�  MTT3�
  L�  MR�  =�  �  L�  �  M�  &�  �  R�  &�  P�  P�  L�  MR�  �  LM�  �  P�  P�  L�  N�  M�  (R�  �  L�  MT[             [gd_scene load_steps=4 format=2]

[ext_resource path="res://Tanks/BaseTank/Bullet.gd" type="Script" id=1]
[ext_resource path="res://Tanks/BaseTank/bullet.png" type="Texture" id=2]


[sub_resource type="CircleShape2D" id=1]

custom_solver_bias = 0.0
radius = 7.0

[node name="Bullet" type="KinematicBody2D" index="0"]

scale = Vector2( 0.35, 0.35 )
input_pickable = false
collision_layer = 1
collision_mask = 1
collision/safe_margin = 0.08
script = ExtResource( 1 )
_sections_unfolded = [ "Material" ]
velocity = Vector2( 0, 0 )
speed = 200

[node name="Sprite" type="Sprite" parent="." index="0"]

scale = Vector2( 0.6, 0.6 )
texture = ExtResource( 2 )
_sections_unfolded = [ "Transform" ]

[node name="CollisionShape2D" type="CollisionShape2D" parent="." index="1"]

shape = SubResource( 1 )


     GDSC            T      ��������������Ķ   ��������������������������Ķ   ����������Ӷ   �������Ӷ���   ����Ӷ��   ����ڶ��   ���¶���   �����϶�   ���������¶�   ��������������ڶ   �������Ŷ���   ����׶��   �������������������ض���   ��������������ض   ��������Ӷ��                                                                    !      %   	   &   
   ,      7      <      =      D      R      5TT=�  �  LNMT=�  ;�  TT3�  L�  MR�  S�  P�  �  �  �  �  TT3�  LMR�  S�  P�  �  LMP�  �  �	  L�  MTT3�
  L�  MR�  �  �  LMP�  �  �  �  T[   [gd_scene load_steps=2 format=2]

[ext_resource path="res://Tanks/BaseTank/PlayerNameText.gd" type="Script" id=1]

[node name="PlayerNameText" type="CenterContainer" index="0"]

anchor_left = 0.0
anchor_top = 0.0
anchor_right = 0.0
anchor_bottom = 0.0
margin_right = 1023.0
margin_bottom = 40.0
rect_pivot_offset = Vector2( 0, 0 )
rect_clip_content = false
mouse_filter = 0
mouse_default_cursor_shape = 0
size_flags_horizontal = 1
size_flags_vertical = 1
use_top_left = false
script = ExtResource( 1 )

[node name="Label" type="Label" parent="." index="0"]

anchor_left = 0.0
anchor_top = 0.0
anchor_right = 0.0
anchor_bottom = 0.0
margin_left = 492.0
margin_top = 13.0
margin_right = 531.0
margin_bottom = 27.0
rect_pivot_offset = Vector2( 0, 0 )
rect_clip_content = false
mouse_filter = 2
mouse_default_cursor_shape = 0
size_flags_horizontal = 1
size_flags_vertical = 4
custom_colors/font_color = Color( 0, 0, 0, 1 )
text = "player"
align = 1
percent_visible = 1.0
lines_skipped = 0
max_lines_visible = -1
_sections_unfolded = [ "custom_colors" ]


     GDSC   u      �        ������������τ�   ������϶   �������������϶�   ����������Ӷ   ���������Ķ�   �涶   �����涶   ��������   ������������   ���ⶶ��   �������ⶶ��   ����ⶶ�   ��������ⶶ�   ����ⶶ�   ��������   �������������Ҷ�   �������������Ҷ�   �����������������������Ķ���   �����޶�   �涶   �����涶   �������϶���   ��¶   �����������Ӷ���   ��Ŷ   ����������������������Ӷ   ������������涶�   ����������������   ���������������   ���������������ⶶ��   ���������������ⶶ��   �����������ն���   �����Ҷ�   ����    ���������������������������Ŷ���   ���������������Ӷ���   �������������������¶���   ���������������������ض�   �����������������ض�   ����   �������������¶�   ���޶���   ����������������Ӷ��   ���������������¶���   ������¶   �����������ݶ���   ����������������ڶ��   �������������ض�   ����Ӷ��   ����������ڶ   ���¶���   �������Ӷ���   �����϶�   ������¶   ����������޶   ���������¶�   �������޶���   �����������Ķ���   ������򶶶   ������������ض��   �����������ƶ���   ����ڶ��   �������Ӷ���   ��������������������������Ķ   ��������Ҷ��   ������Ҷ   ����¶��   ���������¶�   ������Ҷ   ����Ҷ��   ��������������ض   ���������¶�   �������������¶�   �������¶���   �����¶�   ���ݶ���   �������Ӷ���   �����������������ƶ�   ������Ӷ   ���¶���   ����������ٶ   ������������������ض   �������¶���   �������������¶�   ����׶��   �¶�   ����Ӷ��   ζ��   ϶��   �����Ӷ�   ���������������¶���   �����������Ķ���   ����������ƶ   ���������ڶ�   ��������������޶   ���Ӷ���   ���������Ҷ�   �����Ӷ�   �������������ڶ�   ������ڶ   ����¶��   �������������Ҷ�   �����¶�   ����¶��   ������������϶��   �������Ӷ���   ������Ҷ   ���ٶ���   ���������������Ŷ���   ���ڶ���   �������������Ӷ�   �������¶���   ������������ض��   ������������������Ķ   �����������������ݶ�   ���������϶�   ���Ӷ���      player             �             ?                                     '                      (   res://Tanks/BaseTank/PlayerNameText.tscn                     destroy       public_destroy        PlayerNameText     
   on_destroy        /Bullet.tscn      Tanks      
   AI_control        mobile_control        control       Maps      Navigation2D                         	                           	   #   
   )      /      5      ;      A      G      L      V      [      ^      a      g      l      q      v      {      �      �      �      �      �      �       �   !   �   "   �   #   �   $   �   %   �   &   �   '   �   (   �   )   �   *   �   +   �   ,   �   -   �   .   �   /   �   0   �   1   �   2   �   3   �   4   �   5   �   6     7     8     9     :     ;     <      =   &  >   *  ?   +  @   1  A   5  B   >  C   M  D   V  E   [  F   `  G   e  H   n  I   t  J   y  K   z  L   ~  M   �  N   �  O   �  P   �  Q   �  R   �  S   �  T   �  U   �  V   �  W   �  X   �  Y   �  Z   �  [   �  \   �  ]   �  ^   �  _   �  `     a   	  b     c     d     e     f      g   %  h   K  i   Q  j   V  k   Y  l   ]  m   e  n   j  o   n  p   o  q   v  r   |  s   �  t   �  u   �  v   �  w   �  x   �  y   �  z   �  {   �  |   �  }   �  ~   �     �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �     �     �   '  �   7  �   F  �   J  �   S  �   a  �   p  �   y  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �     �     �     �     �     �     �     �     �   %  �   &  �   /  �   3  �   <  �   @  �   H  �   M  �   Q  �   R  �   [  �   j  �   s  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �   �  �     �   	  �     �   5TTB�  TB�  T=�  ;�  TT:=�  �  T:=�  �  T:=�	  �
  T:=�  �  T:=�  �  T:=�  �  T:=�  �  T:=�  �  T:=�  �  T=�  ;�  T=�  �  L�  N�  MT=�  �  T=�  T=�  T:=�  �  T=�  �  T=�  �  T=�  �  T=�  �  T=�  �  T=�  T=�   �  TT:=�!  �  T:=�"  �  T:=�#  �  T:=�$  �  T:=�%  �  T:=�&  �  T=�'  �	  T=�(  �	  T=�)  T=�*  �
  T=�+  �%  T=�,  T=�-  �  TTTT:=�.  ?L�  MT:=�/  �  L�  N�  MTT3�  L�0  MR�  &�0  
�  R�  �  �  �  �   �  �  �1  L�  M�  �1  L�  N�  M�  (R�  �  �0  TT3�  L�0  MR�  =�2  �3  L�  M�  &�2  R�  �2  P�  �0  �  �  �0  TT3�4  LMR�  �  �  �  �5  L�  NN�  M�  =�6  �7  LMP�8  LMP�9  LM�  �  �A  L�6  �  M�  �,  S�:  �  �  S�;  �  �<  L�  M�  =�=  �.  P�>  LM�  �=  P�?  �/  �  �@  L�=  M�  �  &�!  R�  �,  P�A  �  �  �  �  �  0�  '�  R�  �  �  �  (R�  �  �  TT3�B  LMR�  =�C  �  P�>  LM�  �C  P�  �  L�  N�  MP�D  L�  M�C  P�E  �  �C  P�F  �  P�F  �  �G  LMP�@  L�C  MTT3�H  LMR�  =�I  �&  �  =�J  �	  �  )�K  �L  LMP�M  L�  MR�  &�K  �K  P�N  R�  =�O  �K  P�F  P�P  L�F  M�  &�O  	�I  R�  �I  �O  �  �J  �K  �  1�J  TT3�Q  L�R  N�S  N�T  MR�  =�U  �  �  =�V  �	  L�R  P�W  �S  P�X  �R  P�X  �S  P�W  N�R  P�W  �S  P�W  �R  P�X  �S  P�X  M�  &�V  	�  R�  �U  �  �  (R�  �U  �  �  �U  �U  �  �T  �  �Y  L�U  M�  �  �U  TT3�Z  L�T  MR�  &�+  �%  R�  &�,  R�  &�,  P�[  LMR�  �-  �,  P�[  LMP�\  L�  M�  &�-  R�  �B  LM�  �+  �  TT3�]  L�T  MR�  �Z  L�T  M�  �*  �T  �  �+  �T  �  �(  �H  LM�  &�(  R�  &�*  �"  R�  �'  �L  LMP�M  L�  MH�  IP�3  L�  M�  �)  �'  P�^  L�F  N�(  P�F  N�  M�  �*  �  �  �  �  �  �  �  �  �  �  &�)  P�_  LM�  R�  =�S  L�)  H�  I�F  MP�`  LM�  =�R  �  L�  N�  MP�D  L�  M�  �Q  L�R  N�S  N�T  M�  &�(  P�F  P�P  L�F  M�#  �-  R�  �  �  L�  N�  MP�D  L�  M�  '�-  R�  �  �  L�  N�  M�  �S  L�(  P�F  �F  MP�`  LM�  �R  �  L�  N�  MP�D  L�  M�  �Q  L�R  N�S  N�T  M�  +�)  P�_  LM�  �)  H�  IP�P  L�F  M	�$  R�  �)  P�a  L�  M�  (R�  �  �  L�  N�  MTT3�b  L�T  MR�  =�U  �  �  �  �  L�  N�  M�  �  &�  R�  �U  �  �  '�  R�  �U  �  �  �U  �U  �  �T  �  �Y  L�U  M�  �  �U  �  �  &�  R�  �  �  L�  N�  MP�D  L�  M�  '�  R�  �  �  L�  N�  �  MP�D  L�  M�  �  &�  R�  �  �  �  �B  LMTT3�c  L�T  MR�  =�U  �  �  �  �  L�  N�  M�  �  &�d  P�e  L�	  MR�  �U  �  �  '�d  P�e  L�  MR�  �U  �  �  �U  �U  �  �T  �  �Y  L�U  M�  �  �U  �  �  &�d  P�e  L�  MR�  �  �  L�  N�  MP�D  L�  M�  '�d  P�e  L�  MR�  �  �  L�  N�  �  MP�D  L�  MTT3�f  L�g  MR�  &�  �!  �N  �g  6�h  R�  &�g  P�i  �  �g  P�j  �g  P�k  R�  �B  LMTT3�l  L�T  MR�  &�   R�  �m  L�  N�T  M�  �  �n  L�  M�  (R�  �  �  L�  N�  MTT3�o  L�0  MR�  P�  �0  TT3�p  LMR�  �q  L�  M�  �r  L�  M�  �   �  TT3�s  LMR�  �r  L�
  M�  �q  L�
  M�  �t  LMT[              [gd_scene load_steps=4 format=2]

[ext_resource path="res://Tanks/BaseTank/Tank.gd" type="Script" id=1]
[ext_resource path="res://Tanks/BaseTank/PlayerNameText.tscn" type="PackedScene" id=2]
[ext_resource path="res://Tanks/BaseTank/tank.png" type="Texture" id=3]

[node name="Tank" type="KinematicBody2D"]

position = Vector2( 544.794, 391.518 )
z_index = -1
input_pickable = false
collision_layer = 1
collision_mask = 1
collision/safe_margin = 0.08
script = ExtResource( 1 )
_sections_unfolded = [ "Collision", "Transform", "Z Index" ]
__meta__ = {
"_edit_group_": true
}
UP = 16777232
DOWN = 16777234
LEFT = 16777231
RIGHT = 16777233
SHOOT = 77
rotation_speed = 5
movement_speed = 130
go_back_speed_multiplier = 0.5
health = 1
is_controlled_by_mobile = false
AI = false
seconds_between_path_updates = 1
stop_at_distance = 30
clear_path_points_at = 30
minimum_shoot_cooldown = 0.5
field_of_detection = 10000
player_name_label = ExtResource( 2 )
label_position = Vector2( 0, 20 )

[node name="ShootPosition" type="Position2D" parent="." index="0"]

position = Vector2( 0, -16.2495 )
_sections_unfolded = [ "Transform" ]

[node name="CollisionPolygon2D" type="CollisionPolygon2D" parent="." index="1"]

visible = false
build_mode = 0
polygon = PoolVector2Array( -6.11273, -7.94418, -6.08112, 8.79211, 5.90994, 8.79211, 5.79102, -7.78333, 1.89407, -7.78045, 1.89407, -13.8325, -1.839, -13.776, -1.839, -7.95014 )

[node name="Sprite" type="Sprite" parent="." index="2"]

texture = ExtResource( 3 )

[node name="Description" type="RichTextLabel" parent="." index="3"]

visible = false
anchor_left = 0.0
anchor_top = 0.0
anchor_right = 0.0
anchor_bottom = 0.0
margin_right = 40.0
margin_bottom = 40.0
rect_pivot_offset = Vector2( 0, 0 )
rect_clip_content = true
mouse_filter = 0
mouse_default_cursor_shape = 0
size_flags_horizontal = 1
size_flags_vertical = 1
bbcode_enabled = false
bbcode_text = ""
visible_characters = -1
percent_visible = 1.0
meta_underlined = true
tab_size = 4
text = "The green tank from the previous game."
scroll_active = true
scroll_following = false
selection_enabled = false
override_selected_font_color = false

[node name="RayCast2D" type="RayCast2D" parent="." index="4"]

visible = false
enabled = false
exclude_parent = true
cast_to = Vector2( 0, -200 )
collision_mask = 1


 GDST!   !             PNG �PNG

   IHDR   !   !   W��o   �IDATX��WK� ����oE���
�s�l�$D�Tc���[��$HE�7fz���D�8�Y�4���v 7#Ǽ�k̑�3�d�\ճG�"1��[+F��e?Qis6$�X>-�p&Vɻu��L >�Ī{���:����`��$��롉����Zf"����4��3➫^�b��k��_~san�1������-*��:�_�U���I:8�M    IEND�B`�             [remap]

importer="texture"
type="StreamTexture"
path="res://.import/bullet.png-b16a0fd9e3deba2429a8bb0d93aef77c.stex"

[deps]

source_file="res://Tanks/BaseTank/bullet.png"
dest_files=[ "res://.import/bullet.png-b16a0fd9e3deba2429a8bb0d93aef77c.stex" ]

[params]

compress/mode=0
compress/lossy_quality=0.7
compress/hdr_mode=0
compress/normal_map=0
flags/repeat=0
flags/filter=true
flags/mipmaps=false
flags/anisotropic=false
flags/srgb=2
process/fix_alpha_border=true
process/premult_alpha=false
process/HDR_as_SRGB=false
stream=false
size_limit=0
detect_3d=true
svg/scale=1.0
             GDST!   !             PNG �PNG

   IHDR   !   !   W��o   �IDATX��V�� ��I���YI��U�	,}(�	���=��E�9/\  ��$�ʾ�!\�،�e����`�D��5�	�{��P]hb�@H��r��[P�-�!g���0�����cb��4��D]��@9Y�1s�`1�[�tL�$B�7"�Xa�D,��ZQ|�c!�F���P�7�-��#Մ�����qLR������@�d{    IEND�B`�            [remap]

importer="texture"
type="StreamTexture"
path="res://.import/tank.png-00b3e3d9edf6f2455090fab291073052.stex"

[deps]

source_file="res://Tanks/BaseTank/tank.png"
dest_files=[ "res://.import/tank.png-00b3e3d9edf6f2455090fab291073052.stex" ]

[params]

compress/mode=0
compress/lossy_quality=0.7
compress/hdr_mode=0
compress/normal_map=0
flags/repeat=0
flags/filter=true
flags/mipmaps=false
flags/anisotropic=false
flags/srgb=2
process/fix_alpha_border=true
process/premult_alpha=false
process/HDR_as_SRGB=false
stream=false
size_limit=0
detect_3d=true
svg/scale=1.0
   [remap]

path="res://Tanks/BaseTank/Bullet.gdc"
[remap]

path="res://Tanks/BaseTank/PlayerNameText.gdc"
        [remap]

path="res://Tanks/BaseTank/Tank.gdc"
  �PNG

   IHDR   @   @   �iq�  qIDATx��{pTU����~���I�A	$2$�H E, 
(�>��ؙ\vvqtwj�ف�}��H�S�̨�*����0��
��S^�
B!$��t������!��N��t�_U�n�9�;������sסO�'}��QA!~'i�E�Dw2��P��w=�%EY}���c�˕�ɢ�!u�$m�)��qz�ȷD�~F����y��ly���n\s�i�}�����$!�Pi��4:$YF�V��g%H0��u��� *�.����zr�W֥Ô���V-���>��Z�G�d�����B I2*��FK��A� !��_�#1��'��:� �MH��V�ܯ~\mV���-�HZYZ(@Vk���H�
�V�@�ZYZ(Ձd��V����akPxP�������:[�$�����KJ00u|	�Y�^��43u|	I	�7��U ��������=e<��*bX�@�(�¦���C��ŢG�[6!AE���%v)g���X[�EϘ;�hh�L徱E!Q^�ʻ{�9|��qy&�*�����OEu]�r��Y�-�Ⱥ�8x����F�2����,���u��n�ɩs�1�7�H���w�/���/��x=��3���ɜ�y����ov)���������%\� ��6��%-A�̒L�����y<��JZ�Θ��i޴��HN�g�;�x{Ou��� �r���;�L�@3�Ņ�3f�������<����%�"91�iG�R�ض ����8�L��2��cu̽+��/[��}��˖�u!�tȼ��XS�]k�	:5�������3��t��ڝ��W������(�]�7uĊ�:��� �
��֨ew��#VD��j���L�NO��Z��CfG���N}�Q��_>�ߟ6�݇��ݻ��t�
z���/z��&�Mu���F[Ԋ�Fe���&;���S����͍�<^����9L�= ��c+���\1bړ
���6��?������_�������%���wSZ\@^N&�y���*7oiT�`^� ����z�<���'��{�/`Ъ��������x��;��r4[�eFR��b�̛�ί/�v� v�n�G�����qx�,�t��5�}2�7�A�u�/p���{x�e�Y�e��9�9�'�X2o&��>?p�W��� �dֿ�sj��<���@ׯ�o���	P���yё��Ǡ��l�wy���}l����l�WZB��h�v�˗�C�լ�v��� ���o�x��W7�|�U�N#�j�/�׫���=��qŅ���*�B��#�mn��k��=�4lް���E���'b�����\�:��6_X44Y�6�1� ��{;3� �lSM�']a��ǻ)��a�LML�OLK�P^YÇ��7��� ���:Ԓ�s�T���QK
���:�����(p��
����ݹ)��ҺՔ��;7�W�n�bÕ^�G4�ӧ{Y��2��=�Ѫ$��CI��AC����c���z����df��dHZ�/�k���`m�+ǁ�8�>?�toD�#^�u���8/�E�1 ��ƽ��ܓ�ʻ{����ͅ�����\`����J�(+�������hvz{(�T<��`Oq�ed�8w��-f��G���l6n�Ȃ���HY.=QGzb�����,�������l��~�ŋs��9��q,-+�F��sH,^�b�n7�~����� 8�N^�u����������dV/,e��RJ����Oaf߾�����8��A����,��r�n7����{8���b@AEE��[��]�< ���|s�$�$A�9�������}�X,TTT �`pJ���쀦k�O�V2]���d�~�ds�ф�{t��d�{|��hlss���|

��.%Ib����>v���̙3���*����ū���Ob�
+����2����b�op���<��̝�q�ͬX����HO7S�@+W�@A��'�P=6A�3m����xfZ���!pz�l=ZǺ��!��=�������yj�`^x�e�4*E��e�>��*K������p���O��
�Z����9|�`�ח1^[_�8u9d_@a͞j��&˨�j���B�Yb�7��z5�PX�eM�r#�y3��'�b@�-@����Q�I�Ë�����\�쥢������e$�(�H�d�`2h04�����j����r����7ٹb�`4h�I�c� c�<-.~�ցee%1:��c:���fN��|`ţ%dܰ(�j�`ux9��ƀ-9ƞm7Up��*�����x��O�?��Ia�?�@٦���RY��P������_Tauxivt]��=��؋%��|� *��r���uV%�Ft*	w���,	2���l�;+�����|J�R�%A ��N%��%ꬮ�A�,��C����lms`��9,f���
���7�ʜ�C%K�\qt�7��\q��%�7��a����.u��h���j�-��BÇ���n��7�UO|s�������iq�P�}к0{i�?4! 9N�A�"N�U͎�B1<#���z�������)&��=�2�8U߽����2No��x�
�V�ɠ!��s�^�U���K=wp�Z�:<��khs�hluc���:�8<~?W�^v�m
Y�(+�Lck���Ԭ�7G�5����3�s�v~��I���ǐ�<�����~(�xk���ǋk61,#��(�v:G-D{$xXF"/��ԫ���0�c�1r�SY2o&*Y���g�m+<RT��_�c�p3�}����EW>�
Wo����ҧf�o��՝���[��f���O��m2���-�����eȩy#�@��<�t���5L9���C�����r?O�����lb��!�pR�--,e-�v�J���>TF�	�B�R�Y�3����i����t#'j[8Uߊ�~W&Rtj���$�s��2�Lj���6;�?���>��?�%rG'�'t��e&�UĬ)�_2�,*TYlT_qP�좱͍��M�ˇ� Th�vL.I�F�z�L�^MZ�s��,���IK@��@�/��a�_��H9���;8���VMqa.%����#7�L�)��'���T�5r��y�WTs�L5�(z�pDuF(�O�������4j�&2R�$���kQIƤ�p���N ����fw���LC��/�9�͢RP��(J�������[���op+P�����B=�_&���i�B��t���w����a��k�.	X�(J��q}'ZA0���q�(J@�j���5jԨUw|d�!�m�J�?n{(
N����s�o�~�]��S}|�dP�=.%�B�;��h��Y?>����Bvۮ��o=,�i]��IZ�w��˳��lY��u���NCWj^��.%e���O-T&�(:��s������|�3�y?��c�ٓ��Z}�s�����J~u�qK    IEND�B`�      ECFG      application/config/name         FirstChildOfBaseTank   application/config/icon         res://icon.png     display/window/stretch/mode         viewport)   rendering/environment/default_environment          res://default_env.tres    GDPC