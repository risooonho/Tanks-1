GDPC                                                                                 @   res://.import/bullet.png-1a0fa4cbe06138b4d2c47495267773ac.stex  p      6      �h
>x�p��ŷ�E<   res://.import/tank.png-21151b42f14b184c1b89f5ad0c337d12.stex !      �      �9�]�q�P��@��(   res://Tanks/AlienTank/Bullet.gd.remap   �$      1       �r�S�S��;����x    res://Tanks/AlienTank/Bullet.gdc�      Q      X�w6u&����9y�i$   res://Tanks/AlienTank/Bullet.tscn   0      H      �
�\�ʼ1���z�$   res://Tanks/AlienTank/Tank.gd.remap  %      /       |���C1m�ΖVe� ��    res://Tanks/AlienTank/Tank.gdc  �      >      �<$�H������H���B    res://Tanks/AlienTank/Tank.tscn �      �      ��h-�Y������(   res://Tanks/AlienTank/bullet.png.import �      D      "QA�!�0�֎Q��(   res://Tanks/AlienTank/tank.png.import   �"      @      F�-�wb�`<��ҟ   res://icon.png  P%      �      �~dg`!����I�҃   res://project.binary 3            0���6(�����L        GDSC            *      �����������������Ŷ�   ���Ӷ���   �������Ŷ���   ����׶��   ���������Ӷ�      res://Tanks/BaseTank/Bullet.gd                                        	                                  	   &   
   (      5TT:=�  T=�  �  TT3�  L�  MR�  �  �  �  &�  R�  P�  LM�  0T[               [gd_scene load_steps=4 format=2]

[ext_resource path="res://Tanks/AlienTank/Bullet.gd" type="Script" id=1]
[ext_resource path="res://Tanks/AlienTank/bullet.png" type="Texture" id=2]

[sub_resource type="CircleShape2D" id=1]

custom_solver_bias = 0.0
radius = 7.0

[node name="Bullet" type="KinematicBody2D"]

scale = Vector2( 0.35, 0.35 )
input_pickable = false
collision_layer = 1
collision_mask = 1
collision/safe_margin = 0.08
script = ExtResource( 1 )
_sections_unfolded = [ "Material" ]
velocity = Vector2( 0, 0 )
speed = 500
damage = 1
expiration_seconds = 3

[node name="Sprite" type="Sprite" parent="." index="0"]

scale = Vector2( 0.6, 0.6 )
texture = ExtResource( 2 )
_sections_unfolded = [ "Transform", "Visibility" ]

[node name="Sprite5" type="Sprite" parent="." index="1"]

position = Vector2( 0, -10 )
scale = Vector2( 0.6, 0.6 )
texture = ExtResource( 2 )
_sections_unfolded = [ "Transform", "Visibility" ]

[node name="Sprite2" type="Sprite" parent="." index="2"]

position = Vector2( -10, 0 )
scale = Vector2( 0.6, 0.6 )
texture = ExtResource( 2 )
_sections_unfolded = [ "Transform", "Visibility" ]

[node name="Sprite3" type="Sprite" parent="." index="3"]

position = Vector2( 0, 10 )
scale = Vector2( 0.6, 0.6 )
texture = ExtResource( 2 )
_sections_unfolded = [ "Transform", "Visibility" ]

[node name="Sprite4" type="Sprite" parent="." index="4"]

position = Vector2( 10, 0 )
scale = Vector2( 0.6, 0.6 )
texture = ExtResource( 2 )
_sections_unfolded = [ "Transform", "Visibility" ]

[node name="CollisionShape2D" type="CollisionShape2D" parent="." index="5"]

shape = SubResource( 1 )


        GDSC         %   �      �������ض���   �������¶���   ��������¶��   �����϶�   �������Ӷ���   ����¶��   ������������ƶ��   �����������Ӷ���   �������Ӷ���   �������϶���   ������Ҷ   ��¶   ����Ҷ��   ��������������ض   ��Ŷ   ���������¶�   ��������Ҷ��   ��������������ض   ��������������¶   ���������������¶���      res://Tanks/BaseTank/Tank.gd      ShootPosition4        ShootPosition3        ShootPosition2                                              	                           	      
                     %      ,      .      /      5      >      S      [      d      e      n      �      �      �      �      �      �      �      �       �   !   �   "   �   #   �   $   �   %   5TT=T=�  T=�  TTTTTT3�  LMR�  �  L�  M�  �  �  L�  M�  �  �  L�  M�  0TT3�  LMR�  =�  �  P�  LM�  �  P�	  �  L�  N�  MP�
  L�  M�  P�  �  �  P�  �  P�  �  �  LMP�  L�  M�  �  =�  �  P�  LM�  �  P�	  �  L�  N�  MP�
  L�  M�  P�  �  �  P�  P�  �  �  LMP�  L�  M�  �  =�  �  P�  LM�  �  P�	  �  L�  N�  MP�
  L�  M�  P�  �  �  P�  �  P�  �  �  LMP�  L�  M�  �  =�  �  P�  LM�  �  P�	  �  L�  N�  MP�
  L�  M�  P�  �  �  P�  �  P�  �  �  LMP�  L�  MT[  [gd_scene load_steps=3 format=2]

[ext_resource path="res://Tanks/AlienTank/Tank.gd" type="Script" id=1]
[ext_resource path="res://Tanks/AlienTank/tank.png" type="Texture" id=2]

[node name="Tank" type="KinematicBody2D" index="0"]

position = Vector2( 544.794, 391.518 )
scale = Vector2( 1.36678, 1.40962 )
z_index = -1
input_pickable = false
collision_layer = 1
collision_mask = 1
collision/safe_margin = 0.08
script = ExtResource( 1 )
_sections_unfolded = [ "Collision", "Z Index" ]
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
initial_HP = 1

[node name="ShootPosition" type="Position2D" parent="." index="0"]

position = Vector2( 0.193268, -15.885 )
_sections_unfolded = [ "Transform" ]

[node name="ShootPosition2" type="Position2D" parent="." index="1"]

position = Vector2( 11.244, -1.88312 )
_sections_unfolded = [ "Transform" ]

[node name="ShootPosition3" type="Position2D" parent="." index="2"]

position = Vector2( -10.6506, -1.5202 )
_sections_unfolded = [ "Transform" ]

[node name="ShootPosition4" type="Position2D" parent="." index="3"]

position = Vector2( 0.203247, 12.5722 )
_sections_unfolded = [ "Transform" ]

[node name="Description" type="RichTextLabel" parent="." index="4"]

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

[node name="CollisionPolygon2D" type="CollisionPolygon2D" parent="." index="5"]

visible = false
build_mode = 0
polygon = PoolVector2Array( -3.10843, -14.819, -1.7428, -14.6986, -1.7428, -13.8961, 2.0231, -13.8159, 1.94031, -14.8591, 3.30594, -14.8591, 3.38873, -13.4948, 2.35416, -13.5751, 2.35416, -12.6522, 1.2782, -12.572, 1.31958, -9.56256, 2.39554, -9.60269, 2.27139, -10.7663, 4.87851, -10.6861, 6.90631, -8.3989, 7.19598, -4.18573, 9.18237, -3.54373, 9.26514, 0.308319, 7.23734, 1.03055, 7.32013, 5.40424, 4.75436, 7.41049, 2.47827, 7.41049, 2.35416, 6.1265, 1.69202, 6.1265, 1.52649, 9.17603, 2.31281, 9.29642, 2.47827, 10.3397, 3.4715, 10.4199, 3.63702, 11.6638, 1.98172, 11.5836, 1.98172, 10.6205, -1.49445, 10.7008, -1.53586, 11.6237, -3.10843, 11.4632, -3.10843, 10.4199, -2.03244, 10.4199, -2.03244, 9.25626, -0.915131, 9.21616, -1.03928, 6.28699, -1.99109, 6.20673, -1.94968, 7.29013, -4.8465, 7.49075, -6.83289, 5.04309, -6.91568, 1.11081, -9.10895, 0.468781, -9.06757, -3.82462, -6.83289, -4.34625, -6.91568, -8.3989, -4.8465, -10.6459, -1.99109, -10.5657, -1.86694, -9.76318, -0.749603, -9.68292, -1.08063, -12.2911, -2.15662, -12.3312, -2.11523, -13.6955, -3.06702, -13.6553 )

[node name="Sprite" type="Sprite" parent="." index="6"]

position = Vector2( 0.703522, -0.0401306 )
texture = ExtResource( 2 )


               GDST!   !             PNG �PNG

   IHDR   !   !   W��o   �IDATX���� DJ'�I[99BY�b/����yL Ac��uX:}����O�IID̟��
 ��O��I(§�>�Cjḓ}̑^I$���~�-9HL�t���HN}��Yr�J� l=�M��7�u�N�T/�@q��q���I ���ӒX�C˵<(r2�kY�4����Fs��cf��5(�%����g�`���X�H��[�EE�Y^��J'B=?4xVu    IEND�B`�          [remap]

importer="texture"
type="StreamTexture"
path="res://.import/bullet.png-1a0fa4cbe06138b4d2c47495267773ac.stex"

[deps]

source_file="res://Tanks/AlienTank/bullet.png"
dest_files=[ "res://.import/bullet.png-1a0fa4cbe06138b4d2c47495267773ac.stex" ]

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
            GDST!   !            �  PNG �PNG

   IHDR   !   !   W��o  FIDATX��W1n�0<}B?���h�t�t�����YK�%O�eK=eh�>��a�B��
E)�� %���,����ͩ	 JU��ohM
���������Z�n�Y$J�6e�o%0Β�v�����$�1��$9r����:�/�^�$�o�����V��1������8K}����`�>���އ��w ���L�}�ɮ&����I0~9�� ��1&Ǣ�o%�d$J�?@\�8K�����C�e����D	�,�>�j�@ş�!��Y�ꖫ��!��/����f�"zL5�n˟�� `���8�`ɚtd�D)�wM�ĕ��/���\k�y    IEND�B`� [remap]

importer="texture"
type="StreamTexture"
path="res://.import/tank.png-21151b42f14b184c1b89f5ad0c337d12.stex"

[deps]

source_file="res://Tanks/AlienTank/tank.png"
dest_files=[ "res://.import/tank.png-21151b42f14b184c1b89f5ad0c337d12.stex" ]

[params]

compress/mode=0
compress/lossy_quality=0.7
compress/hdr_mode=0
compress/normal_map=0
flags/repeat=0
flags/filter=false
flags/mipmaps=false
flags/anisotropic=false
flags/srgb=2
process/fix_alpha_border=false
process/premult_alpha=false
process/HDR_as_SRGB=false
stream=false
size_limit=0
detect_3d=true
svg/scale=1.0
[remap]

path="res://Tanks/AlienTank/Bullet.gdc"
               [remap]

path="res://Tanks/AlienTank/Tank.gdc"
 �PNG
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
N����s�o�~�]��S}|�dP�=.%�B�;��h��Y?>����Bvۮ��o=,�i]��IZ�w��˳��lY��u���NCWj^��.%e���O-T&�(:��s������|�3�y?��c�ٓ��Z}�s�����J~u�qK    IEND�B`�      ECFG      application/config/name         FirstChildOfBaseTank   application/run/main_scene(         res://Tanks/Abrams/Abrams.tscn     application/config/icon         res://icon.png  )   rendering/environment/default_environment          res://default_env.tres             GDPC